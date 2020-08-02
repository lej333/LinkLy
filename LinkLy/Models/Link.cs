using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinkLy.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace LinkLy.Models
{
    public class Link : IUserEntity
    {
        [Key]
        [Column("link_ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("link_name")]
        public string Name { get; set; }

        [Required]
        [Column("link_uri")]
        [Url]
        public string Uri { get; set; }

        [Required]
        [Column("domain")]
        public string Domain { get; set; }

        [Column("total_clicks")]
        [DisplayName("Total clicks")]
        public int TotalClicks { get; set; }

        [Column("last_click")]
        [DisplayName("Last click")]
        public DateTime LastClick { get; set; }

        [Column("creation_date")]
        [DisplayName("Creationdate")]
        public DateTime CreationDate { get; set; }

        [Column("modified_date")]
        [DisplayName("Modifieddate")]
        public DateTime ModifiedDate { get; set; }

        [Column("user_ID")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public List<Click> Clicks { get; set; }

        public int CalculateClicks(int days) {
            if (Clicks == null) {
                return 0;
            }

            return (from c in Clicks where c.CreationDate >= DateTime.Now.AddDays(-days) select c.Id).Count();
        }
    }
}
