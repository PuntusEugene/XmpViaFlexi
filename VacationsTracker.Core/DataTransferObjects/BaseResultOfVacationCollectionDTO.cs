using System.Collections.Generic;
using Newtonsoft.Json;
using VacationsTracker.Core.DataTransferObjects.Interfaces;

namespace VacationsTracker.Core.DataTransferObjects
{
    internal class BaseResultOfVacationCollectionDTO : IDataTransferObject
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public IEnumerable<VacationDTO> Collection { get; set; }
    }
}
