using System;

namespace LinkLy.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
