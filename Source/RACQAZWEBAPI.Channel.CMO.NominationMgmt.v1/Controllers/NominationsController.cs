namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Controllers
{
    using Constants;
    using Helper.Library.GlobalErrorHandling.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Commands;
    using RACQAZ.Channel.CMO.NominationMgmt.v1.API.Nominations.Model;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Threading.Tasks;

    [ApiVersion(ApiVersionName.V1)]
    [Route("v{api-version:apiVersion}/channel/cmo/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class NominationsController : ControllerBase
    {
        /// <summary>
        ///  WebAPI :Convert CMO nominations sent by Logic App to finalized Apttus Quote for Apttus parties only
        ///</summary>
        /// <param name="command"></param>
        /// <param name="request"></param>
        /// ///This business service receives a set of JSON data for CMO nominations. It parses through each nomination as follows:
        ///The nomination is party-matched, with a new party created if none exists
        ///The product is added to Apttus
        ///Nominations added to Apttus are marked as 'Success'
        ///If a nomination enters the 'Error' status, each nomination is assessed against validation criteria to determine whether it should move into 'Rejected' status
        ///Each nomination is returned to the caller with a status of Success, Error, or Rejected
        /// <returns></returns>
        [HttpPost(Name = NominationsControllerRoute.ProcessCMONominations)]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request details specified are invalid.", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "The caller is not authorised to access this operation.", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The requested resource could not be found.", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status406NotAcceptable, "The specified Accept MIME type is not acceptable.", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An unexpected error occurred.", typeof(ErrorResponse))]
        public async Task<IActionResult> ProcessCMONominations(
            [FromServices] IProcessCMONominationsCommand command,
            [FromBody] Nominations request) => await command.ExecuteAsync(request).ConfigureAwait(false);
    }
}