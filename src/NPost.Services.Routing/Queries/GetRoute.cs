using System.Collections.Generic;
using Convey.CQRS.Queries;
using NPost.Services.Routing.DTO;

namespace NPost.Services.Routing.Queries
{
    public class GetRoute : IQuery<RouteDto>
    {
        public IEnumerable<string> Addresses { get; set; }
    }
}