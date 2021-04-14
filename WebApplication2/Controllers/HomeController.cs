using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Api.Controllers
{
    //[Route("[controller]/[action]")] lets you do https://localhost:44399/home/index
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Test";
        }
    }
}
