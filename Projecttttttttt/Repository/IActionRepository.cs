using Projecttttttttt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecttttttttt.Repository
{
    public interface IActionRepository
    {
        Task<response<string>> InsertData(AccountModel model);
        Task<response<string>> LoginCredentials(AccountModel model);
    }
}
