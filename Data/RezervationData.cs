using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    internal class ReservationData
    {


        public void rezervSelect()
        {
            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();

                string query = $"select * from Reservations";

                var cmd = new SqlCommand(query, con);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {


                    Console.WriteLine($"Id{dr.GetInt32(0)},startDate{dr.GetDateTime(1)},endDate{dr.GetDateTime(2)}, stadionId{dr.GetInt32(3)}, userId{dr.GetInt32(4)}");


                }
            }

        }




        static List<Reservation> GetAllReservation()
        {
            List<Reservation> Rezervation1 = new List<Reservation>();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();

                string query = "select * from Reservations";

                var cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())

                {

                    while (dr.Read())

                    {



                        Reservation Reservation2 = new Reservation
                        {

                            Id = dr.GetInt32(0),
                            StartDate = dr.GetDateTime(1),

                            EndDate = dr.GetDateTime(2),
                            StadionId = dr.GetInt32(3),

                            UserId = dr.GetInt32(4),
                        };

                        Rezervation1.Add(Reservation2);
                    }


                    return Rezervation1;



                }
            }
        }
        public void RezervInsert()
        {
            Console.WriteLine("ilk tarix");
            string startdate = Console.ReadLine();


            Console.WriteLine("son tarix");
            string enddate = Console.ReadLine();


            Console.WriteLine("stadionId");
            string stadionid = Console.ReadLine();

            Console.WriteLine("userId");
            string userId = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {

                con.Open();


                string query = $"insert into Reservations(StartDate,EndDate,StadionId,UserId) values({startdate},{enddate},{userId},{stadionid})";

                var cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();

            }


        }


        public List<Reservation> GetStadions(int Id)
        {



            List<Reservation> Rezervation1 = new List<Reservation>();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();
                string query = "select * from Reservations where StadionId=@StadionId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("StadionId", Id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Reservation Reservation2 = new Reservation();
                                Reservation2.Id = dr.GetInt32(0);

                                Reservation2.StartDate = dr.GetDateTime(1);
                                Reservation2.EndDate = dr.GetDateTime(2);

                                Reservation2.StadionId = dr.GetInt32(3);
                                Reservation2.UserId = dr.GetInt32(4);

                                Rezervation1.Add(Reservation2);

                            }

                        }




                    }
                }
            }
            return Rezervation1;



        }
        public List<Reservation> GetUserId(int Id)
        {
            List<Reservation> Reservations1 = new List<Reservation>();
            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {

                con.Open();



                string query = "select * from Reservations where UserId=@UserId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("UserId", Id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Reservation Reservation2 = new Reservation();
                                Reservation2.Id = dr.GetInt32(0);


                                Reservation2.StartDate = dr.GetDateTime(1);
                                Reservation2.EndDate = dr.GetDateTime(2);

                                Reservation2.StadionId = dr.GetInt32(3);
                                Reservation2.UserId = dr.GetInt32(4);

                                Reservations1.Add(Reservation2);
                            }
                        }


                    }


                }

            }



            return Reservations1;

        }
    }
}