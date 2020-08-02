using System;

namespace LinkLy.Data.Entities
{
    /// <summary>
    /// This interface will be used as a base for all data structures with relation to ASP.NET users
    /// </summary>
    public interface IUserEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string UserId { get; set; }
    }
}
