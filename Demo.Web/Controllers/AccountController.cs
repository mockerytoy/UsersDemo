using Demo.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Users.Model;
using Users.Repository;
using Users.Repository.Repositories;
using Users.Services.Contracts;
using Users.Services.Users;

namespace Demo.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController() : this(new UserService(new EfRepository<User>(new UsersDbContext())))
        {
        }

        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            var ctx = HttpContext.GetOwinContext().Authentication;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = ctx.User;


            User user = this._userService.GetByUserName(model.UserName);

            //check username and password from database, naive checking: 
            //password should be in SHA
            if (user != null && (user.Password == model.Password))
            {
                var claims = new[] {
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
                };
                // can add more claims
           

                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            
                // Add roles into claims
                //var roles = _roleService.GetByUserId(user.Id);
                //if (roles.Any())
                //{
                //    var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.Name));
                //    identity.AddClaims(roleClaims);
                //}

                var authManager = Request.GetOwinContext().Authentication;

                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
            };
            return RedirectToAction("Index", "Home");
            


            //    var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Name, "Brock"));
            //claims.Add(new Claim(ClaimTypes.Hash, "123456"));
            //claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));


            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.NameIdentifier, ClaimTypes.Role);

            //var id = new ClaimsIdentity(claims,
            //                            DefaultAuthenticationTypes.ApplicationCookie);

            //var authenticationManager = Request.GetOwinContext().Authentication;
            ////var authenticationManager = ctx.Authentication;
            //authenticationManager.SignIn(id);

            //return View();

        }

        [HttpPost]
        public ActionResult LogOut(LoginViewModel loginModel)
        {
            return View();
        }
    }
}