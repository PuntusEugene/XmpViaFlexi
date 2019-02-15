﻿using System.Collections.Generic;
using Newtonsoft.Json;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.DataTransferObjects
{
    public class BaseResultOfVacationCollectionDTO
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public IEnumerable<VacationDTO> Collection { get; set; }
    }
}
