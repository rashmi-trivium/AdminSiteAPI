using Microsoft.AspNetCore.Mvc;
using AdminSiteAPI.Models;
using System.Data.SqlClient;

namespace AdminSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        public List<User> Index()
        {
            List<User> users = new List<User>();
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                users.Add(new User {
                    Id = dr["id"].ToString(),
                    CompanyID = dr["CompanyID"].ToString(),
                    CompanyName = dr["CompanyName"].ToString(),
                    Username = dr["Username"].ToString(),
                    UserType = dr["UserType"].ToString(),
                });
            }
            return users;
        }
    }
}
