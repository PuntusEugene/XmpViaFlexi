using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlexiMvvm.Operations;
using VacationsTracker.Core.Domain;
using VacationsTracker.Core.Domain.Exceptions;

namespace VacationsTracker.Core.Infrastructure
{
    public class VacationErrorHandler : IErrorHandler
    {
        public Task HandleAsync(OperationContext context, OperationError<Exception> error, CancellationToken cancellationToken)
        {
            if (error.Handled)
            {
                return Task.CompletedTask;
            }

            switch (error.Exception)
            {
                case InternetConnectionException _:
                    Debug.WriteLine(error.Exception.Message);
                    break;

                case AuthenticationException _:
                    Debug.WriteLine(error.Exception.Message);
                    break;

                case WebException _:
                    Debug.WriteLine(error.Exception.Message);
                    break;

                case Exception _:
                    Debug.WriteLine(error.Exception.Message);
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
