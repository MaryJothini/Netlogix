using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using NTG.ShipmentManagement.Applicaiton.Contracts.JsonValidators;

namespace NTG.ShipmentManagement.Infrastructure
{
    public class JsonParser : IJsonParser
    {

        public IList<ValidationError> ValidateJsonShema<T>(string playload) where T: class
        {
            var jsonGenerator = new JSchemaGenerator();
            var jsonSchema = jsonGenerator.Generate(typeof(T));
            jsonSchema.AllowAdditionalProperties = false;
            if(jsonSchema.Properties.ContainsKey("RequestedPickupTime") )
            {
                jsonSchema.Properties["RequestedPickupTime"].Format = "";
            }
            IList<ValidationError> errorMessages;
            var obj = JObject.Parse(playload);
            obj.IsValid(jsonSchema, out errorMessages);
            return errorMessages;
        }

        public T GetData<T>(string playload) where T : class
        {
            return JsonConvert.DeserializeObject<T>(playload);
        }
    }
}

