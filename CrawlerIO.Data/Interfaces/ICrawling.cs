using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Data.Interfaces
{
    interface ICrawling : Base.IGenericRepository<Crawlings>
    {
        Crawlings GetSingle(int pk);
    }
}
