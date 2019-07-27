using System.Collections.Generic;
using NPost.Services.Routing.DTO;

namespace NPost.Services.Routing.Services
{
    public interface IRoutingService
    {
        RouteDto Calculate(IEnumerable<string> addresses);
    }
}