using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Api_URL.Model;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Api_URL.Repository;

namespace Api_URL.Model
{
    public class ModelBase : IRepository
    {
       
        public string GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public async Task<Response<string>> userAccount(AccountModel model)
        {
            #region for UserLogin
            var response = new Response<string>();
            var connection = GetConfiguration();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_CheckExistUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar, 50).Value = model.username;
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = model.Password;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    await Task.Run(() => cmd.ExecuteNonQuery());

                    var result = cmd.Parameters["@retval"].Value;

                    if (Convert.ToString(cmd.Parameters["@retval"].Value).ToString() == "1")
                    {
                        response.Result = cmd.Parameters["@retval"].Value.ToString();
                        response.Message = "Successful";
                    }
                    else
                    {
                        response.Result = cmd.Parameters["@retval"].Value.ToString();
                        response.isSuccess = false;
                        response.Message = "Unsuccessful";
                    }
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                response.isSuccess = false;
                response.Message = ee.Message;
            }
            return response;
            #endregion
        }
        public async Task<Response<string>> userAcceptAccount(acceptUserAccount accnt)
        {
            #region insertAccount
            var respnd = new Response<string>();
            var conn = GetConfiguration();
            try
            {
                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertUserDetails", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar, 50).Value = accnt.username;
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = accnt.password;
                    cmd.Parameters.Add("@fname", SqlDbType.NVarChar, 50).Value = accnt.firstname;
                    cmd.Parameters.Add("@lname", SqlDbType.NVarChar, 50).Value = accnt.lastname;
                    cmd.Parameters.Add("@cstatus", SqlDbType.NVarChar, 50).Value = accnt.CivilStatus;
                    cmd.Parameters.Add("@bdate", SqlDbType.Date).Value = accnt.bdate;
                    cmd.Parameters.Add("@religion", SqlDbType.NVarChar, 50).Value = accnt.religion;
                    cmd.Parameters.Add("@bplace", SqlDbType.NVarChar, 50).Value = accnt.bplace;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    await Task.Run(() => cmd.ExecuteNonQuery());

                    if (Convert.ToString(cmd.Parameters["@retval"].Value).ToString() == "200")
                    {
                        respnd.Result = cmd.Parameters["@retval"].Value.ToString();
                        respnd.Message = "Successful Inserted Data!";
                    }
                    else if(Convert.ToString(cmd.Parameters["@retval"].Value).ToString() == "100")
                    {
                        respnd.Result = cmd.Parameters["@retval"].Value.ToString();
                        respnd.Message = "Data Already Exist";
                    }
                    else
                    {
                        respnd.Result = cmd.Parameters["@retval"].Value.ToString();
                        respnd.Message = "Unsuccesful Inserted Data!";
                    }
                }
            }
            catch (Exception ee)
            {
                respnd.Message = ee.Message;
                respnd.isSuccess = false;
            }
            return respnd;
            #endregion
        }
    }
}
