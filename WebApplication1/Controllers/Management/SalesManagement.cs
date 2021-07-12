using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.DataAccess.Providers.Contract;
using PharmacyService.DataAccess.Providers.Services;
using PharmacyService.Infrastructure.Response;
using PharmacyService.Models.API.Request.SalesManagement;
using PharmacyService.Models.API.Request.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.ServiceConfig.Security;

namespace WebApplication1.Controllers.Management
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class SalesManagement : BaseController
    {
        private readonly IMapper _imapper;
        private readonly IProductManagementDataProvider _productManagementDataProvider;
       

        public SalesManagement(IMapper imapper, IProductManagementDataProvider productManagement ) :base(imapper)
        {
            _imapper = imapper;
            _productManagementDataProvider = productManagement;
            
        }
        [HttpGet]
        [Route("management/sales/productsin")]
        public async Task<ResponseBuilder> ProductsInPharmacy()
        {
            try
            {
                var prods = await _productManagementDataProvider.ProductToSell.GetAll(filter: p => !p.isDeleted);
                var ids = prods.GroupBy(p => p.productId).Select(p => new { product= p.Key,count= p.Sum(x=>x.items)}).ToList();

                List<object> response = new List<object>();
                Product p = new Product();
                foreach (var item in ids)
                {
                    p = (await _productManagementDataProvider.Product.Get(item.product));
                    response.Add(new { product =p.englishName,  count=item.count/ (float)p.smallUnits });
                }

                return ResponseBuilder.Create(HttpStatusCode.OK, response);
            }

            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }

        }

        [HttpPost]
        [Route("management/sales/inventory")]
        public async Task<ResponseBuilder> Inventory(InventoryRequest request)
        {
            try
            {
                if (request!=null)
                {
                    var response = await _productManagementDataProvider.ProductToSell.Inventory(request);
                    return ResponseBuilder.Create(HttpStatusCode.OK, response);
                }
                return ResponseBuilder.Create(HttpStatusCode.BadRequest, new { status = false }, new string[] { "Bad request" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }


        [HttpPost]
        [Route("management/sales/productsearch")]
        public async Task<ResponseBuilder> ProductSearch([FromBody] string filter)
        {
            try
            {
                int i = 0;
                if (int.TryParse(filter, out i))
                {
                    var result = await _productManagementDataProvider.ProductToSell.GetProductsMatchId(i);
                    return ResponseBuilder.Create(HttpStatusCode.OK, result);
                }
                else
                {
                    var result = await _productManagementDataProvider.ProductToSell.GetProductsMatchName(filter);
                    return ResponseBuilder.Create(HttpStatusCode.OK, result);
                }

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
    }
}
