using System;

namespace NTG.ShipmentManagement.Applicaiton.Exceptions
{
    public class NotFoundException: ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} not found")
        {
            
        }
    }
}