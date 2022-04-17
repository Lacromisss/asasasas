using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace Data
{
    public class StadionData
    {

        public void SelectStadionss()
        {
            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();
                string query = $"select * from Stadions";

                var cmd = new SqlCommand(query, con);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Console.WriteLine($"Id{dr.GetInt32(0)},name{dr.GetString(1)},price{dr.GetDecimal(2)},capacity{dr.GetInt32(3)}");

                }

            }

        }
        static List<Stadion> GetAllStadion()
        {



            List<Stadion> Stadion1 = new List<Stadion>();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();

                string query = "select * from Stadions";

                var cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadion Stadion2 = new Stadion
                        {
                            Id = dr.GetInt32(0),

                            Name = dr.GetString(1),

                            HourPrice = dr.GetDecimal(2),

                            Capacity = dr.GetInt32(3)
                        };

                        Stadion1.Add(Stadion2);

                    }
                }


                return Stadion1;
            }
        }
        public void InsertStadionn()
        {
            Console.WriteLine("name");
            string name = Console.ReadLine();

            Console.WriteLine("hourPrice");
            string hourPrice = Console.ReadLine();

            Console.WriteLine("Capacity");
            string capacity = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();
                string query = $"insert into Stadions(Name,HourPrice,Capacity) values('{name}',{hourPrice},{capacity})";

                var cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();
            }
        }




    }
}