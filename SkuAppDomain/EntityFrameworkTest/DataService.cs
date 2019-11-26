using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkuAppDomain.Entities;
using SkuAppDomain.EntityFrameworkTest.LogData;

namespace SkuAppDomain.EntityFrameworkTest
{
    public class DataService : IDisposable, IDataService
    {
        private EFFarmContext _data;
        private DbContextOptions _lastOptions;

        /// <summary>
        /// Gets an instance of the data service.
        /// </summary>
        public EFFarmContext Service
        {
            get
            {
                if(_data != null)
                {
                    return _data;
                }
    
                _lastOptions = _lastOptions ?? new DataOptionsBuilder().Build();
                _data = new EFFarmContext(_lastOptions);

                return _data;
            }
        }

        public DataService()
        {

        }

        public DataService(DataOptionsBuilder builder) // : base(options)
        {
            _lastOptions = builder.Build();
        }

        public DataOptionsBuilder Configure()
        {
            return new DataOptionsBuilder();
        }

        public void UseConfiguration(DataOptionsBuilder builder)
        {
            _data?.Dispose();
            _data = new EFFarmContext(builder.Build());
        }

        public DataService WithScopedService()
        {
            var scopedService = new DataService();
            scopedService.UseConfiguration(new DataOptionsBuilder(_lastOptions));
            return scopedService;
        }

        public DataService WithScopedService(DataOptionsBuilder builder)
        {
            var scopedService = new DataService();
            scopedService.UseConfiguration(builder);
            return scopedService;
        }

        public void Dispose()
        {
            _data?.Dispose();
        }
    }
}
