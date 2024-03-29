﻿using System;
using System.Collections.Generic;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace FCP.Exceptionless.WebApi
{
    public static class HttpActionExecutedContextTraceExtensions
    {
        public static Action<TraceRecord> BuildTraceRecordAction_AddExceptionlessRequestInfo(this HttpActionExecutedContext actionExecutedContext)
        {
            return (traceRecord) =>
            {
                //add Exceptionless RequestInfo Arguments
                traceRecord.Properties.Add("ContextData",
                    new Dictionary<string, object> { { "HttpActionContext", actionExecutedContext.ActionContext } });
            };
        }
    }
}
