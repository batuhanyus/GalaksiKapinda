using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Concrete
{
    public class MailVerificationService : IMailVerificationService
    {
        IMailVerificationRepository mailVerificationRepository;

        public MailVerificationService(IMailVerificationRepository repository)
        {
            mailVerificationRepository = repository;
        }

        public int Delete(MailVerification entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<MailVerification> GetAll()
        {
            throw new NotImplementedException();
        }

        public MailVerification GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public int Insert(MailVerification entity)
        {
            throw new NotImplementedException();
        }

        public int Update(MailVerification oldEntity, MailVerification newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
