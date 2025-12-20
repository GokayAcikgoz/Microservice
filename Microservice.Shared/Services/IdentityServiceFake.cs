using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("185cc9d6-e67d-4623-abd8-6d70f8fbc77c");

        public string UserName => "Ahmet16";
    }
}
