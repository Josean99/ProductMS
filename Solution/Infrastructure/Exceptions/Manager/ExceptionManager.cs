using Infrastructure.Common;
using Infrastructure.Exceptions.Entities;
using Infrastructure.Exceptions.Policies.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions.Manager
{
    public class ExceptionManager : IExceptionManager
    {
        private readonly ILogger<ExceptionManager> _logProvider;
        private readonly IExceptionPolicy _exceptionPolicy;

        public ExceptionManager(ILogger<ExceptionManager> logProvider, IExceptionPolicy exceptionPolicy)
        {
            _logProvider = logProvider;
            _exceptionPolicy = exceptionPolicy;
        }
        public async Task<Exception> HandleException(HttpContext context, Exception ex)
        {
            var handleException = _exceptionPolicy.ApplyPolicy(ex);

            var message = $"{Constants.EXCEPTION_TITLE} \r\n {ex.Message} \r\n {handleException.Message}";
            _logProvider.LogError(handleException, message);

            HandleExceptionData(ex, handleException);
            var response = context.Response;

            var errorResponse = new ExceptionResponse
            {
                Success = false,
            };

            switch (handleException)
            {
                case ApplicationException exception:
                    if (exception.Message.Contains(Constants.INVALID_TOKEN))
                    {
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorResponse.Message = exception.Message;
                        break;
                    }
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = exception.Message;
                    break;

                case KeyNotFoundException exception:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse.Message = exception.Message;
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = handleException.Message;
                    break;
            }

            return handleException;
        }

        private void HandleExceptionData(Exception baseException, Exception handledException)
        {
            if (baseException.Data.Count > 0 )
            {
                foreach (DictionaryEntry dictionaryEntry in baseException.Data)
                {
                    handledException.Data.Add(dictionaryEntry.Key, dictionaryEntry.Value);
                }
            }
        }
    }
}
