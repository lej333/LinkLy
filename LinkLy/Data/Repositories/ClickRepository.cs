using LinkLy.Models.DataModels;
using LinkLy.Data.BaseRepositories;
using LinkLy.Data;

namespace Linkly.Data.Repositories
{
    public class ClickRepository : BaseRepository<Click, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _db;

        public ClickRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}