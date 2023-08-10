using System.Text;
using Business.Concrete;
using ClosedXML.Excel;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class ReportController : Controller
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
    public ReportController(Context db)
    {
        _db = db;
        _blogManager = new BlogManager(new EfBlogRepository(_db));
    }
    
    // GET
    public IActionResult ExportStaticExcel()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Blog List");
            worksheet.Cell(1, 1).Value = "Blog Id";
            worksheet.Cell(1, 2).Value = "Blog Title";
            worksheet.Cell(1, 3).Value = "Blog Content";
            worksheet.Cell(1, 4).Value = "Blog CreatedAt";
            worksheet.Cell(1, 5).Value = "Blog CategoryId";
            worksheet.Cell(1, 6).Value = "Blog WriterId";

            int blogRowCount = 2;
            foreach (var blog in _blogManager.GetAll())
            {
                worksheet.Cell(blogRowCount, 1).Value = blog.Id.ToString(); // Convert Guid to string
                worksheet.Cell(blogRowCount, 2).Value = blog.Title;
                worksheet.Cell(blogRowCount, 3).Value = blog.Content;
                worksheet.Cell(blogRowCount, 4).Value = blog.CreatedAt.ToString();
                worksheet.Cell(blogRowCount, 5).Value = blog.CategoryId.ToString();
                worksheet.Cell(blogRowCount, 6).Value = blog.WriterId.ToString();
                blogRowCount++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BlogList.xlsx");
            }
        }
    }
    
    public IActionResult ExportStaticCsv()
    {
        return View();
    }
    
    
    public IActionResult ExportStaticExcelWriter()
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Writer List");
            worksheet.Cell(1, 1).Value = "Writer Id";
            worksheet.Cell(1, 2).Value = "Writer Name";
            worksheet.Cell(1, 3).Value = "Writer About";
            worksheet.Cell(1, 4).Value = "Writer Email";
            worksheet.Cell(1, 5).Value = "Writer CreatedAt";
            worksheet.Cell(1, 6).Value = "Writer ApplicationUSerId";

            int blogRowCount = 2;
            foreach (var writer in _db.Writers.ToList())
            {
                worksheet.Cell(blogRowCount, 1).Value = writer.Id.ToString(); // Convert Guid to string
                worksheet.Cell(blogRowCount, 2).Value = writer.Name;
                worksheet.Cell(blogRowCount, 3).Value = writer.About;
                worksheet.Cell(blogRowCount, 4).Value = writer.Email;
                worksheet.Cell(blogRowCount, 5).Value = writer.CreatedAt.ToString();
                worksheet.Cell(blogRowCount, 6).Value = writer.ApplicationUserId;
                blogRowCount++;
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "WriterList.xlsx");
            }
        }
    }


}