using SkuAppDomain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkuAppDomain.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IUserRepository repository;

        public AccountRepository(IUserRepository Repository)
        {
            this.repository = Repository;
        }

        //public List<LogComment> Comments
    }
}
