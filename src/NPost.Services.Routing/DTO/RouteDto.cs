using System.Collections.Generic;

namespace NPost.Services.Routing.DTO
{
    public class RouteDto
    {
        public IEnumerable<string> Addresses { get; set; }
        public double TotalDistance { get; set; }
    }
}