using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelDBSebastian;


namespace HotelDBRestService.Controllers
{
    public class HotelsController : ApiController
    {

        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = HotelDBSebastian; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // GET api/values
        public List<Hotel> Get()
        {
            List<Hotel> hotels = new List<Hotel>();
           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "select * from Hotel";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Hotel h = new Hotel()
                    {
                        HotelId = (int)reader["Hotel_Id"],
                        HotelName = (string)reader["Hotel_Name"],
                        HotelAddress = (string)reader["Hotel_Address"]
                    };

                    hotels.Add(h);
                }

                command.Connection.Close();
               
            }
                return hotels;
        }


        // GET api/values/5
        public Hotel Get(int id)
        {
            Hotel hotels = new Hotel();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"select * from Hotel WHERE Hotel_Id = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    hotels.HotelId = (int)reader["Hotel_Id"];
                    hotels.HotelName = (string)reader["Hotel_Name"];
                    hotels.HotelAddress = (string)reader["Hotel_Address"];
                }

                command.Connection.Close();
            }

            return hotels;

        }

        // POST api/values
        public bool Post([FromBody]Hotel value)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"insert into Hotel VALUES('{value.HotelName}', '{value.HotelAddress}')";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }

            return (rowAffected == 1);
        }

        // PUT api/values/5
        public bool Put(int id, [FromBody]Hotel value)
        {
           
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"UPDATE Hotel SET Hotel_Name='{value.HotelName}', Hotel_Address = '{value.HotelAddress}' WHERE Hotel_Id={id}";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }
            return rowAffected == 1;
        }

        // DELETE api/values/5
        public bool Delete(int id)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"DELETE FROM Hotel WHERE Hotel_Id={id}";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }

            return rowAffected == 1;
        }
    }
}
