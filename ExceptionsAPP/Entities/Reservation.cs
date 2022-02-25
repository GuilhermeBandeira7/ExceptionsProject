using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionsAPP.Entities.Exceptions;

namespace ExceptionsAPP.Entities
{
    public class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public Reservation()
        {
        }

        public Reservation(int roomNumber, DateTime checkin, DateTime checkout)
        {
            if (checkout <= checkin) // é usado este tratamento de exceção no construtor para não deixar que uma instância checkout seja feita com data anterior ao checkin
            {
                throw new DomainException("Check out date must be prior to check in date");
            }
            RoomNumber = roomNumber;
            Checkin = checkin;
            Checkout = checkout;
        }

        public int Duration()
        {
            TimeSpan duration = Checkout.Subtract(Checkin); //TimeSpan represents a duration. To get the diference between checkin and checkout we use subtract method
            return (int)duration.TotalDays; // TotalDays converts the duration into days. We need to use casting because totaldays is a double value

        }

        public void updateDates(DateTime checkin, DateTime checkout) // método que atualiza as datas de reserva
        {
            

            DateTime now = DateTime.Now; // essa variável now do tipo datetime é importante para ser usada como parâmetro e não deixar que uma reserva seja feita em uma data que ja passou
            if (checkin < now || checkout < now) // se essa condição retornar true, o throw lança uma instância da nossa DomainException
            {
                throw new DomainException("Reservation dates for upadate must be future dates"); //throw lança uma nova instância de DomainException recebendo uma string. 
            }
            if (checkout < checkin)
            {
                throw new DomainException("Check out date must be prior to check in date");
            }

            Checkin = checkin;
            Checkout = checkout;
            
        }

        public override string ToString()
        {
            return "Room "
                + RoomNumber
                + ", Check-in "
                + Checkin.ToString("dd/MM/yyyy")
                + ", Check-out "
                + Checkout.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " nights";

        }
    }
}
