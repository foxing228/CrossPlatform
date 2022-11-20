using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Okta.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Lab5.Models;
using System.Reflection;

namespace Lab5.Controllers
{
    public class AccountController : Controller
    {
        // [Authorize(Roles = "Lab5Groups")]
        // public IActionResult EnthusiastOnly()
        // {
        //     return View();
        // }
        
        [HttpGet]
        public IActionResult SignIn()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Challenge(OktaDefaults.MvcAuthenticationScheme);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            return new SignOutResult(
                new[]
                {
                    OktaDefaults.MvcAuthenticationScheme,
                    CookieAuthenticationDefaults.AuthenticationScheme,
                },
                new AuthenticationProperties { RedirectUri = "/Home/" });
        }
        
        public IActionResult Profile()
        {
            return View(new UserProfileModel()
            {
                Email = HttpContext.User.Claims.Where(x => x.Type == "preferred_username").FirstOrDefault().Value.ToString(),
                FirstName = HttpContext.User.Claims.Where(x => x.Type == "given_name").FirstOrDefault().Value.ToString(),
                LastName = HttpContext.User.Claims.Where(x => x.Type == "family_name").FirstOrDefault().Value.ToString(),
                PhoneNumber = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault().Value.ToString(),
                Alias = HttpContext.User.Claims.Where(x => x.Type == "zoneinfo").FirstOrDefault().Value.ToString(),
            });
        }

        /*[HttpPost]
        public IActionResult Profile(Lab5.Models.ProfileModel model)
        {
            model.Email = HttpContext.User.Claims.Where(x => x.Type == "login").FirstOrDefault().Value.ToString();
            model.FirstName = HttpContext.User.Claims.Where(x => x.Type == "firstName").FirstOrDefault().Value.ToString();
            model.LastName = HttpContext.User.Claims.Where(x => x.Type == "lastName").FirstOrDefault().Value.ToString();
            model.UserName = HttpContext.User.Claims.Where(x => x.Type == "nickname").FirstOrDefault().Value.ToString();
            model.PhoneNumber = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault().Value.ToString();
            return View(new ProfileModel
            {
                Email = HttpContext.User.Claims.Where(x => x.Type == "login").FirstOrDefault().Value.ToString(),
                FirstName = HttpContext.User.Claims.Where(x => x.Type == "firstName").FirstOrDefault().Value.ToString(),
                LastName = HttpContext.User.Claims.Where(x => x.Type == "lastName").FirstOrDefault().Value.ToString(),
                UserName = HttpContext.User.Claims.Where(x => x.Type == "nickname").FirstOrDefault().Value.ToString(),
                PhoneNumber = HttpContext.User.Claims.Where(x => x.Type == "phone_number").FirstOrDefault().Value.ToString(),
            });
        }*/


    }
}