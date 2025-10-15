using CashFlow.Communication.Responses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is CashFlowException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var cashFlowException = context.Exception as CashFlowException;
            var errorResponse = new ResponseErrorJson(cashFlowException!.GetErrors());

            context.HttpContext.Response.StatusCode = cashFlowException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        // Erro na mensagem é aqui
        private void ThrowUnkowError(ExceptionContext context)
        {
            // // Loga a exception real (pode ser console ou ILogger)
            Console.WriteLine(context.Exception);

            var errorResponse = new ResponseErrorJson(ResourceErrorMessage.UNKNOW_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(errorResponse);
        }
    }
}
