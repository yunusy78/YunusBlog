using System.Text;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogWeb.Controllers;

public class NewsletterApiController : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://localhost:7093/api/NewsletterApi");
        var result = await response.Content.ReadAsStringAsync();
        var newslettersList = JsonConvert.DeserializeObject<List<Newsletter>>(result);
        return View(newslettersList );
        
    }
    
    public  IActionResult AddNewsletter()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewsletter(Newsletter newsletter)
    {
        var client = new HttpClient();
        var stringContent = new StringContent(JsonConvert.SerializeObject(newsletter),Encoding.UTF8,"application/json");
        var response = await client.PostAsync("https://localhost:7093/api/NewsletterApi",stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
        
    }
    
    public async Task<IActionResult> EditNewsletter(Guid id)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://localhost:7093/api/NewsletterApi/{id}");
        var result = await response.Content.ReadAsStringAsync();
        var newsletter = JsonConvert.DeserializeObject<Newsletter>(result);
        return View(newsletter);
    }
    
    [HttpPost]
    public async Task<IActionResult> EditNewsletter(Newsletter newsletter)
    {
        var client = new HttpClient();
        var stringContent = new StringContent(JsonConvert.SerializeObject(newsletter),Encoding.UTF8,"application/json");
        var response = await client.PutAsync("https://localhost:7093/api/NewsletterApi",stringContent);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
    
    public async Task<IActionResult> DeleteNewsletter(Guid id)
    {
        var client = new HttpClient();
        var response = await client.DeleteAsync($"https://localhost:7093/api/NewsletterApi/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
    
}