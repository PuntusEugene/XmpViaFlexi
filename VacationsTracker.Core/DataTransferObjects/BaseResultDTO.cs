using Newtonsoft.Json;

namespace VacationsTracker.Core.DataTransferObjects
{
    public class BaseResultDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
