﻿using Hedgar.Exchanges.Backend.Domain.Models;
using Hedgar.Exchanges.Backend.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Hedgar.Exchanges.Backend.API.Models
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
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

        private static void SalvarExcecao(ErrorLog ex)
        {
            var service = new ErrorLogService();

            service.FazerLog(ex);
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var runtimeError = actionExecutedContext.Exception;

            var errorLog = new ErrorLog
            {
                DtHrErro = DateTime.Now,
                ExceptionMessage = runtimeError.Message,
                ExceptionSource = runtimeError.StackTrace,
                ExceptionType = runtimeError.GetType().FullName,
                ExceptionUrl = actionExecutedContext.Request.RequestUri.OriginalString
            };

            SalvarExcecao(errorLog);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }

    }
}