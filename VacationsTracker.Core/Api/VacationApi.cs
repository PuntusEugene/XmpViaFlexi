using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api
{
    public class VacationApi : IVacationApi
    {
        private readonly IVacationApiContext _apiContext;
        private readonly IIdentityApi _identyApi;
        private string _url => SettingApi.SwaggerServiceUrl;

        public VacationApi(IVacationApiContext apiContext, IIdentityApi identyApi)
        {
            _apiContext = apiContext;
            _identyApi = identyApi;
        }

        public async Task<BaseResultOfVacationCollectionDTO> GetVacationCollectionAsync(CancellationToken cancellationToken)
        {
            var token = await _identyApi.AuthorizationAsync();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationCollectionDTO>(_url, Method.GET, token);
        }

        public async Task<BaseResultOfVacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto, CancellationToken cancellationToken)
        {
            var token = await _identyApi.AuthorizationAsync();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO, VacationDTO>(_url, Method.POST, token, vacationDto);
        }

        public async Task<BaseResultOfVacationDTO> GetVacationAsync(Guid id, CancellationToken cancellationToken)
        {
            var token = await _identyApi.AuthorizationAsync();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO>(_url, Method.GET, token, "{id}", new []{new KeyValuePair<string, object>("id", id) });
        }

        public async Task<BaseResultDTO> DeleteVacationAsync(Guid id, CancellationToken cancellationToken)
        {
            var token = await _identyApi.AuthorizationAsync();
            return await _apiContext.SendRequestAsync<BaseResultDTO>(_url, Method.DELETE, token, "{id}", new[] { new KeyValuePair<string, object>("id", id) });
        }
    }
}
