namespace RACQAZ.Channel.CMO.NominationMgmt.v1.API.Options
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     All options for the application.
    /// </summary>
    public class ApplicationOptions
    {
        [Required]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
        public CacheProfileOptions CacheProfiles { get; set; }

        [Required]
        public CompressionOptions Compression { get; set; }

        [Required]
        public ForwardedHeadersOptions ForwardedHeaders { get; set; }

        [Required]
        public KestrelServerOptions Kestrel { get; set; }

        [Required]
        public PartyManagementOptions PartyManagement { get; set; }

        [Required]
        public PartyManagementAuthOptions PartyManagementAuth { get; set; }

        [Required]
        public PartyMatchManagementOptions PartyMatchManagement { get; set; }

        [Required]
        public PartyMatchManagementAuthOptions PartyMatchManagementAuth { get; set; }

        [Required]
        public QuoteManagementOptions QuoteManagement { get; set; }

        [Required]
        public QuoteManagementAuthOptions QuoteManagementAuth { get; set; }

        [Required]
        public CartManagementOptions CartManagement { get; set; }

        [Required]
        public CartManagementAuthOptions CartManagementAuth { get; set; }

        [Required]
        public ServiceBusAuthOptions ServiceBusAuth { get; set; }
    }
}