﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bulletin.Services.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> SendOtpCodeAsync(string phoneNumber);
        Task<double> GetCurrentPayRateAsync();
        Task<bool> VerifyOtpCodeAsync(string code);
    }
}
