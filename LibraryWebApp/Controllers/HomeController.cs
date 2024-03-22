using LibraryWebApp.Models;
using LibraryWebApp.UOW;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork unitOfWork = new UnitOfWork();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register(User user)
        {
            var users = unitOfWork.UserRepository.GetByEmail(user.Email);
            if (users == null)
            {
                bool check = MailModel.sendEmail(user);
                if (check)
                {
                    ViewBag.Test = "Please check your email";
                    unitOfWork.UserRepository.Insert(user);
                }
                else
                {
                    ViewBag.Test = "Email Couldnt Send";
                }
                return View();
            }
            else
            {

            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
