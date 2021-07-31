using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.DataAccess.Providers.Contract;
using PharmacyService.Infrastructure.Response;
using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.API.Response.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.ServiceConfig.Security;

namespace WebApplication1.Controllers.Invoices
{
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1.0")]
    public class InvoiceController : BaseController
    {
        private readonly IInvoicesDataProvider _invoicesDataProvider;
        private readonly IProductManagementDataProvider _productManagementDataProvider;
        private readonly IServicesDataProvider _servicesDataProvider;

        public InvoiceController(IInvoicesDataProvider invoicesDataProvider, IProductManagementDataProvider productManagementDataProvider, IServicesDataProvider servicesDataProvider, IMapper mapper) :base(mapper)
        {
            _invoicesDataProvider = invoicesDataProvider;
            _productManagementDataProvider = productManagementDataProvider;
            _servicesDataProvider = servicesDataProvider;
        }

        #region PurchaceInvoice
        [HttpPost]
        [Route("invoice/purchase/add")]
        public async Task<ResponseBuilder> CreatePuchaceInvoice(CreatePuchaceInvoice request)
        {
            try
            {
                var validations = await _invoicesDataProvider.PurchaceInvoice.ValidatePurchaseInvoiceRequest(request);
                validations.AddRange(await _servicesDataProvider.User.ValidUserId(request.createdBy));
                if (validations.Count == 0)
                {
                    var id = await _invoicesDataProvider.PurchaceInvoice.AddGetId(_mapper.Map<PurchaceInvoice>(request));
                    var ids= await _invoicesDataProvider.PurchaceInvoiceDetails.AddManyItems(id, request.createdBy, _mapper.Map<List<PurchaceInvoiceDetails>>(request.purchaces));
                    var respose = await _productManagementDataProvider.ProductToSell.AddProductsFromPurInv(ids, request.createdBy);

                    return ResponseBuilder.Create(HttpStatusCode.OK,_mapper.Map<List<ProductToSellResponse>>(respose));
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validations);
            }
            catch (Exception ex)
            {

               return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }

        }

        [HttpGet]
        [Route("invoice/purchase/getall")]
        public async Task<ResponseBuilder> GetAllPuchaceInvoice()
        {
            try
            {
                var invoices = await _invoicesDataProvider.PurchaceInvoice.GetAll(filter: x => !x.isDeleted);
                if (invoices!=null&&invoices.Count()!=0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<PurchaceInvioceResponse>>(invoices));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("invoice/purchase/filter")]
        public async Task<ResponseBuilder> FilterPuchaceInvoice(PurchaceInvoiceFilterRequest request)
        {
            try
            {
                var response = await _invoicesDataProvider.PurchaceInvoice.GetPurchaceInvoiceByFilter(request);
                if (response!=null && response.Count()!=0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<PurchaceInvioceResponse>>(response));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoice/purchasedetails/get")]
        public async Task<ResponseBuilder> PuchaceInvoiceDetails(int id)
        {
            try
            {
                var response = await _invoicesDataProvider.PurchaceInvoiceDetails.GetInvoiceDetails(id);
                if (response!=null && response.Count()>0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<PurchaceInvoiceDetailsResponse>>(response));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion

        #region SalesInvoice

        [HttpPost]
        [Route("invoice/sales/add")]
        public async Task<ResponseBuilder> CreateSalesInvoice(CreateSalesInvoice request)
        {
            try
            {
                
                
                    var validations = await _invoicesDataProvider.Invoice.ValidateInvoiceRequest(request);
                    validations.AddRange(await _servicesDataProvider.User.ValidUserId(request.userId));
                    if (validations.Count == 0)
                    {
                        var id = await _invoicesDataProvider.Invoice.AddGetId(_mapper.Map<Invoice>(request));
                        var response = await _invoicesDataProvider.InvoiceDetails.SaveItems(id, request.userId, _mapper.Map<List<InvoiceDetails>>(request.salesProducts));

                        return ResponseBuilder.Create(HttpStatusCode.OK, response);
                    }

                    return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validations);
                
                     
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("invoice/sales/edit")]
        public async Task<ResponseBuilder> EditSalesInvoice(EditSalesInvoiceRequest request)
        {
            try
            {
                if (request.salesInvoiceRequest.id != 0)
                {
                    var result = await _invoicesDataProvider.InvoiceDetails.AddManyItems(request.salesInvoiceRequest.id, request.salesInvoiceRequest.userId, _mapper.Map<List<InvoiceDetails>>(request.salesInvoiceRequest.salesProducts));
                    var response = new InvoiceEditResponse() { id = result, invoiceId = request.salesInvoiceRequest.id };
                    return ResponseBuilder.Create(HttpStatusCode.OK, response);
                }
                else
                {
                    var id = await _invoicesDataProvider.Invoice.AddGetId(_mapper.Map<Invoice>(request.salesInvoiceRequest));
                    var result = await _invoicesDataProvider.InvoiceDetails.AddManyItems(id, request.salesInvoiceRequest.userId, _mapper.Map<List<InvoiceDetails>>(request.salesInvoiceRequest.salesProducts));
                    var response = new InvoiceEditResponse() { id = result, invoiceId = id };
                    return ResponseBuilder.Create(HttpStatusCode.OK, response);
                }
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoice/sales/getall")]
        public async Task<ResponseBuilder> GetAllSalesInvoice()
        {
            try
            {
                var invoices = await _invoicesDataProvider.Invoice.GetAll(filter: x => !x.isDeleted);
                if (invoices != null && invoices.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<SalesInvioceResponse>>(invoices));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("invoice/sales/filter")]
        public async Task<ResponseBuilder> FilterSalesInvoice(SalesInvoiceFilterRequest request)
        {
            try
            {
                var response = await _invoicesDataProvider.Invoice.GetSalesInvoiceByFilter(request);
                if (response != null && response.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<SalesInvioceResponse>>(response));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoice/salesdetails/get")]
        public async Task<ResponseBuilder> SalesInvoiceDetails(int id)
        {
            try
            {
                var response = await _invoicesDataProvider.InvoiceDetails.GetInvoiceDetails(id);
                if (response != null && response.Count() > 0)
                {
                    var result = _mapper.Map<List<SalesInvoiceDetailsResponse>>(response);
                    foreach (var item in result)
                    {
                        item.productId = (await _productManagementDataProvider.ProductToSell.Get(item.productToSellId)).productId;
                    }
                    return ResponseBuilder.Create(HttpStatusCode.OK, result);
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion

        #region ReturnedInvoice

        [HttpPost]
        [Route("invoice/return/add")]
        public async Task<ResponseBuilder> CreateReturnInvoice(CreateReturnInvoice request)
        {
            try
            {
                var validations=(await _servicesDataProvider.User.ValidUserId(request.createdBy));
                if (validations.Count == 0)
                {
                    var id = await _invoicesDataProvider.ReturnedInvoice.AddGetId(_mapper.Map<ReturnedInvoice>(request));
                    await _invoicesDataProvider.ReturnedInvoiceDetails.AddManyItems(id, request.createdBy, _mapper.Map<List<ReturnedInvoiceDetails>>(request.productsToReturn));
                    return ResponseBuilder.Create(HttpStatusCode.OK);
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validations);

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoice/returnedinvoice/getall")]
        public async Task<ResponseBuilder> GetAllReturnedInvoice()
        {
            try
            {
                var invoices = await _invoicesDataProvider.ReturnedInvoice.GetAll(filter: x => !x.isDeleted);
                if (invoices != null && invoices.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<ReturnedInvioceResponse>>(invoices));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("invoice/returned/filter")]
        public async Task<ResponseBuilder> FilterReturnedInvoice(ReturnedInvoiceFilterRequest request)
        {
            try
            {
                var response = await _invoicesDataProvider.ReturnedInvoice.GetReturnedInvoiceByFilter(request);
                if (response != null && response.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<ReturnedInvioceResponse>>(response));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoice/returneddetails/get")]
        public async Task<ResponseBuilder> ReturnedInvoiceDetails(int id)
        {
            try
            {
                var response = await _invoicesDataProvider.ReturnedInvoiceDetails.GetReturnedInvoiceDetails(id);
                if (response != null && response.Count() > 0)
                {
                    var result = _mapper.Map<List<ReturnedInvoiceDetailsResponse>>(response);
                    foreach (var item in result)
                    {
                        item.productToSellId = (await _invoicesDataProvider.InvoiceDetails.Get(item.invoiceDetailsId)).productToSellId;
                        item.productId = (await _productManagementDataProvider.ProductToSell.Get(item.productToSellId)).productId;
                    }
                    return ResponseBuilder.Create(HttpStatusCode.OK,result );
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion

        #region InvoiceType&Status
        [HttpGet]
        [Route("invoicetypes/sales/getall")]
        public async Task<ResponseBuilder> GetAllSalesInvoiceTypes()
        {
            try
            {
                var invoices = await _invoicesDataProvider.InvoiceType.GetAll(filter: x => !x.isDeleted);
                if (invoices != null && invoices.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<InvoiceTypesResponse>>(invoices));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("invoicestatus/sales/getall")]
        public async Task<ResponseBuilder> GetAllSalesInvoiceStatus()
        {
            try
            {
                var invoices = await _invoicesDataProvider.InvoiceStatus.GetAll(filter: x => !x.isDeleted);
                if (invoices != null && invoices.Count() != 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<InvoiceStatusResponse>>(invoices));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "There are no records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion
    }
}
