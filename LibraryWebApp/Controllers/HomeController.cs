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
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(User user)
        {
            if (user != null && user.FirstName != null && user.LastName != null && user.Email != null && user.Password != null)
            {
                var users = unitOfWork.UserRepository.GetById(user.Email);
                if(users.Password == user.Password)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register(User user)
        {
            if (user != null && user.FirstName != null && user.LastName !=null && user.Email != null && user.Password!=null)
            {
                var users = unitOfWork.UserRepository.GetById(user.Email);
                if(users == null)
                {
                    bool check = MailModel.sendEmail(user);
                    if (check)
                    {
                        unitOfWork.UserRepository.Insert(user);
                        unitOfWork.Save();
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }

                }
                else
                {
                    return Json(true);
                }
            }
            else
            {
                return Json(false);
            }
        }
        [HttpGet]
        [ActionName("TakeBook")] 
        public ActionResult TakeBook()
        {
            return Json(true);
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
