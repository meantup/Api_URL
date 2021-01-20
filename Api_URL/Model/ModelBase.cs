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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Globalization;

namespace Api_URL.Model
{
    public class ModelBase : IRepository
    {
        public string GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }
        public string GetConfiguration1()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("DefCon").Value;
        }
        public async Task<Response<List<acceptUserAccount>>> userAccount(AccountModel model)
        {
            #region for UserLogin
            var responses = new Response<List<acceptUserAccount>>();
            var connection = GetConfiguration();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("usp_SelectUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar, 50).Value = model.username;
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = model.Password;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    await Task.Run(() => adapter.Fill(dt));
                    var result = cmd.Parameters["@retval"].Value;
                    List<acceptUserAccount> user = new List<acceptUserAccount>();
                    var test = dt.AsEnumerable().Select(x => new acceptUserAccount
                    {
                        CivilStatus = x["CivilStatus"].ToString(),
                        bdate = DateTime.Parse(x["Birthdate"].ToString()),
                        bplace = x["Birthplace"].ToString(),
                        firstname = x["FirstName"].ToString(),
                        lastname = x["LastName"].ToString(),
                        religion = x["Religion"].ToString()
                    }).ToList();

                    if (dt.Rows.Count > 0)
                    {
                        if (int.Parse(result.ToString()) == 200)
                        {
                            responses.Result = test;
                            responses.response = int.Parse(result.ToString());
                        }
                        else
                        {
                            responses.response = int.Parse(result.ToString());
                        }
                    }
                    else
                    {
                        responses.response = 100;
                    }
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                responses.isSuccess = false;
                responses.Message = ee.Message;
                responses.response = 400;
            }
            return responses;
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
                    else if (Convert.ToString(cmd.Parameters["@retval"].Value).ToString() == "404")
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
        public async Task<Response<string>> GetAllAccount(acceptUserAccount accnt)
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
                    else if (Convert.ToString(cmd.Parameters["@retval"].Value).ToString() == "404")
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
        public async Task<List<ItemOrderDetails>> getDATE(DateiNQUIRY tdt)
        {
            #region insertAccount
            List<ItemOrderDetails> response = new List<ItemOrderDetails>();
            var conn = GetConfiguration1();
            try
            {
                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open(); 
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand("usp_InquiryDate", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@from", SqlDbType.DateTime).Value = DateTime.Parse(tdt.startDate);
                    cmd.Parameters.Add("@to", SqlDbType.DateTime).Value = DateTime.Parse(tdt.endDate);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    await Task.Run(() => ad.Fill(dt));
                    var set = dt.AsEnumerable().Select(x => new ItemOrderDetails
                    {
                        iname = x["IName"].ToString(),
                        idesc = x["IDesc"].ToString(),
                        icode = x["ICode"].ToString(),
                        tdt = DateTime.Parse(x["TDT"].ToString()),
                        amount = Decimal.Parse(x["amount"].ToString()),
                        quantity = int.Parse(x["quantity"].ToString())
                    }).ToList();
                    if (dt.Rows.Count > 0)
                    {
                        response = set;
                    }
                }
            }
            catch (Exception ee)
            {
               
            }
            return response;
            #endregion
        }
        public async Task<response<string>> postItem(ItemOrderDetails itm)
        {
            var respnsecode = new response<string>();
            var conn = GetConfiguration1();
            try
            {
                using (SqlConnection sql = new SqlConnection(conn))
                {
                    sql.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertItemOrder", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@iname", SqlDbType.NVarChar, 50).Value = itm.iname;
                    cmd.Parameters.Add("@idesc", SqlDbType.NVarChar, 50).Value = itm.idesc;
                    cmd.Parameters.Add("@icode", SqlDbType.NVarChar, 50).Value = itm.icode;
                    cmd.Parameters.Add("@amount", SqlDbType.Decimal, 18).Value = itm.amount;
                    cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = itm.quantity;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    await Task.Run(() => cmd.ExecuteNonQuery());
                    int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value);
                    if(retval == 100)
                    {
                        respnsecode.message = "Successful Inserted";
                        respnsecode.retval = Convert.ToString(retval);
                    }
                    else if(retval == 500)
                    {
                        respnsecode.retval = Convert.ToString(retval);
                        respnsecode.message = "UnSuccessful Inserted";
                    }
                    else
                    {
                        respnsecode.retval = Convert.ToString(404);
                        respnsecode.message = "Internal Server Error";
                    }
                }
            }
            catch (Exception ee)
            {
                respnsecode.retval = Convert.ToString(400);
                respnsecode.message = "Bad Request";
            }
            return respnsecode;
        }
    }
}
