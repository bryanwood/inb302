using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFiles.Domain.Abstract
{
    public interface IEmailService
    {
        void SendEmail(string[] recipients, string message);
    }
}
