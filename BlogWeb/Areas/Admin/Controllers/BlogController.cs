using System.Text;
using Business.Concrete;
using ClosedXML.Excel;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
public class BlogController : Controller
{
    private readonly BlogManager _blogManager;
    private readonly Context _db;
    
    public BlogController(Context db)
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

            int blogRowCount = 2;
            foreach (var blog in _blogManager.GetAll())
            {
                worksheet.Cell(blogRowCount, 1).Value = blog.Id.ToString(); // Convert Guid to string
                worksheet.Cell(blogRowCount, 2).Value = blog.Title;
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


}