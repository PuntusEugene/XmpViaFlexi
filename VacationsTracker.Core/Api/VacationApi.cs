using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using VacationsTracker.Core.Api.Interfaces;
using VacationsTracker.Core.Api.Parameters;
using VacationsTracker.Core.DataTransferObjects;

namespace VacationsTracker.Core.Api
{
    internal class VacationApi : IVacationApi
    {
        private readonly IVacationApiContext _apiContext;
        private readonly IIdentityApi _identyApi;
        private string _url => ApiSettings.SwaggerServiceUrl;

        public VacationApi(IVacationApiContext apiContext, IIdentityApi identyApi)
        {
            _apiContext = apiContext;
            _identyApi = identyApi;
        }

        public async Task<BaseResultOfVacationCollectionDTO> GetVacationCollectionAsync(CancellationToken cancellationToken)
        {
            var token = await _identyApi.GetAuthorizationTokenAsync();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationCollectionDTO>(_url, Method.GET, token, cancellationToken);
        }

        public async Task<BaseResultOfVacationDTO> CreateOrUpdateVacationAsync(VacationDTO vacationDto, CancellationToken cancellationToken)
        {
            var token = await _identyApi.GetAuthorizationTokenAsync();
            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO, VacationDTO>(new SharedContextParameters(_url, Method.POST, token), vacationDto, cancellationToken);
        }

        public async Task<BaseResultOfVacationDTO> GetVacationAsync(Guid id, CancellationToken cancellationToken)
        {
            var token = await _identyApi.GetAuthorizationTokenAsync();
            var parameters = new SharedContextParameters(_url, Method.GET, token)
                .AddUrlSegment("{id}", "id", id);

            return await _apiContext.SendRequestAsync<BaseResultOfVacationDTO>(parameters, cancellationToken);
        }

        public async Task<BaseResultDTO> DeleteVacationAsync(Guid id, CancellationToken cancellationToken)
        {
            var token = await _identyApi.GetAuthorizationTokenAsync();
            var parameters = new SharedContextParameters(_url, Method.DELETE, token)
                .AddUrlSegment("{id}", "id", id);

            return await _apiContext.SendRequestAsync<BaseResultDTO>(parameters, cancellationToken);
        }
    }
}
