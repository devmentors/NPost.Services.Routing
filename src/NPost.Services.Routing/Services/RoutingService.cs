using System.Collections.Generic;
using System.Linq;
using NPost.Services.Routing.DTO;

namespace NPost.Services.Routing.Services
{
    public class RoutingService : IRoutingService
    {
        public RouteDto Calculate(IEnumerable<string> addresses)
        {
            var routeAddresses = addresses.OrderBy(a => a).ToList();
            var totalDistance = routeAddresses.Sum(a => a.Length * 5);

            return new RouteDto
            {
                Addresses = routeAddresses,
                TotalDistance = totalDistance
            };
        }
    }
}