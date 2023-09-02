﻿using CNPM_ktxUtc2Store.Dto;
using CNPM_ktxUtc2Store.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CNPM_ktxUtc2Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeService homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult>Index(string sTerm="",int categoryId=0)
        {
            IEnumerable<product> products= await _homeRepository.GetProduct(sTerm,categoryId);
            IEnumerable<category> categories = await _homeRepository.Categories();
            var productDisplayModel = new productDisplayModel
            {
                products = products,
                categories = categories,
                sTerm=sTerm,
                categoryId=categoryId
            };
            return View(productDisplayModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}