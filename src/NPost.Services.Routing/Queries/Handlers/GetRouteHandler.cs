using System;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Microsoft.Extensions.Logging;
using NPost.Services.Routing.DTO;
using NPost.Services.Routing.Services;

namespace NPost.Services.Routing.Queries.Handlers
{
    public class GetRouteHandler : IQueryHandler<GetRoute, RouteDto>
    {
        private readonly IRoutingService _routingService;
        private readonly ILogger<GetRouteHandler> _logger;

        // Inject the different routing strategies.
        public GetRouteHandler(IRoutingService routingService, ILogger<GetRouteHandler> logger)
        {
            _routingService = routingService;
            _logger = logger;
        }

        public async Task<RouteDto> HandleAsync(GetRoute query)
        {
            if (query.Addresses is null || !query.Addresses.Any())
            {
                throw new Exception("Route cannot be calculated without the addresses.");
            }

            var addressesInfo = string.Join(", ", query.Addresses);
            _logger.LogInformation($"Calculating the optimal route for addresses: {addressesInfo}");
            // Let's assume it's a time consuming calculation.
            await Task.Delay(3000);
            var route = _routingService.Calculate(query.Addresses);
            _logger.LogInformation($"The optimal route for addresses: {addressesInfo} was calculated," +
                                   $"total distance: {route.TotalDistance} km.");

            return route;
        }
    }
}