using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LinkLy.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LinkLy.Models.DataModels
{
    public class UserSetting : IUserEntity
    {
        [Key]
        [Column("usersetting_ID")]
        public int Id { get; set; }

        [Column("creation_date")]
        [DisplayName("Creationdate")]
        public DateTime CreationDate { get; set; }

        [Column("modified_date")]
        [DisplayName("Modifieddate")]
        public DateTime ModifiedDate { get; set; }

        [Column("user_ID")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
