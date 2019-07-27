using Convey;
using Convey.CQRS.Queries;
using Convey.Discovery.Consul;
using Convey.Docs.Swagger;
using Convey.HTTP;
using Convey.LoadBalancing.Fabio;
using Convey.WebApi;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPost.Services.Routing.Services;

namespace NPost.Services.Routing
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<IRoutingService, RoutingService>();
            
            return builder
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddConsul()
                .AddFabio()
                .AddSwaggerDocs()
                .AddWebApiSwaggerDocs();
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseInitializers()
                .UseConsul()
                .UseSwagger()
                .UseSwaggerUI()
                .UseSwaggerDocs();

            return app;
        }
    }
}