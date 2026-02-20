using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
    }
}
