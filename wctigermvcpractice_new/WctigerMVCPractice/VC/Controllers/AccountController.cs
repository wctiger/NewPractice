using Models.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VC.UIModels;
using Utilities;

namespace VC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAuthentication _authentication;
        private IUserRepository _repository;

        public AccountController(IAuthentication auth, IUserRepository repo)
        {
            this._authentication = auth;
            this._repository = repo;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if( _authentication.Authenticate(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Admin", null);
                    else
                        return RedirectToAction("List", "Products", null);
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect User Name or Password");
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Admin");
        }

        [AllowAnonymous]
        public ViewResult CreateUser()
        {
            return View(new User());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserGuid = Guid.NewGuid();
                user.Password = SecurityUtility.EncryptPassword(user.Password + user.UserGuid.ToString());
                if (_repository.SaveUser(user))
                {
                    TempData["message"] = string.Format("User {0} has been created", user.UserName);
                    return RedirectToAction("Login");
                }

            }
            return View(user);
        }
	}
}