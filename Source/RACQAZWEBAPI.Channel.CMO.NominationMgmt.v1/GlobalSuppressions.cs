// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Program.LogAndRunAsync(Microsoft.Extensions.Hosting.IHost)~System.Threading.Tasks.Task{System.Int32}")]
[assembly:
    SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusClient.GetPaymentByIdAsync(System.String)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse}")]
[assembly:
    SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusClient.GetPaymentByIdAsync(System.String)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse}")]
[assembly:
    SuppressMessage("Reliability", "CA1602:Dispose objects before losing scope", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusClient.GetPaymentByIdAsync(System.String)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse}")]
[assembly:
    SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>",
        Scope = "type", Target = "~T:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.Ext_Invoiceid")]
[assembly:
    SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.GetPaymentByIdCommand.ExecuteAsync(System.String,System.Threading.CancellationToken)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly:
    SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "member",
        Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.Serializedresultentity.ext_InvoiceId")]
[assembly:
    SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>",
        Scope = "member",
        Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.Serializedresultentity.ext_InvoiceId")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.CustomServiceCollectionExtensions.AddCustomOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)~Microsoft.Extensions.DependencyInjection.IServiceCollection")]
[assembly:
    SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.ApttusPaymentResponse_to_BillingPaymentJsonCanonicalSchema.Map(RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.BillingPaymentJsonCanonicalSchema)")]
[assembly:
    SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.ApttusPaymentResponseToBillingPaymentJsonCanonicalSchema.Map(RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.BillingPaymentJsonCanonicalSchema)")]
[assembly:
    SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix", Justification = "<Pending>",
        Scope = "type", Target = "~T:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.CacheProfileOptions")]
[assembly:
    SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>",
        Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ApplicationOptions.CacheProfiles")]
[assembly:
    SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~M:Infrastructure.WebApi.Options.ConfigureApttusServiceOptions.Configure(Helper.Library.Options.AzureAdOptions)")]
[assembly:
    SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Utilities.GenerateJsonException.CreateJsonFault(System.String,System.String,System.String,System.String)~RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.BillingPaymentJsonCanonicalSchema")]
[assembly:
    SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Utilities.GenerateJsonException.GetErrorResponseWithHttpStatusCode(System.Int32,System.String,System.String,System.String)~Microsoft.AspNetCore.Mvc.ObjectResult")]
[assembly:
    SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable",
        Justification = "<Pending>", Scope = "type",
        Target = "~T:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Utilities.GenerateJsonException")]
[assembly:
    SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>",
        Scope = "member",
        Target =
            "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse.SerializedResultEntities")]
[assembly:
    SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Utilities.GenerateJsonException.CreateJsonFault(System.String,System.String,System.String,System.String)~RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.BillingPaymentJsonCanonicalSchema")]
[assembly:
    SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>",
        Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.CompressionOptions.MimeTypes")]
[assembly:
    SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member",
        Target =
            "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetPaymentByIdAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetPaymentByIdCommand,System.String)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetPaymentByIdAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetPaymentByIdCommand,System.String)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.ApttusPaymentResponseToBillingPaymentJsonCanonicalSchema.IdentifierMap(RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.BillingPaymentJsonCanonicalSchema)")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.DataArea.AgreementList")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.AgreementListFiltered.IdentifierIdentification")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.AgreementList.IdentifierIdentification")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetAccountIdByReceiptNumberAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetAccountIdByReceiptNumberCommand,RequestReceiptNumber)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetAccountIdByReceiptNumberAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetAccountIdByReceiptNumberCommand,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.RequestReceiptNumber)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusClient.GetAccountIdByReceiptNumberAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.RequestReceiptNumber)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.ApttusWebClient.Models.ApttusPaymentResponse}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetAccountIdByReceiptNumberAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetAccountIdByReceiptNumberCommand,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.RequestReceiptNumber)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Style", "IDE0022:Use block body for methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Apttus.v1.Controllers.ApttusPaymentController.GetAccountIdByReceiptNumberAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IGetAccountIdByReceiptNumberCommand,RACQAZ.Channel.CMO.NominationMgmt.v1.API.ViewModels.RequestReceiptNumber)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Controllers.NominationsController.ProcessCMONominations(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IProcessCMONominationsCommand,RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nominations)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Controllers.NominationsController.ProcessCMONominations(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands.IProcessCMONominationsCommand,RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nominations)~System.Threading.Tasks.Task{Microsoft.AspNetCore.Mvc.IActionResult}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigurePartyIdentifierManagementAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.PartyIdentifierManagementAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyMatchManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigurePartyManagementAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.PartyManagementAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services.CartManagementClient.FinalizeQuotebyCartIdAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.Request.CreateCartRequest)~System.Threading.Tasks.Task{System.Boolean}")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.RestClient.BaseRestClient.PostXmlAsync2``2(``0,System.String)~System.Threading.Tasks.Task{System.String}")]
[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.RestClient.BaseRestClient.SendAsync``2(``0,System.String,System.Net.Http.HttpMethod,System.String)~System.Threading.Tasks.Task{``1}")]
[assembly: SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services.QuoteManagementClient.DummyQuoteAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model.ApttusQuote)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model.ApttusQuote}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.CustomServiceCollectionExtensions.AddCustomOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)~Microsoft.Extensions.DependencyInjection.IServiceCollection")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.PartyMatchManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.CartManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.Program.LogAndRunAsync(Microsoft.Extensions.Hosting.IHost)~System.Threading.Tasks.Task{System.Int32}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.QuoteManagementAuthenticationHandler.SendAsync(System.Net.Http.HttpRequestMessage,System.Threading.CancellationToken)~System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigureQuoteManagementAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.QuoteManagementAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigureServiceBusOptionsAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ServiceBusOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigureServiceBusOptionsAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ServiceBusAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigurePartyMatchManagementAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.PartyMatchManagementAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.ConfigureCartManagementAuthOptions.Configure(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options.CartManagementAuthOptions)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Services.CartManagementClient.FinalizeQuotebyCartIdAsync(RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartRequest.ApttusCartRequest)~System.Threading.Tasks.Task{RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartResponse.ApttusCartResponse}")]
[assembly: SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>", Scope = "member", Target = "~P:RACQAZ.Channel.CMO.NominationMgmt.v1.API.CartManagement.CartResponse.Dataarea.ProductQuoteReference")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ErrorValidations.NominationErrorValidation.ErrorValidation(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ErrorValidations.NominationErrorValidation.ErrorValidation(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants.MappingConstants.PartyResponseValidations(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Constants.MappingConstants.PartyResponseError(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.String")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZWEBAPI.Channel.CMO.NominationMgmt.v1.API.ApplicationBuilderExtensions.UseStaticFilesWithCacheControl(Microsoft.AspNetCore.Builder.IApplicationBuilder)~Microsoft.AspNetCore.Builder.IApplicationBuilder")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.MatchParty.NominationsToMatchPartyMapper.MapExternalIdentifiers(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~RACQAZ.Channel.CMO.NominationMgmt.v1.API.MatchParty.Models.Request.ExternalIdentifiersType")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty.NominationsToCreatePartyMapper.GetIdentifierIdentification(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.Collections.Generic.List{RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request.IdentifierIdentification}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty.NominationsToCreatePartyMapper.MapIdentifierIdentification(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.Collections.Generic.List{RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request.IdentifierIdentification}")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "<Pending>", Scope = "member", Target = "~M:RACQAZ.Channel.CMO.NominationMgmt.v1.API.Mappers.CreateParty.NominationsToCreatePartyMapper.MapIdentifierIdentification(RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model.Nomination)~System.Collections.Generic.List{RACQAZ.Channel.CMO.NominationMgmt.v1.API.PartyManagement.Request.IdentifierIdentificationType}")]
