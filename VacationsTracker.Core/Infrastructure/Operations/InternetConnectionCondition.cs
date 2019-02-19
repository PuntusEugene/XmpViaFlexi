using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Application.Connectivity;
using VacationsTracker.Core.Domain.Exceptions;
using VacationsTracker.Core.Resourses;

namespace VacationsTracker.Core.Infrastructure.Operations
{
    public class InternetConnectionCondition : OperationConditionBase
    {
        public override Task<bool> CheckAsync(OperationContext context, CancellationToken cancellationToken)
        {
            var connectivityService = context.DependencyProvider.NotNull().Get<IConnectivityService>();
           
            if (connectivityService.IsConnected)
            {
                return Task.FromResult(true);
            }
            
            throw new InternetConnectionException(Strings.NoInternetConnection);
        }
    }
}
