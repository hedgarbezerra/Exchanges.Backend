using Hedgar.Exchanges.Backend.Domain.Models;
using Hedgar.Exchanges.Backend.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Hedgar.Exchanges.Backend.API.Models
{
    public class GlobalExceptionHandler: ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
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

            base.Handle(context);
        }
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
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
;
            return base.HandleAsync(context, cancellationToken);
        }

        private void SalvarExcecao(ErrorLog ex)
        {
            var service = new ErrorLogService();

            service.FazerLog(ex);
        }
    }
}