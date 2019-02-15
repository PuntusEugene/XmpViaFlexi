using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;
using VacationsTracker.Core.Infrastructure.Storage;

namespace VacationsTracker.Core.Api
{
    public class VacationApi : IVacationApi
    {
        private readonly IVacationApiContext _apiContext;
        private readonly IIdentityApi _identyApi;
        private readonly string _url;

        public VacationApi(IVacationApiContext apiContext, IIdentityApi identyApi)
        {
            //_url = "http://localhost:5000/api/vts/workflow";
            //_url = "http://10.6.107.38:5000/api/vts/workflow";
            _url = "https://vts-v2.azurewebsites.net/api/vts/workflow";
            _apiContext = apiContext;
            _identyApi = identyApi;
        }

        public async Task<BaseResultOfVacationCollectionDTO> GetVacationCollectionAsync()
        {
            await CheckAuthorization();
            var asd = await _apiContext.SendRequestAsync<BaseResultOfVacationCollectionDTO>(_url, Method.GET);
            return asd;
        }

        public async Task<BaseResultOfVacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto)
        {
            await CheckAuthorization();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO, VacationDTO>(_url, Method.POST, vacationDto);
        }

        public async Task<BaseResultOfVacationDTO> GetVacationAsync(Guid id)
        {
            await CheckAuthorization();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO>(_url, Method.GET, "{id}", new []{new KeyValuePair<string, object>("id", id) });
        }

        public async Task<BaseResultDTO> DeleteVacationAsync(Guid id)
        {
            await CheckAuthorization();
            return await _apiContext.SendRequestAsync<BaseResultDTO>(_url, Method.DELETE, "{id}", new[] { new KeyValuePair<string, object>("id", id) });
        }

        private async Task CheckAuthorization()
        {
            if (!await _identyApi.AuthorizationAsync())
            {
                throw new AuthenticationException();
            }
        }
    }
}
