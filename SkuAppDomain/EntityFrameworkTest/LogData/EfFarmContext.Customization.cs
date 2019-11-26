using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.EntityFrameworkTest.LogData
{
    public partial class EFFarmContext
    {
        private readonly DbContextOptions _options;

        public EFFarmContext()
        {

        }

        public EFFarmContext(DbContextOptions options) 
        {
            _options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_options == null)
            {
                optionsBuilder.UseMySql(@"Server=127.0.0.1;port=3306;User Id=kinderboer;Password=waitword;Host=localhost;Database=super_awesome_child_farm");
            }
        }
    }
}
