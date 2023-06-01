using Microsoft.AspNetCore.Mvc;
using AdminSiteAPI.Models;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using System.Reflection;

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

        [HttpGet]
        [Route("api/getclientlist")]
        public List<Client> GetClientList()
        {
            List<Client> clients = new List<Client>();
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Clients", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                clients.Add(new Client
                {
                    ClientId = dr["ClientId"].ToString(),
                    ClientName = dr["ClientName"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    AnnualSalary = dr["AnnualSalary"].ToString(),
                    DateOfBirth = dr["DateOfBirth"].ToString(),
                });
            }
            return clients;
        }

        [HttpGet]
        [Route("api/getclientlist/{id}")]
        public Client GetCLientById(int id)
        {
            Client client = new Client();
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Clients where ClientId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                client.ClientId = dr["ClientId"].ToString();
                client.ClientName = dr["ClientName"].ToString();
                client.Gender = dr["Gender"].ToString();
                client.AnnualSalary = dr["AnnualSalary"].ToString();
                client.DateOfBirth = dr["DateOfBirth"].ToString();
            }
            return client;
        }

        [HttpPost]
        [Route("api/addclient")]
        public int AddClient([FromBody] Client client)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Clients" +
                "(ClientName, Gender, AnnualSalary, DateOfBirth)" +
                " values(@ClientName, @Gender, @AnnualSalary, @DateOfBirth)", con);
            cmd.Parameters.AddWithValue("@ClientName", client.ClientName);
            cmd.Parameters.AddWithValue("@Gender", client.Gender);
            cmd.Parameters.AddWithValue("@AnnualSalary", client.AnnualSalary);
            cmd.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
            int result = cmd.ExecuteNonQuery();

            return result;
        }

        [HttpDelete]
        [Route("api/deleteclient/{id}")]
        public int DeleteClient(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RASHMIS-LT\SQLEXPRESS;Initial Catalog=AdminSiteDB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Clients where ClientId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();

            return result;
        }
    }
}
