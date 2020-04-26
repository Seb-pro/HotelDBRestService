using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using HotelDBSebastian;

namespace DBConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            const string serverUrl = "http://localhost:55991/";

            HttpClientHandler handler = new HttpClientHandler();

            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/facilities").Result;

                    #region Facilities Test
                    //Console.WriteLine("Alle faciliteter\n");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    List<Facility> facilities = response.Content.ReadAsAsync<List<Facility>>().Result;

                    //    foreach (Facility f in facilities)
                    //    {
                    //        Console.WriteLine(f);
                    //    }
                    //}


                    //Console.WriteLine("\nEt specifikt facilitet\n");

                    //response = client.GetAsync("api/facilities/3").Result;
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    Facility f2 = response.Content.ReadAsAsync<Facility>().Result;

                    //    Console.WriteLine(f2);
                    //}

                    //Console.WriteLine("\nIndsæt et facilitet\n");

                    //Facility facilityIns = new Facility() { FacilityName = "New Facility" };

                    //response = client.PostAsJsonAsync("api/facilities", facilityIns).Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool succes = response.Content.ReadAsAsync<bool>().Result;

                    //    Console.WriteLine(succes);
                    //}

                    //Console.WriteLine("\nUpdater et facilitet\n");

                    //Facility updateFacility = new Facility { FacilityName = "Updatede" };
                    //response = client.PutAsJsonAsync("api/facilities/5", updateFacility).Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool upSucces = response.Content.ReadAsAsync<bool>().Result;

                    //    Console.WriteLine(upSucces);

                    //}

                    //Console.WriteLine("\nSlette et facilitet\n");

                    //response = client.DeleteAsync("api/facilities/6").Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool delSucces = response.Content.ReadAsAsync<bool>().Result;
                    //    Console.WriteLine(delSucces);
                    //}

                    //response = client.GetAsync("api/facilities").Result;

                    //Console.WriteLine("Alle faciliteter igen\n");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    List<Facility> facilities = response.Content.ReadAsAsync<List<Facility>>().Result;

                    //    foreach (Facility f3 in facilities)
                    //    {
                    //        Console.WriteLine(f3);
                    //    }
                    //}
                    #endregion

                    #region Hotels Test

                    //response = client.GetAsync("api/hotels").Result;

                    //Console.WriteLine("Alle hoteller\n");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    List<Hotel> hotels = response.Content.ReadAsAsync<List<Hotel>>().Result;

                    //    foreach (Hotel h in hotels)
                    //    {
                    //        Console.WriteLine(h);
                    //    }
                    //}


                    //Console.WriteLine("\nEt specifikt Hotel\n");

                    //response = client.GetAsync("api/hotels/3").Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    Hotel h2 = response.Content.ReadAsAsync<Hotel>().Result;

                    //    Console.WriteLine(h2);
                    //}

                    //Console.WriteLine("\nIndsæt et nyt Hotel\n");

                    //Hotel hotelins = new Hotel() { HotelName = "New Hotel", HotelAddress = "New Hotel Street" };

                    //response = client.PostAsJsonAsync("api/hotels", hotelins).Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool succes = response.Content.ReadAsAsync<bool>().Result;

                    //    Console.WriteLine(succes);
                    //}

                    //Console.WriteLine("\nUpdater et Hotel\n");

                    //Hotel updateHotel = new Hotel { HotelName = "Hotel Updatede", HotelAddress = "Updatede Road 1" };
                    //response = client.PutAsJsonAsync("api/hotels/8", updateHotel).Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool upSucces = response.Content.ReadAsAsync<bool>().Result;

                    //    Console.WriteLine(upSucces);

                    //}

                    //Console.WriteLine("\nSlette et Hotel\n");

                    //response = client.DeleteAsync("api/hotels/9").Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    bool delSucces = response.Content.ReadAsAsync<bool>().Result;
                    //    Console.WriteLine(delSucces);
                    //}

                    //response = client.GetAsync("api/hotels").Result;

                    //Console.WriteLine("Alle hoteller igen\n");

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    List<Hotel> hotels = response.Content.ReadAsAsync<List<Hotel>>().Result;

                    //    foreach (Hotel h in hotels)
                    //    {
                    //        Console.WriteLine(h);
                    //    }
                    //} 
                    #endregion


                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            Console.ReadKey();


        }

    }
}
