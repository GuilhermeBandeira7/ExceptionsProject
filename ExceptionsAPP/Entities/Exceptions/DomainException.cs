using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsAPP.Entities.Exceptions
{
    internal class DomainException : ApplicationException //DomainExecepion é uma exceção personalizada do nosso domain(programa) 
    {
        public DomainException(string messege) : base(messege) // construtor que recebe uma string 
        {

        }
    }
}
