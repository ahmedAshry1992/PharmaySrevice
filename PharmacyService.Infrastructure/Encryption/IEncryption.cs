using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Infrastructure.Encryption
{
    public interface IEncryption
    {
        string Decrypt(string input);
        string Encrypt(string input);
    }
}
