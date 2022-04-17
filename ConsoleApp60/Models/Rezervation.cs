using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    internal class Reservation
    {
        public int Id { get; set; }

        public int StadionId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        List<Reservation> Reservations { get; set; }

        public void ShowReservationUser()
        {


            Console.WriteLine($"User {UserId},starDate{StartDate},endDate{EndDate}");


        }


        public void ShowReservation()
        {

            Console.WriteLine($"stadion Id{StadionId}, startDate{StartDate},endDate{EndDate}");


        }
    }
}