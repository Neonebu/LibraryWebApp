using LibraryWebApp.Models;
using LibraryWebApp.UOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                Book b = unitOfWork.BookRepository.GetById(1);
                if(b!= null)
                {

                }
                else
                {
                    Book book = new Book { Author = "test", BookCount = 3, Name = "ExampleName", Status = "available", Id = 0, Year = 1994 };
                    unitOfWork.BookRepository.Insert(book);
                    unitOfWork.Save();                  
                }
            }catch(Exception ex)
            {
                
            }
        }

        public IActionResult Index()
        {
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
    }
}
