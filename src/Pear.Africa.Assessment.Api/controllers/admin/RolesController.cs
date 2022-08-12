using Pear.Africa.Assessment.Common.Identity.Auth;

using Pear.Africa.Assessment.Api.Controllers.Base;
using Pear.Africa.Assessment.Domain.Identity;
using Pear.Africa.Assessment.Common.Dtos.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Pear.Africa.Assessment.Api.Controllers.Admin
{
    public class RolesController : AdminControllerBase
    {
        private readonly RoleManager<Role> _roleManager;


        public RolesController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult ListRoles()
        {
            return Ok(_roleManager.Roles);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(RoleDTO roleDto)
        {
            if (string.IsNullOrWhiteSpace(roleDto.Name))
            {
                return BadRequest("Role name should be provided.");
            }
            await _roleManager.CreateAsync(new Role(roleDto.Name));

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditRole(RoleDTO roleDto)
        {
            var role = await _roleManager.FindByIdAsync(roleDto.Id);
            if (role == null) return NotFound();

            role.Name = roleDto.Name;

            await _roleManager.UpdateAsync(role);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteRole(Guid id)
        {
            var identityRole = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (identityRole == null)
            {
                return NotFound();
            }

            if (identityRole.Name == Policies.IsAdmin)
            {
                return BadRequest();
            }

            await _roleManager.DeleteAsync(identityRole);

            return Ok();
        }
    }
}
