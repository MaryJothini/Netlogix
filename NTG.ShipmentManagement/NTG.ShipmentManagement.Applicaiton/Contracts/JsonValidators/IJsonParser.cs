using Newtonsoft.Json.Schema;
using System;
namespace NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators
{
    public interface IJsonParser
    {
        IList<ValidationError> ValidateJsonShema<T>(string playload) where T : class;

        T GetData<T>(string playload) where T : class;
    }
}

