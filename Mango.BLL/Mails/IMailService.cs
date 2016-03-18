using System.Collections.Generic;
using Mango.Common.Results;
using Mango.Entities.Domain;

namespace Mango.BLL.Mails
{
    public interface IMailService:IService
    {
      ServiceResult SendEmail(EmailItem email);
    }
}
