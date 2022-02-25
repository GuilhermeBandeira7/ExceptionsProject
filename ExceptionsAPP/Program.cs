using System;
using System.IO;
using ExceptionsAPP.Entities;
using ExceptionsAPP.Entities.Exceptions;

namespace ExcepionsAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Room number ");
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine("Check-in date (M/d/yyyy): ");
                DateTime checkin = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Check-out date (M/d/yyyy): ");
                DateTime checkout = DateTime.Parse(Console.ReadLine());




                Reservation reservation = new Reservation(number, checkin, checkout);
                Console.WriteLine(" Reservation " + reservation);

                Console.WriteLine();

                Console.WriteLine("Enter data to update the reservation: ");
                Console.WriteLine("Check-in date (M/d/yyyy): ");
                checkin = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Check-out date (M/d/yyyy): ");
                checkout = DateTime.Parse(Console.ReadLine());

                reservation.updateDates(checkin, checkout);
                Console.WriteLine("Reservation: " + reservation);
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error in reservation: "+ e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: "+ e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: "+ e.Message);
            }




        }
    }
}