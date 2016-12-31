using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Data.Interfaces
{
    interface IUrl:Base.IGenericRepository<Urls>
    {
        Urls GetSingle(int pk);
    }
}
