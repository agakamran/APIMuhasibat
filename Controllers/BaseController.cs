using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APIMuhasibat.Controllers
{
    public class BaseController : ControllerBase
    {
        protected JwtSecurityToken _gettoken() {            
            
            if (Request.Headers["Authorization"].FirstOrDefault() != null)
            {
                string token = Request.Headers["Authorization"].FirstOrDefault().Substring(7);
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                return tokenS;
            }
            return null;
        }
        protected string _GeteId() {
            string Id = "";
            if (_gettoken() != null)
            {
                var claims = _gettoken().Claims;
                 Id = claims.Where(x => x.Type == JwtRegisteredClaimNames.NameId).FirstOrDefault().Value;
            }
            return Id;
        }
        protected IEnumerable<Claim> _GetRoles()
        {
            if (_gettoken() != null)
            {
                var claims = _gettoken().Claims;
                return claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType);
            }
            return null;
        }
        protected string _GetRole() {
            string rols = "";
            if (_gettoken() != null) { 
                var claims = _gettoken().Claims;
                rols = claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).FirstOrDefault().Value;                
            }
            return rols;
        }
        protected string _GetRoleId()
        {
            string rols = "";
            if (_gettoken() != null)
            {
                var claims = _gettoken().Claims;
                rols = claims.Where(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).FirstOrDefault().Value;
            }
            return rols;
        }
        protected string _GetEmail(){
            string email = "";
            if (_gettoken() != null)
            {
                var claims = _gettoken().Claims;
                email = claims.Where(x => x.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;
            }
            return email;
        }
        protected string _GetTarix()
        {
            var claims = _gettoken().Claims;
            var tari = claims.Where(x => x.Type == JwtRegisteredClaimNames.Exp).FirstOrDefault().Value;
            return tari;
        }
    }
}
