using RACQAZ.Channel.CMO.NominationMgmt.v1.API.QuoteManagement.Model;
using System.Threading.Tasks;

public interface IQuoteManagementClient
{
    Task<ApttusQuote> CreateQuoteAsync(ApttusQuote request);
}