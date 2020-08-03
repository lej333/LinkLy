using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinkLy.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LinkLy.Models.DataModels
{
    public class Domain : IUserEntity
    {
        [Key]
        [Column("domain_ID")]
        public int Id { get; set; }

        [Required]
        [Column("domain_name")]
        public string Name { get; set; }

        [Column("creation_date")]
        [DisplayName("Creationdate")]
        public DateTime CreationDate { get; set; }

        [Column("modified_date")]
        [DisplayName("Modifieddate")]
        public DateTime ModifiedDate { get; set; }

        [Column("user_ID")]
        [ForeignKey("user_ID")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
