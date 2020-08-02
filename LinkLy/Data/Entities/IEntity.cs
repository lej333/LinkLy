using System;

namespace LinkLy.Data.Entities
{
    /// <summary>
    /// This interface will be used as a base for all data structures without relation with ASP.NET users
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
