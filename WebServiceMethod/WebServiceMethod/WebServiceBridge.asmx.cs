using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using WebServiceMethod.Model;
using System.Web.Mvc;

namespace WebServiceMethod.WebServiceMethod
{
    /// <summary>
    /// Summary description for WebServiceBridge
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceBridge : System.Web.Services.WebService
    {
        string con = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        [WebMethod]
        [HttpPost]
        public string CheckUser(string username,string password) 
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("usp_CheckExistUser",connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = password;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = username;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    string retvalue = Convert.ToString(cmd.Parameters["@retval"].Value.ToString());
                    if(retvalue == "1")
                    {
                        result = retvalue;
                    }
                    else
                    {
                        result = retvalue;
                    }
                }
            }
            catch (Exception ee)
            {
                result = ee.Message;
            }
            return result;
        }
        [WebMethod]
        [HttpPost]
        public string AddUserDetails(User_Details user)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertUserDetails", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar, 50).Value = user.username;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar, 50).Value = user.password;
                    cmd.Parameters.Add("@fname", SqlDbType.VarChar, 50).Value = user.fname;
                    cmd.Parameters.Add("@lname", SqlDbType.VarChar, 50).Value = user.lname;
                    cmd.Parameters.Add("@cstatus", SqlDbType.VarChar, 50).Value = user.civilstatus;
                    cmd.Parameters.Add("@bdate", SqlDbType.VarChar, 50).Value = user.bdate;
                    cmd.Parameters.Add("@religion", SqlDbType.VarChar, 50).Value = user.religion;
                    cmd.Parameters.Add("@bplace", SqlDbType.VarChar, 50).Value = user.bplace;
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();

                    string retvalue = Convert.ToString(cmd.Parameters["@retval"].Value.ToString());
                    if (retvalue == "200")
                    {
                        result = retvalue;
                    }
                    else
                    {
                        result = retvalue;
                    }
                }
            }
            catch (Exception ee)
            {
                result = ee.Message;
            }
            return result;
        }
    }
}
