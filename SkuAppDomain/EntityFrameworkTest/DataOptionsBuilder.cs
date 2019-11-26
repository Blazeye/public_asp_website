using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.EntityFrameworkTest
{
    public class DataOptionsBuilder
    {
        private static DbContextOptionsBuilder _builder;

        public DbContextOptionsBuilder Builder => _builder;

        public DataOptionsBuilder()
        {
            _builder = new DbContextOptionsBuilder();
        }

        public DataOptionsBuilder(DbContextOptions options)
        {
            _builder = new DbContextOptionsBuilder(options);
        }

        public DbContextOptions Build()
        {
            return _builder.IsConfigured ? _builder.Options : null;
        }

        public static implicit operator DbContextOptionsBuilder(DataOptionsBuilder builder)
        {
            return builder.Builder;
        }
    }
}
