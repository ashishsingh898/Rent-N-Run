using Microsoft.AspNetCore.Mvc;
using RentNRunLib;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Web;
using Microsoft.AspNetCore.Identity;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace RentNRun.Controllers
{
    public class HomeController : Controller
    {
        Myclass ob = new();
        CarrentContext dc = new CarrentContext();

        public IActionResult Index()
        {
            return View();
        }


        public ViewResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string toaddress, string uname, string pwd)
        {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse("kakatiyamotors@gmail.com");
            email.To.Add(MailboxAddress.Parse("kakatiyamotors@gmail.com"));
            email.Subject = "TestingMail";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>your car is successfully booked</h1>" };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("kakatiyamotors", "kakatiya@123");
            smtp.Send(email);
            smtp.Disconnect(true);
            return View();
        }


        public ActionResult Cars()
        {
            var result = ob.Cars();
            return View(result);
        }


        public ViewResult Services()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Signup r)
        {
            if (ModelState.IsValid)
            {
                var i = ob.Signupmethod(r);
                if (i > 0)
                {
                    ViewData["a"] = "New User created successfully";
                }
                else
                {
                    ViewData["a"] = "Error occured try after some time";
                }
                ModelState.Clear();
                return View();
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string t1, string t2)
        {
            HttpContext.Session.SetString("Email", t1);
            var r = ob.Signinmethod(t1, t2);

            if (r > 0)
            {
                Response.Redirect("Cars");

            }
            else
            {
                ViewData["a"] = "In-Valid user";
            }

            return View();
        }


        public ActionResult Signout()
        {
            HttpContext.Session.Clear();
            return View("Signin");
        }


        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contactus r)
        {
            var i = ob.Contactmethod(r);
            if (i > 0)
            {
                ViewData["a"] = "Your Query is Sent to Customer Care,We Will Respond You Shortly.";
            }
            else
            {
                ViewData["a"] = "Error occured try after some time";
            }
            ModelState.Clear();
            return View();
        }



        [HttpGet]
        public ViewResult Cart(int mycarid)
        {
            // is it 1 or many
            var result = dc.Cars.ToList().Find(c => c.CarId == mycarid);

            TempData["p"] = result.Model;
            TempData["i"] = result.CarId;
            TempData["j"] = result.ModelYear;
            TempData["k"] = result.Color;
            TempData["l"] = result.NumberOfPersons;
            TempData["m"] = result.DailyRent;

            TempData.Keep();
            return View(result);
        }

        [HttpPost]
        public ActionResult Cart(IFormCollection c)
        {
            // insert new value to myorders table
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Signin");
            }
            else
            {
                Cart o = new Cart();
                o.CarId = Convert.ToInt32(TempData["i"]);
                o.Email = HttpContext.Session.GetString("Email");


                dc.Carts.Add(o);
                int i = dc.SaveChanges();

                if (i > 0)
                {
                    ViewData["a"] = "Your order placed successfully";
                }
                else
                {
                    ViewData["a"] = "Error occured try after some time";
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult Booking(int mycarid)
        {
      

                if (HttpContext.Session.GetString("Email") == null)
                {
                    return RedirectToAction("Signin");
                }
            
           
            else
            {

                var res = ob.Booking(mycarid);
                TempData["i"] = res.CarId;
                TempData["p"] = res.Model;
                TempData["type"] = HttpContext.Session.GetString("Email");
                TempData["desc"] = res.Color;
                TempData["s"] = res.NumberOfPersons;
                TempData["sa"] = res.DailyRent;
                TempData["dd"] = res.Images;
                TempData.Keep();

                return View(res);
                }
            
        }

        [HttpPost]
        public ActionResult Booking(Booking c)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Signin");
            }

            else
            {


                c.CarId = Convert.ToInt32(TempData["i"]);
                c.Email = TempData["type"].ToString();
                c.OrderDate = DateTime.Now;


                dc.Bookings.Add(c);
                int i = dc.SaveChanges();
                if (i > 0)
                {
                    ViewData["a"] = "Booked Successfully";
                }
                else
                {
                    ViewData["a"] = "Something went wrong..Please try again";
                }
            }

            return View();
        }
    }
    }
