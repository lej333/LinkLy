using System;

namespace LinkLy.Data.Entities
{
    public interface IUserEntity
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string UserId { get; set; }
    }
}
