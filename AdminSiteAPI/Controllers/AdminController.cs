using Microsoft.AspNetCore.Mvc;
using AdminSiteAPI.Models;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace AdminSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("api/getuserlist")]
        public List<User> GetUserList()
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

        [HttpGet]
        [Route("api/getuserlist/{id}")]
        public User GetUserById(int id)
        {
            User user = new User();
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                user.Id = dr["id"].ToString();
                user.CompanyID = dr["CompanyID"].ToString();
                user.CompanyName = dr["CompanyName"].ToString();
                user.Username = dr["Username"].ToString();
                user.UserType = dr["UserType"].ToString();
            }
            return user;
        }

        [HttpPost]
        [Route("api/adduser")]
        public int AddUser([FromBody] User user)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Users values(@id, @CompanyID, @CompanyName, @Username, @UserType)", con);
            cmd.Parameters.AddWithValue("@id", user.Id);
            cmd.Parameters.AddWithValue("@CompanyID", user.CompanyID);
            cmd.Parameters.AddWithValue("@CompanyName", user.CompanyName);
            cmd.Parameters.AddWithValue("@Username", user.Username);
            cmd.Parameters.AddWithValue("@UserType", user.UserType);
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        [HttpDelete]
        [Route("api/deleteuser/{id}")]
        public int DeleteUser(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Users where id=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}
