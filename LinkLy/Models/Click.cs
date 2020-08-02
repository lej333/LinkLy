using LinkLy.Data.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkLy.Models
{
    public class Click : IEntity
    {

        [Key]
        [Column("click_ID")]
        public int Id { get; set; }

        [Column("creation_date")]
        [DisplayName("Creationdate")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Column("creation_ipnumber")]
        [DisplayName("Creation ipnumber")]
        public string CreationIpNumber { get; set; }

        [Column("browser_name")]
        [DisplayName("Browser")]
        public string BrowserName { get; set; }

        [Column("browser_version")]
        [DisplayName("Browser version")]
        public string BrowserVersion { get; set; }

        [Column("os_name")]
        [DisplayName("OS")]
        public string OSName { get; set; }

        [Column("device_type")]
        [DisplayName("Device type")]
        public string DeviceType { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("host_name")]
        [DisplayName("Hostname")]
        public string HostName { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("organisation")]
        public string Organisation { get; set; }

        [Column("postal")]
        public string Postal { get; set; }

        [Column("region")]
        public string Region { get; set; }

        [Required]
        [Column("link_ID")]
        [ForeignKey("link_ID")]
        public int LinkId { get; set; }

        public Link link { get; set; }
    }
}
