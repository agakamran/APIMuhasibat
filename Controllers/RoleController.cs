using APIMuhasibat.Models;
using APIMuhasibat.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIMuhasibat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class RoleController : ControllerBase
    {
        private RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
       
        public RoleController(RoleManager<ApplicationRole> roleMgr, UserManager<ApplicationUser> userMrg)
        {
            _roleManager = roleMgr;
            _userManager = userMrg;
        }
        [HttpGet]
        [Route("_getRoles")]
        public IActionResult _getRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_roleManager.Roles);
        }
        [HttpGet]//("{id}")
        [Route("_getUser")]
        public IActionResult _getUser(string id)
        {
            RoleEditModel Mod = new RoleEditModel();
            if (id != null&& id!= "undefined")
            {
                IdentityRole role = _roleManager.FindByIdAsync(id).Result;
                var members = new List<ApplicationUser>();
                var nonMembers = new List<ApplicationUser>();
                foreach (ApplicationUser user in _userManager.Users)
                {
                    var list = _userManager.IsInRoleAsync(user, role.Name).Result ? members : nonMembers;
                    list.Add(user);
                }
                Mod.Role = role; Mod.Members = members; Mod.NonMembers = nonMembers;
            }
            return Ok(Mod);
        }
        [HttpPost]
        [Route("_EditRoles")]
        public IActionResult _EditRoles([FromBody] RoleModificationModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.IdsToAdd ?? new string[] { })
                {
                    ApplicationUser user = _userManager.FindByIdAsync(userId).Result;
                    if (user != null)
                    {
                        result = _userManager.AddToRoleAsync(user, model.RoleName).Result;
                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    ApplicationUser user = _userManager.FindByIdAsync(userId).Result;
                    if (user != null)
                    {
                        result = _userManager.RemoveFromRoleAsync(user, model.RoleName).Result;
                        if (!result.Succeeded)
                        {
                            AddErrors(result);
                        }
                    }
                }
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {

                var Rol = new RoleModificationModel();
                Rol.RoleId = model.RoleId;
                return _getUser(Rol.RoleId);
            }
        }

        [HttpPost]
        [Route("_CreateRole")]
        public async Task<IActionResult> _CreateRole([FromBody] Role rol)
        {
            if (ModelState.IsValid)
            {
                if (rol.id == "")
                {
                    IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole(rol.name));
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        AddErrors(result);
                        return BadRequest();
                    }
                }
                /*  else
                  {

                      IdentityResult result = await _roleManager.UpdateAsync();
                      if (result.Succeeded)
                      {
                          return Ok();
                      }
                      else
                      {
                          AddErrors(result);
                          return BadRequest();
                      }

                  }*/

            }
            return Ok(rol.name);
        }
        [HttpPost]
        [Route("_DeleteRole")]
        public async Task<IActionResult> _DeleteRole([FromBody] Role rol)
        {
            ApplicationRole role = await _roleManager.FindByIdAsync(rol.id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Ok(_roleManager.Roles);
                }
                else
                {
                    AddErrors(result);
                    return BadRequest(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "No role found");
                return Ok();
            }
            // return View("Index", _roleManager.Roles);
        }
        [HttpGet]
        [Route("addAllrole")]
        public async Task<IActionResult> addAllrole()
        {
            bool _b;
            string _user = "agakamran@yandex.ru", password = "123456";
            string[] _role = { "Administrator", "Operator", "User" };
            foreach (var rol in _role)
            {
                if (rol == "Administrator") { _b = true; }
                else { _b = false; }
                if (await _roleManager.FindByNameAsync(rol) == null)
                {
                    await _roleManager.CreateAsync(new ApplicationRole
                    {
                      CanAccess  = _b,
                      CanAdd = _b,
                      CanDelete = _b,
                      CanUpdate = _b,
                        Id = Guid.NewGuid().ToString(),
                        Name = rol,
                        NormalizedName = rol.ToUpper()
                    });
                }
            }
            if (await _userManager.FindByEmailAsync(_user) == null)
            {
                var user = new ApplicationUser { UserName = _user, Email = _user };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    foreach (var rol in _role)
                    {
                        await _userManager.AddToRoleAsync(user, rol);
                    }
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var _result = await _userManager.ConfirmEmailAsync(user, code);
                }
            }
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        #region Helpers       
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        //[HttpGet]
        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        #endregion
        //------------------------------------
       
    }
}
