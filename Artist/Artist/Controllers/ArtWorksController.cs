using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artist.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Text;
using ClosedXML.Excel;
using System.Data;
using X.PagedList;


namespace Artist.Controllers
{
    public class ArtWorksController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ArtistContext _context;
        string id = "id";


        public ArtWorksController(ArtistContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }



        // GET: ArtWorks
        //admin
        [Authorize(Roles = "Admin")]
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.ArtWorks.Where(x=>x.Quantity>0).Include(a => a.Category).Include(a => a.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }

        [Authorize(Roles = "Admin")]
        public  IActionResult Index1(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.ArtWorks.Where(x => x.Quantity == 0).Include(a => a.Category).Include(a => a.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }
        //customer
        [Authorize(Roles = "User")]
        public  IActionResult CustomerArts(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.ArtWorks.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.Quantity>0).Include(a => a.Category).Include(a => a.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }
        [Authorize(Roles = "User")]
        public IActionResult SoldArts2(int? page)
        {
            var pageNumber = page ?? 1;
            var artistContext = _context.ArtWorks.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.Quantity == 0).Include(a => a.Category).Include(a => a.User).ToList().ToPagedList(pageNumber, 6);
            return View( artistContext);
        }
        //admin report
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Table1()

        {
            var artistContext = _context.ArtWorks.Where(x => x.Quantity > 0).Include(a => a.Category).Include(a => a.User);
            return View(await artistContext.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Table2()

        {
            var artistContext = _context.ArtWorks.Where(x => x.Quantity == 0).Include(a => a.Category).Include(a => a.User);
            return View(await artistContext.ToListAsync());
        }
        //accountant report
        [Authorize(Roles = "Accountant")]
        public async Task<IActionResult> Table3()

        {
            var artistContext = _context.ArtWorks.Where(x => x.Quantity == 0).Include(a => a.Category).Include(a => a.User);
            return View(await artistContext.ToListAsync());
        }
        [Authorize(Roles = "Accountant")]
        public async Task<IActionResult> Table4()

        {
            var artistContext = _context.ArtWorks.Where(x => x.Quantity > 0).Include(a => a.Category).Include(a => a.User);
            return View(await artistContext.ToListAsync());
        }

      

        [HttpPost]
        public FileResult Export()
        {
            int rowNum = 1;
            DataTable dt = new DataTable("ArtWorks");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"),
                                            new DataColumn("Title"),
                                            new DataColumn("Artist Name"),
                                            new DataColumn("Price"),
                                            new DataColumn("Quantity"),

                                           });

            var artworks = _context.ArtWorks.Where(x=>x.Quantity>0).ToList();
            foreach (var art in artworks)
            {
                dt.Rows.Add(rowNum, art.ArtistFname + art.ArtistLname,art.Title, art.ArtPrice,
                    art.Quantity
                 );
                rowNum++;
            }

            DataTable dt2 = new DataTable("Report");
            dt2.Columns.AddRange(new DataColumn[3] {
                                             new DataColumn("Total Arts"),
                                             new DataColumn("Total Price"),
                                            new DataColumn("Avg price")

                                            });

            var countOfarts = _context.ArtWorks.Where(x=>x.Quantity>0).Count();
            var totalPrice = _context.ArtWorks.Where(x=>x.Quantity>0).Select(x => x.ArtPrice * x.Quantity).Sum();

            var avgPrice = _context.ArtWorks.Select(x=>x.ArtPrice).Average();


            dt2.Rows.Add(countOfarts, totalPrice,avgPrice);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dt2);


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AvailableArts.xlsx");
                }
            }

        }

        [HttpPost]
        public FileResult Export1()
        {
            int rowNum = 1;
            DataTable dt = new DataTable("ArtWorks");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Id"),
                                            new DataColumn("Title"),
                                            new DataColumn("Artist Name"),
                                            new DataColumn("Price"),
                                             new DataColumn("Quantity")

                                           });

            var artworks = _context.ArtWorks.Where(x => x.Quantity == 0).ToList();
            foreach (var art in artworks)
            {
                dt.Rows.Add(rowNum, art.ArtistFname + art.ArtistLname, art.Title, art.ArtPrice,
                    art.Quantity
                 );
                rowNum++;
            }

            DataTable dt2 = new DataTable("Report");
            dt2.Columns.AddRange(new DataColumn[4] {
                                             new DataColumn("Total Arts"),
                                             new DataColumn("Total Price"),
                                            new DataColumn("Avg price"),
                                            new DataColumn("Profits")

                                            });

            var countOfarts = _context.ArtWorks.Where(x => x.Quantity == 0).Count();
            var totalPrice = _context.ArtWorks.Where(x => x.Quantity == 0).Select(x => x.ArtPrice).Sum();
            var profits = _context.ArtWorks.Where(x => x.Quantity == 0).Select(x => x.ArtPrice * .20).Sum();

            var avgPrice = _context.ArtWorks.Select(x => x.ArtPrice).Average();
            dt2.Rows.Add(countOfarts, totalPrice, avgPrice,profits);

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Worksheets.Add(dt2);


                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SoldArts.xlsx");
                }
            }

        }
        public FileResult CreatePdf()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            //file name to be created   
            string strPDFFileName = string.Format("AvailableArts" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(5);
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

        public FileResult CreatePdf1()
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            //file name to be created   
            string strPDFFileName = string.Format("SoldArts" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table with 5 columns  
            PdfPTable tableLayout = new PdfPTable(4);
            PdfPTable tableLayout2 = new PdfPTable(4);


            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = _hostEnvironment.WebRootPath + ("~/File/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF4(tableLayout2));

            doc.Add(Add_Content_To_PDF3(tableLayout));

            // Closing the document  
            doc.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;


            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 24, 30, 30, 24, 24 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            var artworks = _context.ArtWorks.Where(x=>x.Quantity>0).ToList();

            tableLayout.AddCell(new PdfPCell(new Phrase("All Available Arts", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            int rowNum = 1;
            ////Add header  
            AddCellToHeader(tableLayout, "ArtId");
            AddCellToHeader(tableLayout, "Title");
            AddCellToHeader(tableLayout, "Artist Name");
            AddCellToHeader(tableLayout, "Price");
            AddCellToHeader(tableLayout, "Quantity");
            ////Add body  

            foreach (var emp in artworks)
            {
                AddCellToBody(tableLayout, rowNum.ToString());
                AddCellToBody(tableLayout, emp.Title);
                AddCellToBody(tableLayout, emp.ArtistFname + emp.ArtistLname);
                AddCellToBody(tableLayout, emp.ArtPrice.ToString());
                AddCellToBody(tableLayout, emp.Quantity.ToString());
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

            var countOfarts = _context.ArtWorks.Where(x => x.Quantity > 0).Count();
            var totalPrice = _context.ArtWorks.Where(x => x.Quantity > 0).Select(x => x.ArtPrice * x.Quantity).Sum();
            var avgPrice = _context.ArtWorks.Select(x => x.ArtPrice).Average();


            tableLayout2.AddCell(new PdfPCell(new Phrase("Available Arts Report", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            AddCellToHeader2(tableLayout2, "Total Arts");
            AddCellToHeader2(tableLayout2, "Total Peice");
            AddCellToHeader2(tableLayout2, "Avg price");

            AddCellToBody2(tableLayout2, countOfarts.ToString());
            AddCellToBody2(tableLayout2, totalPrice.ToString());
            AddCellToBody2(tableLayout2, avgPrice.ToString());
            return tableLayout2;
        }

        protected PdfPTable Add_Content_To_PDF3(PdfPTable tableLayout)
        {

            float[] headers = { 24, 30, 30, 24}; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            var artworks = _context.ArtWorks.Where(x => x.Quantity == 0).ToList();

            tableLayout.AddCell(new PdfPCell(new Phrase("All Sold Arts", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            int rowNum = 1;
            ////Add header  
            AddCellToHeader(tableLayout, "ArtId");
            AddCellToHeader(tableLayout, "Title");
            AddCellToHeader(tableLayout, "Artist Name");
            AddCellToHeader(tableLayout, "Price");
            ////Add body  

            foreach (var emp in artworks)
            {
                AddCellToBody(tableLayout, rowNum.ToString());
                AddCellToBody(tableLayout, emp.Title);
                AddCellToBody(tableLayout, emp.ArtistFname + emp.ArtistLname);
                AddCellToBody(tableLayout, emp.ArtPrice.ToString());
                rowNum++;

            }

            return tableLayout;
        }

        protected PdfPTable Add_Content_To_PDF4(PdfPTable tableLayout2)
        {


            float[] headers2 = { 50, 50, 50 ,50}; //Header Widths  
            tableLayout2.SetWidths(headers2); //Set the pdf headers  
            tableLayout2.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout2.HeaderRows = 2;


            //Add Title to the PDF file at the top  

            var countOfarts = _context.ArtWorks.Where(x => x.Quantity ==0).Count();
            var totalPrice = _context.ArtWorks.Where(x => x.Quantity ==0).Select(x => x.ArtPrice).Sum();
            var avgPrice = _context.ArtWorks.Select(x => x.ArtPrice).Average();
            var profits = _context.ArtWorks.Where(x=>x.Quantity==0).Select(x => x.ArtPrice * .20).Sum();


            tableLayout2.AddCell(new PdfPCell(new Phrase("Sold Arts Report", new Font(Font.FontFamily.HELVETICA, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
            {
                Colspan = 12,
                Border = 0,
                PaddingBottom = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            });


            AddCellToHeader2(tableLayout2, "Total Arts");
            AddCellToHeader2(tableLayout2, "Total Price");
            AddCellToHeader2(tableLayout2, "Avg price");
            AddCellToHeader2(tableLayout2, "Profits");

            AddCellToBody2(tableLayout2, countOfarts.ToString());
            AddCellToBody2(tableLayout2, totalPrice.ToString());
            AddCellToBody2(tableLayout2, avgPrice.ToString());
            AddCellToBody2(tableLayout2, profits.ToString());

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


        // GET: ArtWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ArtId == id);
            if (artWorks == null)
            {
                return NotFound();
            }

            return View(artWorks);
        }

        public async Task<IActionResult> DetailsCust(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artWorks = await _context.ArtWorks
                .Include(a => a.Category)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ArtId == id);
            if (artWorks == null)
            {
                return NotFound();
            }

            return View(artWorks);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Search()
        {

            return View();
        }

        [HttpPost]
        [Obsolete]
        [Authorize(Roles = "Admin")]
        public IActionResult Search(DateTime datefrom, DateTime dateto, int? page)
        {
            var pageNumber = page ?? 1;

            var xx =  _context.ArtWorks.Where(x => x.SoldDate >= datefrom && x.SoldDate <= dateto && x.Quantity==0).Include(x=>x.Category).ToList().ToPagedList(pageNumber, 6);
            return View(xx);
        }
        // GET: ArtWorks/Create
        [Authorize(Roles = "User")]

        public IActionResult Create()
        {
            
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: ArtWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtId,ArtPrice,ImageName,Title,Description,UserId,CategoryId,OrderId,ArtistFname,ArtistLname,Quantity,ArtDate,ImageFile")] ArtWorks artWorks)
        {

            if (artWorks.ImageFile != null) // check if contains ext
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + artWorks.ImageFile.FileName;
                string extension = Path.GetExtension(artWorks.ImageFile.FileName);
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await artWorks.ImageFile.CopyToAsync(fileStream);
                }
                artWorks.ImageName = fileName;
                artWorks.ArtDate = DateTime.Now;
                artWorks.UserId = HttpContext.Session.GetInt32(id);
                _context.Add(artWorks);
                var users = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).FirstOrDefault();
                Notification noti = new Notification();
                noti.Date = DateTime.Now.ToShortDateString();
                noti.UserId = 61;
                noti.Msg = users.fullname + " has added a new drawing ";
                noti.IsRead = false;
                _context.Add(noti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CustomerArts));
            }
            else
            {

            }

            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");

            return RedirectToAction(nameof(CustomerArts));
        }
        // GET: ArtWorks/Edit/5
        [Authorize(Roles = "User")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artWorks = await _context.ArtWorks.FindAsync(id);
            if (artWorks == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryName", "CategoryName", artWorks.CategoryId);
            return View(artWorks);
        }

        // POST: ArtWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtId,ArtPrice,ImageName,Title,Description,CategoryId,OrderId,ArtistFname,ArtistLname,Quantity,ImageFile")] ArtWorks artWorks)
        {
            if (id != artWorks.ArtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (artWorks.ImageFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + artWorks.ImageFile.FileName;
                        string extension = Path.GetExtension(artWorks.ImageFile.FileName);
                        string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await artWorks.ImageFile.CopyToAsync(fileStream);
                        }
                        artWorks.ImageName = fileName;
                    }
                    _context.Update(artWorks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtWorksExists(artWorks.ArtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CustomerArts));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryName", "CategoryName", artWorks.CategoryId);
            return RedirectToAction(nameof(CustomerArts));
        }

        // POST: ArtWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artWorks = await _context.ArtWorks.FindAsync(id);
            _context.ArtWorks.Remove(artWorks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CustomerArts));
        }

        private bool ArtWorksExists(int id)
        {
            return _context.ArtWorks.Any(e => e.ArtId == id);
        }

        public async Task<ActionResult> Logout()
        {
            var user = _context.Users.Where(x => x.UserId == HttpContext.Session.GetInt32(id)).FirstOrDefault();
            if (user.RoleId == 3)
            {
                DateTime today = DateTime.Now;
                var attendance = _context.Attendance.Where(x => x.UserId == HttpContext.Session.GetInt32(id) && x.DateOfDay == today.ToShortDateString()).FirstOrDefault();
                attendance.EndTime = DateTime.Now.ToShortTimeString();
                _context.Attendance.Update(attendance);
                await _context.SaveChangesAsync();
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                HttpContext.Session.Clear();
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Home", "Home");
            }

        }

    }
}
