using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyService.DataAccess.Providers.Contract;
using PharmacyService.Infrastructure.Encryption;
using PharmacyService.Infrastructure.Response;
using PharmacyService.Models.API.Request.Management;
using PharmacyService.Models.API.Response.Management;
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
    public class ManagementController : BaseController
    {        

        private readonly IMapper mapper;
        private readonly IServicesDataProvider _servicesDataProvider;
        private readonly IEncryption _encryption;

        public ManagementController( IMapper mapper, IServicesDataProvider servicesDataProvider, IEncryption encryption) : base(mapper)
        {
            
            this.mapper = mapper;
            _servicesDataProvider = servicesDataProvider;
            _encryption = encryption;
        }

        #region Customer
        [HttpPost]
        [Route("management/customer/manage")]
        public async Task<ResponseBuilder> CustomerManage(CustomerRequest request)
        {
            try
            {
                var validationList = new List<string>();
                if (request.Name == null)
                    validationList.Add("First name required");
              //  if (request.lastName == null)
                  //  validationList.Add("Last name required");
                if (request.phoneNumber == null)
                    validationList.Add("Phone number required");
                validationList.AddRange(await _servicesDataProvider.User.ValidUserId(request.modifiedBy));
                if (validationList.Count==0)
                {
                    if (request.id == 0)
                    {
                        await _servicesDataProvider.Customer.Add(mapper.Map<Customer>(request));
                    }
                    else
                    {
                        await _servicesDataProvider.Customer.Update(_mapper.Map<Customer>(request));
                    }
                    return ResponseBuilder.Create(HttpStatusCode.OK);
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validationList);

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/customer/getall")]
        public async Task<ResponseBuilder> CustomerGetAll()
        {
            try
            {
                var result = await _servicesDataProvider.Customer.GetAll(filter: x=>!x.isDeleted);
                if (result!=null && result.Count()>0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CustomerRequest>>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/customer/get")]
        public async Task<ResponseBuilder> CustomerGetById(int id)
        {
            try
            {
                var result = await _servicesDataProvider.Customer.Get(id);
                if (result!=null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<CustomerRequest>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/customer/search")]
        public async Task<ResponseBuilder> CustomerSearch( string request)
        {
            try
            {
                var result = await _servicesDataProvider.Customer.GetAll(filter: x => !x.isDeleted);
                if (result != null && result.Count() > 0)
                {
                    
                    int i = 0;
                    var customers = new List<Customer>();
                    if (int.TryParse(request, out i))
                    {
                        customers =  result.Where(x => (x.id == i) || x.phoneNumber== request).ToList();
                    }
                    else
                        customers = result.Where(x => x.Name.Contains(request)).ToList();

                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<CustomerRequest>>(customers));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }


        #endregion

        #region Supplier

        [HttpPost]
        [Route("management/supplier/manage")]
        public async Task<ResponseBuilder> SupplierManage(SupplierRequest request)
        {
            try
            {
                var validationList = new List<string>();
                if (request.name == null)
                    validationList.Add("First name required");                
                if (request.phoneNumber == null)
                    validationList.Add("Phone number required");
                validationList.AddRange(await _servicesDataProvider.User.ValidUserId(request.modifiedBy));
                if (validationList.Count==0)
                {
                    if (request.id == 0)
                    {
                        await _servicesDataProvider.Supplier.Add(mapper.Map<Supplier>(request));
                    }
                    else
                    {
                        await _servicesDataProvider.Supplier.Update(mapper.Map<Supplier>(request));
                    }
                    return ResponseBuilder.Create(HttpStatusCode.OK);
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validationList);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/supplier/getall")]
        public async Task<ResponseBuilder> SupplierGetAll()
        {
            try
            {
                var result = await _servicesDataProvider.Supplier.GetAll(filter: x => !x.isDeleted);
                if (result != null && result.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<SupplierRequest>>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/supplier/get")]
        public async Task<ResponseBuilder> SupplierGetById(int id)
        {
            try
            {
                var result = await _servicesDataProvider.Supplier.Get(id);
                if (result != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<SupplierRequest>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        #endregion

        #region User

        [HttpPost]
        [Route("management/user/create")]
        public async Task<ResponseBuilder> UserCreate(UserRequest request)
        {
            try
            {
                var validationList = new List<string>();
                if (!_servicesDataProvider.User.IsValidEmail(request.email)&&request.email!=null)
                    validationList.Add("Invalid user email");
                validationList.AddRange(_servicesDataProvider.User.ValidatePassword(request.password));
                if(request.firstName==null)
                    validationList.Add("First name is required");
                if(request.lastName==null)
                    validationList.Add("Last name is required");
                if(request.phoneNumber==null)
                    validationList.Add("Phone number is required");
                validationList.AddRange(await _servicesDataProvider.User.ValidUserId(request.createdBy));
                if (validationList.Count==0)
                {
                    if (request.id == 0)
                    {
                        request.password = _encryption.Encrypt(request.password);
                        await _servicesDataProvider.User.Add(mapper.Map<User>(request));
                    }

                    return ResponseBuilder.Create(HttpStatusCode.OK);
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validationList);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
        [HttpPost]
        [Route("management/user/manage")]
        public async Task<ResponseBuilder> UserManage(UpdateUserRequest request)
        {
            try
            {
                var validationList = new List<string>();                
                if (request.firstName == null)
                    validationList.Add("First name is required");
                if (request.lastName == null)
                    validationList.Add("Last name is required");
                if (request.phoneNumber == null)
                    validationList.Add("Phone number is required");
                validationList.AddRange(await _servicesDataProvider.User.ValidUserId(request.modifiedBy));
                if (validationList.Count==0)
                {
                    await _servicesDataProvider.User.Update(mapper.Map<User>(request));
                    return ResponseBuilder.Create(HttpStatusCode.OK);
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validationList);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/user/getall")]
        public async Task<ResponseBuilder> UserGetAll()
        {
            try
            {
                var result = await _servicesDataProvider.User.GetAll(filter: x => !x.isDeleted);
                if (result != null && result.Count() > 0)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<List<UserResponse>>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });

            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpGet]
        [Route("management/user/get")]
        public async Task<ResponseBuilder> UserGetById(int id)
        {
            try
            {
                var result = await _servicesDataProvider.User.Get(id);
                if (result != null)
                {
                    return ResponseBuilder.Create(HttpStatusCode.OK, _mapper.Map<UserResponse>(result));
                }
                return ResponseBuilder.Create(HttpStatusCode.NotFound, new { status = false }, new string[] { "No records" });
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }
        #endregion
        #region Authentication
        [HttpPost]
        [Route("management/user/login")]
        public async Task<ResponseBuilder> LogIn(LogInRequest user)
        {
            try
            {
                var logInResponse = new LogInUserResponse();
                var validationList = new List<string>();
                if (string.IsNullOrEmpty(user.email))
                    validationList.Add("email is required");
                if (string.IsNullOrEmpty(user.password))
                    validationList.Add("Password is required");
                if (!_servicesDataProvider.User.IsValidEmail(user.email) && user.email != null)
                    validationList.Add("Invalid user email");
                if (validationList.Count == 0)
                {
                    var response = (await _servicesDataProvider.User.GetAll(filter: x => !x.isDeleted && x.email == user.email)).FirstOrDefault();
                    if (response != null)
                    {
                        if (!response.isActive)
                            return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "User is not active" });
                        if (_encryption.Encrypt(user.password) == response.password)
                        { 
                            logInResponse.email = response.email;
                            logInResponse.id = response.id;
                            logInResponse.firstName = response.firstName;
                            return ResponseBuilder.Create(HttpStatusCode.OK, logInResponse);
                        }
                        return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "Wrong password"});
                    }
                    
                    return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { "Not found user" });
                }
                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, validationList);
            }
            catch (Exception ex)
            {

                return ResponseBuilder.Create(HttpStatusCode.InternalServerError, new { status = false }, new string[] { ex.Message });
            }
        }

        [HttpPost]
        [Route("management/user/password")]
        public string Password(string pass)
        {
            return _encryption.Encrypt(pass);
        }

        #endregion
    }
}
