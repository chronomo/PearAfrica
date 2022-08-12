
using Pear.Africa.Assessment.Common.Identity.Auth;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pear.Africa.Assessment.Api.Controllers.Base
{
    //[Authorize(Policy = Policies.IsAdmin)]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class AdminControllerBase : ControllerBase
    {
        protected const string Id = "{id}";
    }
}
