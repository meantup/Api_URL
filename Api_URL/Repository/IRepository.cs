using Api_URL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Repository
{
    public interface IRepository
    {
        Task<Response<string>> userAccount(AccountModel account);
        Task<Response<string>> userAcceptAccount(acceptUserAccount acct);
    }
}
 