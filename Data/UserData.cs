using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Models;

namespace Data
{
    public class UsersData
    {
        public void InsertUser()
        {

            Console.WriteLine("FullName");
            string fullname = Console.ReadLine();

            Console.WriteLine("EMAIL:");
            string email = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {


                con.Open();
                string query = $"insert into Users(FullName,Email) values('{fullname}',{email})";

                var cmd = new SqlCommand(query, con);

                cmd.ExecuteNonQuery();


            }
        }
        public void SelectUser()
        {
            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {

                con.Open();

                string query = $"select * from Users";
                var cmd = new SqlCommand(query, con);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Console.WriteLine($"Id{dr.GetInt32(0)},FullName{dr.GetString(1)},Email{dr.GetString(2)}");
                }



            }


        }

        static List<User> GetAllUser()
        {
            List<User> AnaUser = new List<User>();

            using (SqlConnection con = new SqlConnection(SqlServer.ConnectionString))
            {
                con.Open();
                string query = "select * from Users";

                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User userr = new User
                        {
                            Id = dr.GetInt32(0),
                            FullName = dr.GetString(1),
                            Email = dr.GetString(2),

                        };


                        AnaUser.Add(userr);



                    }

                    return AnaUser;
                }
            }


        }

    }
}