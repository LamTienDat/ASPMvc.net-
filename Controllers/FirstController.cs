using System;
using System.IO;
using System.Linq;
using hello_asp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hello_asp.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
        public string Index() 
        {
        //    this.HttpContext
        // this.Request
        // this.Response
        // this.RouteData


        // this.User
        // this.ModelState
        // this.ViewData
        // this.ViewBag
        // this.Url
        // this.TempData
        _logger.LogInformation("Index Action");
        return "toi la index cua first";
        } 
        public void Nothing() 
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }
        public IActionResult Readme() 
        {
            var content = @"
            hjdhgbfdilf
            
            
            
            gedf
            gedfg
            fg
            d";
            return Content(content, "text/plain");
        }
        public IActionResult Haha() 
        {
            string filepath = Path.Combine(Startup.ContentRootPath, "Files", "haha.png");
            var bytes = System.IO.File.ReadAllBytes(filepath);
            return File(bytes, "image/png");
        }
        public IActionResult IphonePrice() 
        {
            return Json(
                new{
                        productName = "promax",
                        productPrice = 1000
                }
            );
                
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("chuyen huong den" + url);
            return LocalRedirect(url);
        }
        public IActionResult Google()
        {
            var url = "https://www.google.com/";
            _logger.LogInformation("chuyen huong den" + url);
            return Redirect(url);
        }
        public IActionResult HelloView(string username) 
        {
            if(string.IsNullOrEmpty(username)) 
            {
                username = "Guest";
            }
            // return View("xinchao2", username);
            // return View((object)username);
            return View("xinchao3", username);

            // truong hop pho bien 
            // View();
            //View(Modal);
        }
        public object Anything() => System.DateTime.Now;
        [TempData]
        public string StatusMessage{ get; set;}
        public IActionResult ViewProduct(int? id) 
        {
            var product = _productService.Where( p => p.Id == id).FirstOrDefault();
            // khi muon chuyen huong tu page nay sang page khac
            if (product == null)
            {
                StatusMessage = "san pham nay hien khong co";
                // TempData["StatusMessage"] = "san pham nay hien khong co";
                return Redirect(Url.Action("Index", "Home"));
            }
                //Model : cach 1
                //View/First/ViewProduct.cshtml
                //MyView/First/ViewProduct.cshtml
                // return View(product);

                //ViewData :  cach 2
            this.ViewData["product"] = product;
            ViewData["Title"] = product.Name;
            return View("ViewProduct2");
        }
    }
}