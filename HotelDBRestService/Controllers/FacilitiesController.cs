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
    public class FacilitiesController : ApiController
    {

        const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = HotelDBSebastian; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET api/values
        public List<Facility> Get()
        {
            List<Facility> facilities = new List<Facility>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = "select * from FacilityItem";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Facility f = new Facility()
                    {
                        FacilityId = (int)reader["Facility_Id"],
                        FacilityName = (string)reader["Facility_Name"]
                    };

                    facilities.Add(f);
                }

                command.Connection.Close();
            }

            return facilities;

        }

        // GET api/values/5
        public Facility Get(int id)
        {
            Facility facility = new Facility();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"select * from FacilityItem WHERE Facility_Id = {id}";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    facility.FacilityId = (int)reader["Facility_Id"];
                    facility.FacilityName = (string)reader["Facility_Name"];
                }

                command.Connection.Close();
            }

            return facility;
        }

        // POST api/values
        public bool Post([FromBody]Facility value)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"insert into FacilityItem VALUES('{value.FacilityName}')";

                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }

            return (rowAffected == 1);
        }

        // PUT api/values/5
        public bool Put(int id, [FromBody]Facility value)
        {

            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $"UPDATE FacilityItem SET Facility_Name='{value.FacilityName}' WHERE Facility_Id={id}";

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
                string queryString = $"DELETE FROM FacilityItem WHERE Facility_Id={id}";
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Connection.Open();
                rowAffected = command.ExecuteNonQuery();
                command.Connection.Close();
            }

            return rowAffected == 1;
            
        }
    }
}
