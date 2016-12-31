using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Data.Repository
{
    public class ElementRepository : Base.GenericRepository<TestDBEntities, Elements>, Interfaces.IElement
    {
        public Elements GetSingle(int pk)
        {
            var query = GetAll().Where(s => s.Id == pk);

            return query.FirstOrDefault();
        }
    }
}
