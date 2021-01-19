using Api_URL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_URL.Repository
{
    public interface IRepository
    {
        Task<Response<List<acceptUserAccount>>> userAccount(AccountModel model);
        Task<Response<string>> userAcceptAccount(acceptUserAccount acct);
        Task<List<InquiryDetails>> getDATE(string startDate,string endDate);
        Task<response<string>> postItem(ItemOrderDetails itm);
    }
}
 