using Newtonsoft.Json;
using VacationsTracker.Core.DataTransferObjects.Interfaces;

namespace VacationsTracker.Core.DataTransferObjects
{
    public class BaseResultOfVacationDTO : IDataTransferObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public VacationDTO Vacation { get; set; }
    }
}
