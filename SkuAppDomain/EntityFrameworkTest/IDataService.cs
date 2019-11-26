using SkuAppDomain.EntityFrameworkTest.LogData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.EntityFrameworkTest
{
    public interface IDataService
    {
        EFFarmContext Service { get; }
    }
}
