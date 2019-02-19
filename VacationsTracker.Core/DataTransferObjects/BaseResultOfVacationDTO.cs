using Newtonsoft.Json;

namespace VacationsTracker.Core.DataTransferObjects
{
    public class BaseResultOfVacationDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public VacationDTO Vacation { get; set; }
    }
}
