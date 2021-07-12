using AutoMapper;
using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.API.Request.Management;
using PharmacyService.Models.API.Request.Services;
using PharmacyService.Models.API.Response.Invoice;
using PharmacyService.Models.API.Response.Management;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ServiceConfig.Mapper
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<PurchaceaianvoiceModel, PurchaceInvoiceDetails>();
            CreateMap<CreatePuchaceInvoice, PurchaceInvoice>();
            CreateMap<ProductRequest, Product>();
            CreateMap<Product,ProductRequest >();
            CreateMap<SalesInvoiceModel, InvoiceDetails>();
            CreateMap<CreateSalesInvoice, Invoice>();
            CreateMap<ProductToReturn, ReturnedInvoiceDetails>();
            CreateMap<CreateReturnInvoice, ReturnedInvoice>();            
            CreateMap<DosageFormRequest, DosageForm>();
            CreateMap<DosageForm, DosageFormRequest>(); 
            CreateMap<LargeUnitRequest, LargeUnitType>();
            CreateMap<LargeUnitType, LargeUnitRequest>();
            CreateMap<SmallUnitRequest, SmallUnitType>();
            CreateMap<SmallUnitType, SmallUnitRequest>(); 
            CreateMap<ClassificationRequest, Classification>();
            CreateMap<Classification, ClassificationRequest>();
            CreateMap<CustomerRequest, Customer>();
            CreateMap<Customer, CustomerRequest>();
            CreateMap<SupplierRequest, Supplier>();
            CreateMap<Supplier, SupplierRequest>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
            CreateMap<UpdateUserRequest,User>();
            CreateMap<PurchaceInvoice, PurchaceInvioceResponse>();
            CreateMap<PurchaceInvoiceDetails, PurchaceInvoiceDetailsResponse>();
            CreateMap<Invoice, SalesInvioceResponse>();
            CreateMap<InvoiceDetails, SalesInvoiceDetailsResponse>();
            CreateMap<ReturnedInvoice, ReturnedInvioceResponse>();
            CreateMap<ReturnedInvoiceDetails, ReturnedInvoiceDetailsResponse>();
            CreateMap<User, UserResponse>();
            CreateMap<ProductsCompany,ProductsCompanyRequest>();
            CreateMap<ProductsCompanyRequest,ProductsCompany >();
            CreateMap<InvoiceType, InvoiceTypesResponse>();
            CreateMap<InvoiceStatus, InvoiceStatusResponse>();
            CreateMap<ProductToSell, ProductToSellResponse>();

        }
    }
}
