using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Infrastructure.Storage;
using VacationsTracker.Core.SwaggerApi.Interfaces;

namespace VacationsTracker.Core.SwaggerApi
{
    public class VacationApi : IVacationApi
    {
        private readonly IVacationContext _context;
        private readonly IVacationSecureStorage _vacationSecureStorage;
        private readonly string _url;

        public VacationApi(IVacationContext context, IVacationSecureStorage vacationSecureStorage)
        {
            _url = "http://localhost:5000/api/vts/workflow";
            _context = context;
            _vacationSecureStorage = vacationSecureStorage;
        }

        public async Task<BaseResultOfVacationDTO> GetVacationCollectionAsync()
        {
            return await _context.SendRequestAsync<BaseResultOfVacationDTO>(_url, Method.GET);
        }

        public async Task<VacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto)
        {
            return await _context.SendRequestAsync<VacationDTO, VacationDTO>(_url, Method.POST, vacationDto);
        }

        public async Task<VacationDTO> GetVacationAsync(Guid id)
        {
            return await _context.SendRequestAsync<VacationDTO>(_url, Method.GET);
        }

        public async Task<BaseResultDTO> DeleteVacationAsync(Guid id)
        {
            return await _context.SendRequestAsync<BaseResultDTO>(_url, Method.DELETE);
        }
    }
}
