using Microsoft.AspNetCore.Mvc;
using SimpleSearchSite.Data;
using System.Text;


namespace SimpleSearchSite.Controllers;


public class HomeController : Controller
{
private readonly IItemRepository _repo;
public HomeController(IItemRepository repo) => _repo = repo;

// GET /Home/Index?q=search
public IActionResult Index(string? q)
{

string currentDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
string base64Date = Convert.ToBase64String(Encoding.UTF8.GetBytes(currentDate));
    Response.Cookies.Append("flag", base64Date, new CookieOptions
    {
        Expires = DateTimeOffset.UtcNow.AddDays(7),
        HttpOnly = false,
        Secure = false,
        SameSite = SameSiteMode.Strict
    });



var results = _repo.Search(q ?? string.Empty);
ViewData["Query"] = q ?? string.Empty;
return View(results);
}


public IActionResult About() => View();
}
