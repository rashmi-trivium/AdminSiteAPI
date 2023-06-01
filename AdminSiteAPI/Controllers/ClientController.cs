using AdminSiteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AdminSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : Controller
    {
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
