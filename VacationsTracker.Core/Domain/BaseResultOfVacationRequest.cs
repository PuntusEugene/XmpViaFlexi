using System;
using System.Collections.Generic;
using System.Text;

namespace VacationsTracker.Core.Domain
{
    public class BaseResultOfVacationRequest
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<VacationRequest> Result { get; set; }
    }
}
