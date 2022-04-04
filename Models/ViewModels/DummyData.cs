using APIMuhasibat.Data;
using APIMuhasibat.Models;
using APIMuhasibat.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace APIMuhasibat.Models.ViewModels
{
    class DummyData
    {
      //  private readonly IRepository<Shirket> _firma = null;
        public DummyData(//IRepository<Shirket> firma//, IRepository<Navbar> nav, IRepository<NavbarRole> navrol
            )
        {
            // _firma = firma;
            //  _nav = nav;
            //  _navrol = navrol;
        }

        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationRole> _roleManager)
        {
            bool _b;
            context.Database.EnsureCreated();
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
                        reade = _b,
                        create = _b,
                        delete = _b,
                        update = _b,
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
                        if (rol == "Administrator") {await _userManager.AddToRoleAsync(user, rol); }                        
                    }
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var _result = await _userManager.ConfirmEmailAsync(user, code);
                }
            }
        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
        public string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
