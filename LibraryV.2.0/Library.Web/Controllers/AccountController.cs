using Domain.Model.Models;
using Library.Web.Models;
using Repository.Abstraction.Interfaces;
using System;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Web.Mvc;

namespace Library.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserRepository _accountRepository;
        public AccountController(IUserRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        // GET: Account
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Login");
            var connection = new LdapConnection("adservermd.amdaris.net");
            var credential = new NetworkCredential(model.Username, model.Password);

            try
            {
                connection.Credential = credential;
                connection.Bind();
            }
            catch (Exception ex)
            {
                // handle the Exception
                // return ModelState.AddModelError()
                throw;
            }
            
            // Authorization 

            return RedirectToAction("Index", "Book");
        }
        private LogOnViewModel Authorize(NetworkCredential credential)
        {
            var user = _accountRepository.GetByName(credential.UserName);
            if (user != null)
                return  AutoMapper.Mapper.Map<User, LogOnViewModel>(user);
            return null;
        }
    }
}