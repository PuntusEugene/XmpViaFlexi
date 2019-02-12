using System.Collections.Generic;
using VacationsTracker.Core.Domain;

namespace VacationsTracker.Core.DataTransfer
{
    public class BaseResultOfVacationRequest
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<VacationRequest> Result { get; set; }
    }
}
