using Exceptionless.Plugins.Default;
using Exceptionless.WebApi;
using NLog.Targets;
using System;

namespace FCP.Exceptionless.NLog.WebApi
{
    [Target("WebApiExceptionless")]
    public class WebApiExceptionlessTarget : FCPExceptionlessTarget
    {
        private const string webApiPluginTypeFullName = "Exceptionless.WebApi.ExceptionlessWebApiPlugin";

        protected override void InitializeTarget()
        {
            base.InitializeTarget();

            var webApiPluginType = GetExceptionlessWebApiPluginType();

            Client.Configuration.AddPlugin(webApiPluginType.FullName, webApiPluginType);
            Client.Configuration.AddPlugin<IgnoreUserAgentPlugin>();
        }

        private Type GetExceptionlessWebApiPluginType()
        {
            var exceptionlessWebApiAssembly = typeof(ExceptionlessHandleErrorAttribute).Assembly;

            return exceptionlessWebApiAssembly.GetType(webApiPluginTypeFullName);
        }
    }
}
