using Garvan.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garvan.Data.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailToSend emailToSend);
    }
}
