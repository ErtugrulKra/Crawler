using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Data.Repository
{
    public class UrlRepository : Base.GenericRepository<TestDBEntities, Urls>, Interfaces.IUrl
    {
        public Urls GetSingle(int pk)
        {
            var query = GetAll().Where(s => s.Id == pk);

            return query.FirstOrDefault();
        }
    }
}
