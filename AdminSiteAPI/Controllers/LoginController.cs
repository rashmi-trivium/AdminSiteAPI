using AdminSiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AdminSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("api/login")]
        public int Login([FromBody] LoginData data)
        {
            int response = 0;
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where UserName=@uname AND password=@pwd", con);
            cmd.Parameters.AddWithValue("@uname", data.UserName);
            cmd.Parameters.AddWithValue("@pwd", data.Password);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                response = 1;
            }
            return response;
        }
    }
}
