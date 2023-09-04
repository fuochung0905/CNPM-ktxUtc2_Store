using Microsoft.AspNetCore.Mvc;

namespace CNPM_ktxUtc2Store.Controllers
{
    public class CartController : Controller
    {
        public IActionResult AddItem(int productId, int quantity=1)
        {
            return View();
        }
        public IActionResult Remove(int productId)
        {
            return View();
        }
        public IActionResult GetUserCart()
        {
            return View();
        }
        public IActionResult GetTotalItemInCart()
        {
            return View();
        }

    }
}
