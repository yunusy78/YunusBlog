using BlogWeb.Areas.Admin.Models;
using DataAccess.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Writer = Entity.Concrete.Writer;

namespace BlogWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize (Roles = "Admin")]
public class WriterController : Controller
{
    private readonly Context _db;
    public WriterController(Context db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    private static List<WriterClass> writers = new List<WriterClass>
    {
        new WriterClass { Id = 1, Name = "Yunus Emre" },
        new WriterClass { Id = 2, Name = "Kemal Sunal" },
        new WriterClass { Id = 3, Name = "Ali Veli" },
        new WriterClass { Id = 4, Name = "Merve" },
        new WriterClass { Id = 5, Name = "Zeynep" }
    };

    public IActionResult GetWriters()
    {
        
        var writer = _db.Writers.ToList();
        return Json(writer); 
    }
    
    public IActionResult GetWriterById(Guid id)
    {
       /* var writer = writers.FirstOrDefault(w => w.Id == id);
        if (writer != null)
        {
            return Json(writer);
        }
        return Json(new { error = "Writer not found" });*/
       
         var writer = _db.Writers.FirstOrDefault(x => x.Id == id);
            if (writer != null)
            {
                return Json(writer);
            }
            return Json(new { error = "Writer not found" });

    }
    
    [HttpPost]
    public IActionResult AddWriter(Writer writer)
    {
        writer.CreatedAt=DateTime.Now;
        _db.Writers.Add(writer);
        _db.SaveChanges();
        return Json(writer);
      
    }
    
    [HttpPost]
    public IActionResult UpdateWriter(Writer writer)
    {
        var writerToUpdate = _db.Writers.FirstOrDefault(x => x.Id == writer.Id);
        if (writerToUpdate != null)
        {
            writerToUpdate.Name = writer.Name;
            writerToUpdate.Email = writer.Email;
            writerToUpdate.About = writer.About;
            writerToUpdate.Password = writer.Password;
            writerToUpdate.Status = writer.Status;
            writerToUpdate.ApplicationUserId = writer.ApplicationUserId;
            _db.Writers.Update(writerToUpdate);
            _db.SaveChanges();
            return Json(writerToUpdate);
        }
        return Json(new { error = "Writer not found" });
    }
    
    [HttpPost]
    public IActionResult DeleteWriter(Guid id)
    {
        var writerToDelete = _db.Writers.FirstOrDefault(x => x.Id == id);
        if (writerToDelete != null)
        {
            _db.Writers.Remove(writerToDelete);
            _db.SaveChanges();
            return Json(writerToDelete);
        }
        return Json(new { error = "Writer not found" });
    }
    
    
}