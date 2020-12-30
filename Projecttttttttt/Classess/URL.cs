using Newtonsoft.Json;
using Projecttttttttt.Models;
using Projecttttttttt.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projecttttttttt.Classess
{
    public class URL : IActionRepository
    {

        public async Task<response<string>> LoginCredentials(AccountModel model)
        {
            var res = new response<string>();
            try
            {
                string url = "http://localhost:55497/userAccount";
                string jsonReturn = JsonConvert.SerializeObject(model);
                var response = string.Empty;
                using (var client = new WebClient())
                {
                    client.Headers.Add("content-type", "application/json");
                    response = await Task.Run(() => Encoding.ASCII.GetString(client.UploadData(url, "POST", Encoding.UTF8.GetBytes(jsonReturn))));
                }
                res.Result = response;
            }
            catch (Exception ee)
            {
                res.Result = "500";
            }
            return res;
        }
        public async Task<response<string>> InsertData(AccountModel model)
        {
            var res = new response<string>();
            try
            {
                string url = "http://localhost:55497/userAccount";
                string jsonReturn = JsonConvert.SerializeObject(model);
                var response = string.Empty;
                using (var client = new WebClient())
                {
                    client.Headers.Add("content-type", "application/json");
                    response = await Task.Run(() => Encoding.ASCII.GetString(client.UploadData(url, "POST", Encoding.UTF8.GetBytes(jsonReturn))));
                }
                res.Result = response;
            }
            catch (Exception ee)
            {
                res.Result = "500";
            }
            return res;
        }
    }
}
