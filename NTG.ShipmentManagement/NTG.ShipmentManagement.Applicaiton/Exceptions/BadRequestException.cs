using System;

namespace NTG.ShipmentManagement.Applicaiton.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message)
        : base(message)
        {
            
        }
    }
}