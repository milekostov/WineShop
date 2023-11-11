using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineShop.Models;

namespace WineShop.DataAccess.Repository.IRepository
{
    public interface IPackagingTypeRepository : IRepository<PackagingType>
    {
        void Update(PackagingType obj);
        
    }
}
