using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.API.Request.Management;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MiddlewareDbContext context;

        public UserRepository (MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public  List<string> ValidatePassword(string password)
        {
            try
            {
                List<string> messages = new List<string>();

                if (!password.Any(c => char.IsLetter(c)))
                    messages.Add("Password must contain characters.");

                if (!password.Any(c => char.IsDigit(c)))
                    messages.Add("Password must contain characters.");

                if (!password.Any(c => char.IsLower(c)))
                    messages.Add("Password must contain lower case char.");

                if (!password.Any(c => char.IsUpper(c)))
                    messages.Add("Password must contain upper case char.");


                if (password.Length < 8)
                    messages.Add("Password must be grater than or eqlal 8.");

                return messages;
            }
            catch (Exception ex)
            {
                return new List<string>() { ex.Message };
            }
        }

        public async Task<List<string>> ValidUserId(int id)
        {
            var errorMessages = new List<string>();
            if (!await context.Users.AnyAsync(x => x.id == id))
            {
                errorMessages.Add("Not exist user");
                return errorMessages;
            }
            if (!(await context.Users.FindAsync(id)).isActive)
                errorMessages.Add("User is blocked");
            if ((await context.Users.FindAsync(id)).isDeleted)
                errorMessages.Add("User is deleted");
            return errorMessages;


        }

        public async Task Update(User request)
        {
            var row = await context.Users.FindAsync(request.id);
            row.prancheId = request.prancheId;
            row.role = request.role;
            row.firstName = request.firstName;
            row.lastName = request.lastName;
            row.hireDate = request.hireDate;
            row.phoneNumber = request.phoneNumber;            
            row.modifiedAt = DateTime.Now;
            row.modifiedBy = request.modifiedBy;
        }
    }
}
