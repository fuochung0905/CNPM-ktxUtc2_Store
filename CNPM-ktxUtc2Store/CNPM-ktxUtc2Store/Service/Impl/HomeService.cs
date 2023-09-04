﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CNPM_ktxUtc2Store.Service.Impl
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _dbcontext;
        public HomeService(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;

        }
        public async Task<IEnumerable<category>> Categories()
        {
            return await _dbcontext.categories.ToListAsync();
        }
        public async Task<IEnumerable<product>> GetProduct(string sterm = "", int categoryId = 0)
        {
            sterm = sterm.ToLower();

            IEnumerable<product> products = await (from product in _dbcontext.products
                                                   join category in _dbcontext.categories
                                                   on product.categoryId equals category.Id
                                                  where string.IsNullOrWhiteSpace(sterm) ||( product != null && product.productName.ToLower().StartsWith(sterm))
                                                   select new product
                                                   {
                                                       Id = product.Id,
                                                       productName = product.productName,
                                                       description = product.description,
                                                       discount = product.discount,
                                                       price = product.price,
                                                       categoryId=product.categoryId,
                                                       imageUrl = product.imageUrl,
                                                       categoryName = category.categoryName

                                                   }).ToListAsync();
            if (categoryId > 0)
            {
                products = products.Where(a => a.categoryId == categoryId).ToList();
            }
            return products;

        }
    }
}
