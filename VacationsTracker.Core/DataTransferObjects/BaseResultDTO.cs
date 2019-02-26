using Newtonsoft.Json;
using VacationsTracker.Core.DataTransferObjects.Interfaces;

namespace VacationsTracker.Core.DataTransferObjects
{
    internal class BaseResultDTO : IDataTransferObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
