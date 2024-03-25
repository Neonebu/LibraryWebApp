using LibraryWebApp.Models;
using LibraryWebApp.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace LibraryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UnitOfWork unitOfWork = new UnitOfWork();
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(ILogger<HomeController> logger,IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _contextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            populateTable();
            var books = unitOfWork.BookRepository.Get();
            return View(books);
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
            if (user != null)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
                //_contextAccessor.HttpContext.Session.SetString("display", "display:none");
                //_contextAccessor.HttpContext.Session.SetString("username", user.FirstName + " " + user.LastName);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                //ViewBag.User = user.FirstName + " " + user.LastName;
                //ViewBag.style = "display:none";

            }
            //var users = unitOfWork.UserRepository.GetById(user.Email);
            //if (users == null)
            //{
            //    bool check = MailModel.sendEmail(user);
            //    if (check)
            //    {
            //        ViewBag.Test = "Please check your email";
            //        unitOfWork.UserRepository.Insert(user);
            //    }
            //    else
            //    {
            //        ViewBag.Test = "Email Couldnt Send";
            //    }
            //    return View();
            //}
            //else
            //{

            //}
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void populateTable()
        {
            try
            {
                Book b = unitOfWork.BookRepository.GetById(1);
                if (b != null)
                {

                }
                else
                {
                    Book book = new Book { Author = "test", BookCount = 3, Name = "ExampleName", Status = "available", Id = 0, Year = 1994 };
                    unitOfWork.BookRepository.Insert(book);
                    unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
