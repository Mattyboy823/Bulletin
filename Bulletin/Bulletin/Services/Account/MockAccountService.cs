using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bulletin.Services.Account
{
    public class MockAccountService :IAccountService
    {
        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10.0);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Task.FromResult(false);
            }
            return Task.Delay(1000).ContinueWith((task) => true);
        }

        Task<bool> IAccountService.SendOtpCodeAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAccountService.VerifyOtpCodeAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
