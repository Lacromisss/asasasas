
using Amazon.EC2.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace ConsoleApp60
{
    internal class Program
{
    static void Main(string[] args)
    {
        UsersData usersData1 = new UsersData();

        StadionData stadionData1 = new StadionData();

        ReservationData rez = new ReservationData();

        int input;
        bool chk = true;
        do
        {

            Console.WriteLine(" 1. stadion eleave et ");
            Console.WriteLine(" 2. stadionlari goster");
            Console.WriteLine(" 3. istifadeci elaave et");
            Console.WriteLine(" 4. istifadecileri goster");
            Console.WriteLine(" 5. rezervleri göstər");
            Console.WriteLine(" 6. rezerv  yarat");
            Console.WriteLine(" 7. verilmis id- stadionun rezervlerini goster goster");
            Console.WriteLine(" 8. Verilmiş id userin rezervlerini goster");
            Console.WriteLine(" 9. Verilmiş  rezervlerini sil");
            input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    stadionData1.InsertStadionn();
                    break;
                case 2:
                    stadionData1.SelectStadionss();
                    break;

                case 3:
                    usersData1.InsertUser();
                    break;
                case 4:
                    usersData1.SelectUser();
                    break;
                case 5:
                    rez.rezervSelect();
                    break;
                case 6:
                    rez.RezervInsert();
                    break;
                case 7:
                    Console.WriteLine("id");
                    int Id = int.Parse(Console.ReadLine());

                    List<Reservation> Rez2 = rez.GetStadions(Id);
                    foreach (var item in Rez2)
                    {

                        item.ShowReservation();

                    }
                    break;
                case 8:
                    Console.WriteLine("Id");

                    int Id2 = int.Parse(Console.ReadLine());

                    List<Reservation> Rez3 = rez.GetUserId(Id2);

                    foreach (var item in Rez3)
                    {

                        item.ShowReservationUser();

                    }


                    break;


            }




        } while (chk);
    }

}

}