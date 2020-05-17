using AutoFixture;
using FluentAssertions;
using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
using RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.Validation;
using System;
using Xunit;

namespace RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.UnitTests.Validation
{
    public class NominationValidatorTests
    {
        private readonly Fixture fixture;

        public NominationValidatorTests()
        {
            if (fixture == null)
            {
                fixture = new Fixture();
            }
        }

        private NominationValidator CreateNominationValidator()
        {
            return new NominationValidator();
        }

        [Fact]
        public void ValidateNomination_WhenAllValid_ShouldNotReturnAValidationError()
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenProgramCodeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.ProgramCode = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("106 - ProgramCode must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenTransTypeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Trans_Type = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("110 - Trans_Type must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenNominationDateIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.NominationDate = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("112 - NominationDate must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenServiceDateIsNullOrEmptyAndProgramCodeIsFDC_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.ProgramCode = "FDC";
            nomination.ServiceDate = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("114 - ServiceDate must be provided for DSR");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenServiceDateIsNullOrEmptyAndProgramCodeIsMDC_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.ProgramCode = "MDC";
            nomination.ServiceDate = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("114 - ServiceDate must be provided for DSR");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenVINIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.VIN = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("116 - VIN must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenDescriptionIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Description = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("118 - Vehicle Description must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenMakeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Make = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("120 - Vehicle Make must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenModelIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Model = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("122 - Vehicle Model must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenBodyTypeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.BodyType = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("124 - Vehicle BodyType must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenColourIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Colour = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("126 - Vehicle Colour must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenRegoIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Rego = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("128 - Vehicle Rego must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenOwnerTypeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.OwnerType = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("130 - OwnerType must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenFirstNameIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.FirstName = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("134 - FirstName must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenSurnameIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Surname = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("136 - Surname must be provided");
        }

        [Theory]
        [InlineData(null)]
        public void ValidateNomination_WhenDOBIsNullOrEmpty_ShouldReturnExpectedValidationError(DateTime? value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.DOB = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("138 - DOB must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenHomePhoneIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.HomePhone = value;
            nomination.BusinessPhone = value;
            nomination.MobilePhone = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("140 - At least one Phone Number must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenStateofMembershipIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.StateofMembership = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("150 - StateofMembership must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenAddressLine1IsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.AddressLine1 = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("154 - AddressLine1 must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenCityIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.City = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("156 - City must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenStateIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.State = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("158 - State must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenPostcodeIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.Postcode = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("160 - Postcode must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenNominationIDIsNullOrEmpty_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.NominationID = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("162 - NominationID must be provided");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ValidateNomination_WhenStartDateIsNullOrEmptyAndProgramCodeIsSMY_ShouldReturnExpectedValidationError(string value)
        {
            // Arrange
            var nominationValidator = CreateNominationValidator();
            var nomination = fixture.Create<Nomination>();

            nomination.ProgramCode = "SMY";
            nomination.StartDate = value;

            // Act
            var validationMessage = nominationValidator.Validate(nomination);

            // Assert
            validationMessage.Should().Be("114 - StartDate must be provided");
        }
    }
}