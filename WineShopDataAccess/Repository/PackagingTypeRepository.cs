using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineShop.DataAccess.Repository.IRepository;
using WineShop.Models;

namespace WineShop.DataAccess.Repository
{
    public class PackagingTypeRepository : Repository<PackagingType>, IPackagingTypeRepository
    {
        private ApplicationDbContext _db;
        public PackagingTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db; 
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(PackagingType obj)
        {
            _db.PackagingTypes.Update(obj);
        }
    }
}
