using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineShop.DataAccess.Repository.IRepository;

namespace WineShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            PackagingType = new PackagingTypeRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IPackagingTypeRepository PackagingType { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
