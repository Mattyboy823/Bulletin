using Bulletin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bulletin.Services.Statement
{
    public interface IStatementService
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
        
    }
}
