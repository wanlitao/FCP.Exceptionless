using Exceptionless;
using FCP.Util;
using System;
using System.Web.Http;

namespace FCP.Exceptionless.WebApi
{
    public static class HttpConfigurationExceptionlessExtensions
    {
        public static HttpConfiguration UseExceptionless(this HttpConfiguration configuration, string apiKey, string serverUrl = null)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (apiKey.isNullOrEmpty())
                throw new ArgumentNullException(nameof(apiKey));

            var exceptionlessClient = new ExceptionlessClient(config =>
            {
                config.ApiKey = apiKey;

                if (!serverUrl.isNullOrEmpty())
                    config.ServerUrl = serverUrl;
            });

            exceptionlessClient.RegisterWebApi(configuration);

            return configuration;
        }
    }
}
