using Hedgar.Exchanges.Backend.Domain.Models;
using Hedgar.Exchanges.Backend.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Hedgar.Exchanges.Backend.API.Models
{
    public sealed class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var runtimeError = context.Exception;

            var errorLog = new ErrorLog
            {
                DtHrErro = DateTime.Now,
                ExceptionMessage = runtimeError.Message,
                ExceptionSource = runtimeError.StackTrace,
                ExceptionType = runtimeError.GetType().FullName,
                ExceptionUrl = context.Request.RequestUri.OriginalString
            };

            SalvarExcecao(errorLog);
            
            base.OnException(context);
        }

        private void SalvarExcecao(ErrorLog ex)
        {
            var service = new ErrorLogService();

            service.FazerLog(ex);
        }
    }
}