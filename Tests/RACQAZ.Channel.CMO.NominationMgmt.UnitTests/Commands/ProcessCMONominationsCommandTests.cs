using AutoFixture;
using Boxed.Mapping;
using FluentAssertions;
using Moq;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartResponse;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Request;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services;
using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ServiceBusMessaging;
using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests.Commands
{
    public class ProcessCMONominationsCommandTests
    {
        private MockRepository mockRepository;

        private Mock<IPartyMatchClient> mockPartyMatchClient;
        private Mock<ICartManagementClient> mockCartManagementClient;
        private Mock<IQuoteManagementClient> mockQuoteManagementClient;
        private Mock<IPartyManagementClient> mockPartyManagementClient;
        private Mock<IServiceBusSender> mockServiceBusSender;

        private Mock<IMapper<Nominations, MatchPartyRequest>> mockPartyMatchMapper;
        private Mock<IMapper<Nominations, PartyRequest>> mockCreatePartyMapper;
        private Mock<IMapper<Tuple<Nominations, RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response.IdentifierIdentificationType>, ApttusQuote>> mockCreateQuoteMapper;
        private Mock<IMapper<ApttusQuote, ApttusCartRequest>> mockFinaliseQuoteMapper;

        private Mock<IValidator<Nomination>> mockValidator;
        private Fixture fixture;
        private ProcessCMONominationsCommand processCMONominationsCommand;
        private Nominations request;
        private RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Response.MatchPartyResponse matchPartyResponse;
        private Nominations nominationSentToQueue;

        public ProcessCMONominationsCommandTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            this.mockPartyMatchClient = this.mockRepository.Create<IPartyMatchClient>();
            this.mockCartManagementClient = this.mockRepository.Create<ICartManagementClient>();
            this.mockQuoteManagementClient = this.mockRepository.Create<IQuoteManagementClient>();
            this.mockPartyManagementClient = this.mockRepository.Create<IPartyManagementClient>();
            this.mockServiceBusSender = this.mockRepository.Create<IServiceBusSender>();

            this.mockPartyMatchMapper = this.mockRepository.Create<IMapper<Nominations, MatchPartyRequest>>();
            this.mockCreatePartyMapper = this.mockRepository.Create<IMapper<Nominations, PartyRequest>>();
            this.mockCreateQuoteMapper = this.mockRepository.Create<IMapper<Tuple<Nominations, RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Response.IdentifierIdentificationType>, ApttusQuote>>();
            this.mockFinaliseQuoteMapper = this.mockRepository.Create<IMapper<ApttusQuote, ApttusCartRequest>>();

            this.mockValidator = this.mockRepository.Create<IValidator<Nomination>>();

            if (this.fixture == null)
            {
                this.fixture = new Fixture();
            }

            SharedArrange();
        }

        private void SharedArrange()
        {
            // Arrange
            processCMONominationsCommand = this.CreateProcessCMONominationsCommand();
            this.request = this.fixture.Create<Nominations>();

            // Setup Party Match
            this.matchPartyResponse = this.fixture.Create<RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Response.MatchPartyResponse>();
            matchPartyResponse.Result.MatchPercent = "100";
            matchPartyResponse.DataArea.Party.PersonStatusIndicator = "Alive";
            matchPartyResponse.DataArea.Party.IdentifierIdentification.First().IdentificationSchemeAgencyIdentifier = "APTTUS";
            mockPartyMatchClient.Setup(mc => mc.MatchPartyAsync(It.IsAny<MatchPartyRequest>())).Returns(Task.FromResult(matchPartyResponse));

            // Setup Create Quote
            var createQuoteResponse = this.fixture.Create<ApttusQuote>();
            createQuoteResponse.Result.ResultCode = MappingConstants.Success;
            mockQuoteManagementClient.Setup(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>())).Returns(Task.FromResult(createQuoteResponse));

            // Setup finalise Quote
            var finaliseQuoteResponse = this.fixture.Create<ApttusCartResponse>();
            finaliseQuoteResponse.Result.ResultCode = MappingConstants.Success;
            mockCartManagementClient.Setup(m => m.FinalizeQuotebyCartIdAsync(It.IsAny<ApttusCartRequest>())).Returns(Task.FromResult(finaliseQuoteResponse));

            nominationSentToQueue = null;
            mockServiceBusSender.Setup(m => m.SendMessage(It.IsAny<Nominations>())).Callback<Nominations>(n => nominationSentToQueue = n);
        }

        private ProcessCMONominationsCommand CreateProcessCMONominationsCommand()
        {
            return new ProcessCMONominationsCommand(
                this.mockPartyMatchClient.Object,
                this.mockCartManagementClient.Object,
                this.mockQuoteManagementClient.Object,
                this.mockPartyManagementClient.Object,
                this.mockServiceBusSender.Object,
                this.mockPartyMatchMapper.Object,
                this.mockCreatePartyMapper.Object,
                this.mockCreateQuoteMapper.Object,
                this.mockFinaliseQuoteMapper.Object,
                this.mockValidator.Object);
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsAnExactMatch_CreateQuoteShouldBeCreated()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockQuoteManagementClient.Verify(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsAnExactMatch_QuoteShouldBeFinalised()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockCartManagementClient.Verify(m => m.FinalizeQuotebyCartIdAsync(It.IsAny<ApttusCartRequest>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsAnExactMatch_SuccessMessageShouldBePlacedOnQueue()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockServiceBusSender.Verify(m => m.SendMessage(It.IsAny<Nominations>()), Times.Once());

            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Success");
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsAnPartialMatch_ShouldNotCreateParty()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "Partial";

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockPartyManagementClient.Verify(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>()), Times.Never());
        }

        [Fact]
        public async Task ExecuteAsync_WhenNoExistingPartyIsFound_PartyShouldBeCreated()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockPartyManagementClient.Verify(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenNominationHasErrorStatus_ValidationsShouldRun()
        {
            // Arrange
            request.DataArea.Nomination.StatusCode = MappingConstants.Error;

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenNominationHasSuccessStatus_ValidationsShouldNotRun()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockServiceBusSender.Verify(m => m.SendMessage(It.IsAny<Nominations>()), Times.Once());

            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Success");
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Never());
        }

        [Fact]
        public async Task ExecuteAsync_WhenValidationsPass_ErrorMessageShouldBePlacedOnQueue()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());
            mockValidator.Setup(m => m.Validate(It.IsAny<Nomination>())).Returns(string.Empty);

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Error");
        }

        [Fact]
        public async Task ExecuteAsync_WhenValidationsFail_RejectedMessageShouldBePlacedOnQueue()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());
            mockValidator.Setup(m => m.Validate(It.IsAny<Nomination>())).Returns("Validation issues...");

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Rejected");
        }

        [Fact]
        public async Task ExecuteAsync_WhenCreatePartyHasATechnicalError_ShouldNotCreateQuote()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockQuoteManagementClient.Verify(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>()), Times.Never());
        }

        [Fact]
        public async Task ExecuteAsync_WhenCreatePartyHasATechnicalError_ErrorMessagShouldBePlacedOnQueue()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Error");
        }

        [Fact]
        public async Task ExecuteAsync_WhenCreateQuoteHasATechnicalError_ShouldNotCreateQuote()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockQuoteManagementClient.Verify(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>()), Times.Never());
        }

        [Fact]
        public async Task ExecuteAsync_WhenFinaliseQuoteHasATechnicalError_ErrorMessagShouldBePlacedOnQueue()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockQuoteManagementClient.Setup(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Error");
        }

        [Fact]
        public async Task ExecuteAsync_WhenMatchPartyHasATechnicalError_ShouldNotCreateParty()
        {
            // Arrange
            mockPartyMatchClient.Setup(m => m.MatchPartyAsync(It.IsAny<MatchPartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockPartyManagementClient.Verify(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>()), Times.Never());
        }

        [Fact]
        public async Task ExecuteAsync_WhenCreatePartyHasATechnicalError_ValidationsShouldBeExecuted()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockPartyManagementClient.Setup(m => m.CreateNewPartyAsync(It.IsAny<PartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenCreateQuoteHasATechnicalError_ValidationsShouldBeExecuted()
        {
            // Arrange
            this.matchPartyResponse.Result.MatchPercent = "0";
            mockQuoteManagementClient.Setup(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenMatchPartyHasATechnicalError_ValidationsShouldBeExecuted()
        {
            // Arrange
            mockPartyMatchClient.Setup(m => m.MatchPartyAsync(It.IsAny<MatchPartyRequest>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenTheQuoteIsCreated_QuoteShouldBeFinalised()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));

            mockQuoteManagementClient.Verify(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>()), Times.Once());
            mockCartManagementClient.Verify(m => m.FinalizeQuotebyCartIdAsync(It.IsAny<ApttusCartRequest>()), Times.Once());
        }

        [Fact]
        public async Task ExecuteAsync_WhenQuoteIsFinalised_SuccessMessageShouldBePlacedOnQueue()
        {
            // Arrange

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));

            mockCartManagementClient.Verify(m => m.FinalizeQuotebyCartIdAsync(It.IsAny<ApttusCartRequest>()), Times.Once());
            mockServiceBusSender.Verify(m => m.SendMessage(It.IsAny<Nominations>()), Times.Once());
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Success");
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsDeceased_ErrorMessageShouldBePlacedOnQueue()
        {
            // Arrange
            this.matchPartyResponse.DataArea.Party.PersonStatusIndicator = "Dead";
            mockQuoteManagementClient.Setup(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            nominationSentToQueue.DataArea.Nomination.StatusCode.Should().Be("Error");
        }

        [Fact]
        public async Task ExecuteAsync_WhenPartyIsDeceased_ValidationsShouldNotBeExecuted()
        {
            // Arrange
            this.matchPartyResponse.DataArea.Party.PersonStatusIndicator = "Dead";
            mockQuoteManagementClient.Setup(m => m.CreateQuoteAsync(It.IsAny<ApttusQuote>())).Throws(new Exception());

            // Act
            var result = await this.processCMONominationsCommand.ExecuteAsync(this.request, default);

            // Assert
            result.Should().BeOfType(typeof(Microsoft.AspNetCore.Mvc.OkResult));
            mockValidator.Verify(m => m.Validate(It.IsAny<Nomination>()), Times.Never());
        }
    }
}