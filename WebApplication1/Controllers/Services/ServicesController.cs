using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.DataAccess.Providers.Contract;
using PharmacyService.Infrastructure.Response;
using PharmacyService.Models.API.Request.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.ServiceConfig.Security;

namespace WebApplication1.Controllers.Services
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class ServicesController : BaseController
    {
        private readonly IProductManagementDataProvider _productManagement;
        private readonly IUnitsDataProvider _unitsDataProvider;
        
        private readonly IMapper mapper;

        public ServicesController(IProductManagementDataProvider productManagement, IUnitsDataProvider unitsDataProvider, IMapper mapper):base(mapper)
        {
            _productManagement = productManagement;
            _unitsDataProvider = unitsDataProvider;
            
            this.mapper = mapper;
        }
        #region Product
        [HttpGet]
        [Route("servises/product/getall")]
        public async Task<ResponseBuilder> GetAllProducts()
        {
            try
            {
                var allProducts= await _productManagement.Product.GetAll(filter: (x => !(x.isDeleted)));
                if (allProducts!=null&&allProducts.Count()>0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ProductRequest>>(allProducts));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/product/search")]
        public async Task<ResponseBuilder> ProductSearch(string filter)
        {
            try
            {
                var result = await _productManagement.Product.Search(filter);
                if (result!=null&&result.Count()>0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ProductRequest>>(result));

                }
                return ResponseBuilder.Create(HttpStatusCode.OK, new { status = false }, new string[] { "No product match" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
       
        [HttpPost]
        [Route("servises/product/manage")]
        public async Task<ResponseBuilder> ProductManage(ProductRequest request)
        {
            try
            {
                if (request.id==0)
                {
                    await _productManagement.Product.Add(mapper.Map<Product>(request));
                }
                else
                {
                    await _productManagement.Product.Update(mapper.Map<Product>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
        #endregion
        #region DosageForm
        [HttpGet]
        [Route("servises/dosageform/getall")]
        public async Task<ResponseBuilder> GetAllDosageForm()
        {
            try
            {
                var allDosageForm = await _unitsDataProvider.DosageForm.GetAll(filter: (x => !(x.isDeleted)));
                if (allDosageForm != null && allDosageForm.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<DosageFormRequest>>(allDosageForm));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/dosageform/get")]
        public async Task<ResponseBuilder> DosageFormGetById(int id)
        {
            try
            {
                var allDosageForm = await _unitsDataProvider.DosageForm.Get(id);
                if (allDosageForm != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<DosageFormRequest>>(allDosageForm));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("servises/dosageform/manage")]
        public async Task<ResponseBuilder> DosageFormManage(DosageFormRequest request)
        {
            try
            {
                if (request.id == 0)
                {
                    await _unitsDataProvider.DosageForm.Add(mapper.Map<DosageForm>(request));
                }
                else
                {
                    await _unitsDataProvider.DosageForm.Update(mapper.Map<DosageForm>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion
        #region LargeUnits

        [HttpGet]
        [Route("servises/largeunits/getall")]
        public async Task<ResponseBuilder> GetAllLargeUnitsTypes()
        {
            try
            {
                var allLargeUnitsTypes = await _unitsDataProvider.LargeUnitType.GetAll(filter: (x => !(x.isDeleted)));
                if (allLargeUnitsTypes != null && allLargeUnitsTypes.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<LargeUnitRequest>>(allLargeUnitsTypes));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/largeunits/get")]
        public async Task<ResponseBuilder> LargeUnitsTypesGetById(int id)
        {
            try
            {
                var allLargeUnitsTypes = await _unitsDataProvider.LargeUnitType.Get(id);
                if (allLargeUnitsTypes != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<LargeUnitRequest>>(allLargeUnitsTypes));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("servises/largeunit/manage")]
        public async Task<ResponseBuilder> LargeUnitManage(LargeUnitRequest request)
        {
            try
            {
                if (request.id == 0)
                {
                    await _unitsDataProvider.LargeUnitType.Add(mapper.Map<LargeUnitType>(request));
                }
                else
                {
                    await _unitsDataProvider.LargeUnitType.Update(mapper.Map<LargeUnitType>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion
        #region SmallUnits

        [HttpGet]
        [Route("servises/smallunits/getall")]
        public async Task<ResponseBuilder> GetAllSmallUnitsTypes()
        {
            try
            {
                var allSmallUnitsTypes = await _unitsDataProvider.SmallUnitType.GetAll(filter: (x => !(x.isDeleted)));
                if (allSmallUnitsTypes != null && allSmallUnitsTypes.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<SmallUnitRequest>>(allSmallUnitsTypes));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/smallunits/get")]
        public async Task<ResponseBuilder> SmallUnitsTypesGetById(int id)
        {
            try
            {
                var allSmallUnitsTypes = await _unitsDataProvider.SmallUnitType.Get(id);
                if (allSmallUnitsTypes != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<SmallUnitRequest>>(allSmallUnitsTypes));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("servises/smallunit/manage")]
        public async Task<ResponseBuilder> SmallUnitManage(SmallUnitRequest request)
        {
            try
            {
                if (request.id == 0)
                {
                    await _unitsDataProvider.SmallUnitType.Add(mapper.Map<SmallUnitType>(request));
                }
                else
                {
                    await _unitsDataProvider.SmallUnitType.Update(mapper.Map<SmallUnitType>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion
        #region Classification

        [HttpGet]
        [Route("servises/classification/getall")]
        public async Task<ResponseBuilder> GetAllClassification()
        {
            try
            {
                var allClassification = await _unitsDataProvider.Classification.GetAll(filter: (x => !(x.isDeleted)));
                if (allClassification != null && allClassification.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ClassificationRequest>>(allClassification));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/classification/get")]
        public async Task<ResponseBuilder> ClassificationGetById(int id)
        {
            try
            {
                var allClassification = await _unitsDataProvider.Classification.Get(id);
                if (allClassification != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ClassificationRequest>>(allClassification));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("servises/classification/manage")]
        public async Task<ResponseBuilder> ClassificationManage(ClassificationRequest request)
        {
            try
            {
                if (request.id == 0)
                {
                    await _unitsDataProvider.Classification.Add(mapper.Map<Classification>(request));
                }
                else
                {
                    await _unitsDataProvider.Classification.Update(mapper.Map<Classification>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion
        #region ProductsCompany
        [HttpGet]
        [Route("servises/productscompany/getall")]
        public async Task<ResponseBuilder> GetAllProductsCompany()
        {
            try
            {
                var allProductsCompany = await _productManagement.ProductsCompany.GetAll(filter: (x => !(x.isDeleted)));
                if (allProductsCompany != null && allProductsCompany.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ProductsCompanyRequest>>(allProductsCompany));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("servises/productscompany/get")]
        public async Task<ResponseBuilder> ProductsCompanyGetById(int id)
        {
            try
            {
                var allClassification = await _productManagement.ProductsCompany.Get(id);
                if (allClassification != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, mapper.Map<List<ProductsCompanyRequest>>(allClassification));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "No data available" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("servises/productscompany/manage")]
        public async Task<ResponseBuilder> ProductsCompanyManage(ProductsCompanyRequest request)
        {
            try
            {
                if (request.id == 0)
                {
                    await _productManagement.ProductsCompany.Add(mapper.Map<ProductsCompany>(request));
                }
                else
                {
                    await _productManagement.ProductsCompany.Update(mapper.Map<ProductsCompany>(request));
                }
                return ResponseBuilder.Create(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
        #endregion
    }
}
