using Artist.Models;
using Artist.ViewModel;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artist.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ArtistContext _context;
        private readonly CustomerContext db;
        private readonly IWebHostEnvironment _hostEnvironment;


        public CustomerController(CustomerContext db, ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = _hostEnvironment;
            this.db = db;
        }
        public async Task<ActionResult> Index()
        {
            var artistContext = _context.Users.Include(u => u.CreditCard).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role);

            return View(await artistContext.Where(d => d.RoleId == 4).ToListAsync());
        }

        public async Task<ActionResult> Index1()
        {
            var artistContext = _context.Users.Include(u => u.CreditCard).Include(u => u.Dep).Include(u => u.Location).Include(u => u.Role);

            return View(await artistContext.Where(d => d.RoleId == 4).ToListAsync());
        }

        [HttpPost]
        public FileResult Export()
        {
            int rowNum = 0;
            DataTable dt = new DataTable("Customers");
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Id"),
                                            new DataColumn("FirstName"),
                                            new DataColumn("LastName"),
                                            new DataColumn("Email"),
                                            new DataColumn("Gender"),
                                            new DataColumn("Number1"),
                                            new DataColumn("Number2"),
                                            
                                           });

            var customers = _context.Users.Where(x => x.RoleId == 4).ToList();
            foreach (var customer in customers)
            {
                dt.Rows.Add(rowNum , customer.FirstName, customer.LastName, customer.Email,
                    customer.Gender, customer.PhoneNumber1, customer.PhoneNumber2

                 );
                rowNum++;
            }

            DataTable dt2 = new DataTable("Report");
            dt2.Columns.AddRange(new DataColumn[3] {
                                             new DataColumn("Total"),
                                            new DataColumn("# females"),
                                            new DataColumn("# males"),
                                            });

            var countOfEmployees = _context.Users.Where(x => x.RoleId == 4).Count();
            var countOfFemaleEmployees = _context.Users.Where(x => x.RoleId == 4 && x.Gender == "Female").Count();
            var countOfMaleEmployees = _context.Users.Where(x => x.RoleId == 4 && x.Gender == "Male").Count();


            dt2.Rows.Add(countOfEmployees, countOfFemaleEmployees, countOfMaleEmployees);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dt2);


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "CustomersReport.xlsx");
                }
            }

        }

      


        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            //file name to be created   
            string strPDFFileName = string.Format("CustomersReport" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(7);
            PdfPTable tableLayout2 = new PdfPTable(3);


            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = _hostEnvironment.WebRootPath + ("~/File/" + strPDFFileName);


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

            float[] headers = { 24, 24, 24, 50, 24, 24, 24 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;




            //Add Title to the PDF file at the top  

            var employees = _context.Users.Where(x => x.RoleId == 4).ToList();


            tableLayout.AddCell(new PdfPCell(new Phrase("All Customers", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });



            int rowNum = 1;
            ////Add header  
            AddCellToHeader(tableLayout, "CustomerId");
            AddCellToHeader(tableLayout, "First Name");
            AddCellToHeader(tableLayout, "Last Name");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "Gender");
            AddCellToHeader(tableLayout, "Number 1");
            AddCellToHeader(tableLayout, "Number 2");



            ////Add body  

            foreach (var emp in employees)
            {
                AddCellToBody(tableLayout, rowNum.ToString());

                AddCellToBody(tableLayout, emp.FirstName);
                AddCellToBody(tableLayout, emp.LastName);

                AddCellToBody(tableLayout, emp.Email);
                AddCellToBody(tableLayout, emp.Gender);
                AddCellToBody(tableLayout, emp.PhoneNumber1.ToString());
                AddCellToBody(tableLayout, emp.PhoneNumber2.ToString());

                rowNum++;

            }

            return tableLayout;
        }

        protected PdfPTable Add_Content_To_PDF2(PdfPTable tableLayout2)
        {


            float[] headers2 = { 50, 50, 50}; //Header Widths  
            tableLayout2.SetWidths(headers2); //Set the pdf headers  
            tableLayout2.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout2.HeaderRows = 2;


            //Add Title to the PDF file at the top  

            var countOfEmployees = _context.Users.Where(x => x.RoleId == 4).Count();
            var countOfFemaleEmployees = _context.Users.Where(x => x.RoleId == 4 && x.Gender == "Female").Count();
            var countOfMaleEmployees = _context.Users.Where(x => x.RoleId == 4 && x.Gender == "Male").Count();


            tableLayout2.AddCell(new PdfPCell(new Phrase("Customers Report", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            AddCellToHeader2(tableLayout2, "Total");
            AddCellToHeader2(tableLayout2, "Total females");
            AddCellToHeader2(tableLayout2, "Total Males");


            AddCellToBody2(tableLayout2, countOfEmployees.ToString());
            AddCellToBody2(tableLayout2, countOfFemaleEmployees.ToString());
            AddCellToBody2(tableLayout2, countOfMaleEmployees.ToString());

            return tableLayout2;
        }

        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
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
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
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

        public async Task<ActionResult> Logout()
        {
            
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            

        }

    }
}


