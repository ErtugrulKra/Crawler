using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerIO.Data.Interfaces
{
    interface IElement : Base.IGenericRepository<Elements>
    {
        Elements GetSingle(int pk);
    }
}
