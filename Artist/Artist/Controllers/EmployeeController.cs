using Artist.Models;
using Artist.ViewModel;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Text;

namespace Artist.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly EmployeeContext db;
        private readonly ArtistContext _context;

        public EmployeeController(EmployeeContext db, ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this.db = db;
            _context = context;
            this._hostEnvironment = _hostEnvironment;


        }

        [HttpPost]
        public FileResult Export()
        {
            int rowNum = 0;
            DataTable dt = new DataTable("Employees");
            dt.Columns.AddRange(new DataColumn[9] { new DataColumn("Id"),
                                            new DataColumn("FirstName"),
                                            new DataColumn("LastName"),
                                            new DataColumn("Email"),
                                            new DataColumn("Gender"),
                                            new DataColumn("Number1"),
                                            new DataColumn("Number2"),
                                            new DataColumn("Position"),
                                            new DataColumn("Salary"),
                                           });

            var customers = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role).ToList();
            foreach (var customer in customers)
            {
                dt.Rows.Add(rowNum + 1, customer.FirstName, customer.LastName, customer.Email,
                    customer.Gender, customer.PhoneNumber1, customer.PhoneNumber2,
                    customer.Position, customer.Salary);
            }

            DataTable dt2 = new DataTable("Report");
            dt2.Columns.AddRange(new DataColumn[4] {
                                             new DataColumn("Total"),
                                            new DataColumn("# females"),
                                            new DataColumn("# males"),
                                            new DataColumn("Avg of salary")});

            var countOfEmployees = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Count();
            var countOfFemaleEmployees = _context.Users.Where(x => (x.RoleId == 3 && x.Gender == "Female") || (x.RoleId == 2 && x.Gender == "Female")).Count();
            var countOfMaleEmployees = _context.Users.Where(x => (x.RoleId == 3 && x.Gender == "Male") || (x.RoleId == 2 && x.Gender == "Male")).Count();
            var avgOfSalary = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Select(x => x.Salary).Average();


            dt2.Rows.Add(countOfEmployees, countOfFemaleEmployees, countOfMaleEmployees,
                   avgOfSalary);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dt2);


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeesReport.xlsx");
                }
            }

        }
        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            //file name to be created   
            string strPDFFileName = string.Format("EmployeesReport" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(8);
            PdfPTable tableLayout2 = new PdfPTable(4);


            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = _hostEnvironment.WebRootPath+("~/File/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF2(tableLayout2));

            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 24, 50, 50, 24,50,50,24,24 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;

           


            //Add Title to the PDF file at the top  

            var employees = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role).ToList();
           

            tableLayout.AddCell(new PdfPCell(new Phrase("All Employees", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0)))) {
                Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER
            });

            

            int rowNum = 1;
            ////Add header  
            AddCellToHeader(tableLayout, "EmployeeId");
            AddCellToHeader(tableLayout, "Name");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "Gender");
            AddCellToHeader(tableLayout, "Number 1");
            AddCellToHeader(tableLayout, "Number 2");

            AddCellToHeader(tableLayout, "Position");
            AddCellToHeader(tableLayout, "Salary");

            ////Add body  

            foreach (var emp in employees)
            {
                AddCellToBody(tableLayout, rowNum.ToString());

                AddCellToBody(tableLayout, emp.fullname);
                AddCellToBody(tableLayout, emp.Email);
                AddCellToBody(tableLayout, emp.Gender);
                AddCellToBody(tableLayout, emp.PhoneNumber1.ToString());
                AddCellToBody(tableLayout, emp.PhoneNumber2.ToString());
                AddCellToBody(tableLayout, emp.Position);
                AddCellToBody(tableLayout, emp.Salary.ToString());

                rowNum++;

            }

            return tableLayout;
        }

        protected PdfPTable Add_Content_To_PDF2(PdfPTable tableLayout2)
        {
         

            float[] headers2 = { 50, 50, 50, 50 }; //Header Widths  
            tableLayout2.SetWidths(headers2); //Set the pdf headers  
            tableLayout2.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout2.HeaderRows = 2;


            //Add Title to the PDF file at the top  

            var countOfEmployees = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Count();
            var countOfFemaleEmployees = _context.Users.Where(x => (x.RoleId == 3 && x.Gender == "Female") || (x.RoleId == 2 && x.Gender == "Female")).Count();
            var countOfMaleEmployees = _context.Users.Where(x => (x.RoleId == 3 && x.Gender == "Male") || (x.RoleId == 2 && x.Gender == "Male")).Count();
            var avgOfSalary = _context.Users.Where(x => x.RoleId == 3 || x.RoleId == 2).Select(x => x.Salary).Average();

            tableLayout2.AddCell(new PdfPCell(new Phrase("Employees Report", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            AddCellToHeader2(tableLayout2, "Total");
            AddCellToHeader2(tableLayout2, "Total females");
            AddCellToHeader2(tableLayout2, "Total Males");
            AddCellToHeader2(tableLayout2, "Avg Salary");


            AddCellToBody2(tableLayout2, countOfEmployees.ToString());
            AddCellToBody2(tableLayout2, countOfFemaleEmployees.ToString());
            AddCellToBody2(tableLayout2, countOfMaleEmployees.ToString());
            AddCellToBody2(tableLayout2, avgOfSalary.ToString());


            return tableLayout2;
        }

        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
    });
        }

        private static void AddCellToHeader2(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
             {
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
    });
        }

        private static void AddCellToBody2(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }
        public async Task<ActionResult> Index()
        {
            var artistContext = _context.Users.Include(u => u.CreditCard).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role);
            return View(await artistContext.Where(d => d.RoleId == 3 || d.RoleId == 2).ToListAsync());
        }
        public async Task<ActionResult> Index1()
        {
            var artistContext = _context.Users.Include(u => u.CreditCard).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role);

            return View(await artistContext.Where(d => d.RoleId == 3 || d.RoleId == 2).ToListAsync());
        }
        public ActionResult AddEmployee()
        {
            var artistContext = _context.Users.Include(t => t.Role).Include(x=>x.Dep);
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            ViewData["RoleId"] = new SelectList(_context.Role, "RoleId", "RoleName");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeVM obj)
        {
            Location location = new Location();
            location.Country = obj.Country;
            location.CityName = obj.CityName;
            location.Latitude = obj.Latitude;
            location.Longitude = obj.Longitude;
            db.Location.Add(location);
            db.SaveChanges();


            Users user = new Users();
                  
            if (user.ImageFile != null) // check if contains ext
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile.FileName;
                string extension = System.IO.Path.GetExtension(user.ImageFile.FileName);
                string path = System.IO.Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                     user.ImageFile.CopyToAsync(fileStream);
                }              
                user.UserImage = fileName;
                obj.UserImage = fileName;
                
                db.SaveChangesAsync();


            }
            user.JoinDate = DateTime.Now;
            obj.JoinDate= DateTime.Now;

            user.Username = obj.Username;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Gender = obj.Gender;
            user.Email = obj.Email;
            user.Password = obj.Password;
            user.ConfirmPassword = obj.ConfirmPassword;
            user.PhoneNumber1 = obj.PhoneNumber1;
            user.PhoneNumber2 = obj.PhoneNumber1;
            user.DateOfBirth = obj.DateOfBirth;
            user.JoinDate = obj.JoinDate;
            user.RoleId = obj.RoleId;
            user.DepId = obj.DepId;
            user.Salary = obj.Salary;
            user.Position = obj.Position;
            user.LocationId = location.LocationId;

            if (user.Gender == "Male")
            {
                user.UserImage = "man.jpg";
            }
            else
            {
                user.UserImage = "woman.png";
            }

            db.Add(user);
            db.SaveChangesAsync();
            ViewData["RoleId"] = new SelectList(_context.Role.Where(x => x.RoleId!=4), "RoleId", "RoleName");
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            return RedirectToAction(nameof(AddEmployee));
        }

        public IActionResult Edit(int? id)
        {

            var user = _context.Users.Where(x => x.UserId == id).Include(x=>x.Dep).Include(x=>x.Location).Include(x=>x.Role).FirstOrDefault();
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            ViewData["RoleID"] = new SelectList(_context.Role, "RoleID", "RoleName");


            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int ID, string FirstName,string gender, string LastName, string Email, int PhoneNumber1, int PhoneNumber2, DateTime DateOfBirth,  string position,int salary ,string Department,string Country,string CityName, Users users)
        {
            var user = _context.Users.Where(u => u.UserId == ID).Include(x => x.Location).Include(x => x.Dep).FirstOrDefault();

            if (ModelState.IsValid)
            {

                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Email = Email;
                user.DateOfBirth = DateOfBirth;

                user.PhoneNumber1 = PhoneNumber1;
                user.PhoneNumber2 = PhoneNumber2;
                user.Salary = salary;
                user.Gender = gender;
                user.Position = position;
                user.Location.Country = Country;
                user.Location.CityName = CityName;
                user.Dep.Title = Department;


                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));



            }
            ViewData["DepId"] = new SelectList(_context.Department, "DepId", "Title");
            ViewData["RoleID"] = new SelectList(_context.Role, "RoleID", "RoleName");

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<ActionResult> Logout()
        {

            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Home");

        }
    }
}
