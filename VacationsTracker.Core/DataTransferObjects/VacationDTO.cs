using System;
using Newtonsoft.Json;
using VacationsTracker.Core.DataTransferObjects.Interfaces;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.DataTransferObjects
{
    public class VacationDTO : IDataTransferObject
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("start")]
        public DateTime Start { get; set; }

        [JsonProperty("end")]
        public DateTime End { get; set; }

        [JsonProperty("vacationType")]
        public VacationType VacationType { get; set; }

        [JsonProperty("vacationStatus")]
        public VacationStatus VacationStatus { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}
