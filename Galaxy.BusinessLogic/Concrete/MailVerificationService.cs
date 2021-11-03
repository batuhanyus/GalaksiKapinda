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
            return mailVerificationRepository.Delete(entity);
        }

        public ICollection<MailVerification> GetAll()
        {
            return mailVerificationRepository.GetAll();
        }

        public MailVerification GetByCode(string code)
        {
            try //I dare you !!
            {
                return mailVerificationRepository.GetAll().Where(a => a.VerificatinCode == code).Single();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MailVerification GetByID(int entityID)
        {
            try
            {
                return mailVerificationRepository.GetAll().Where(a => a.ID == entityID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(MailVerification entity)
        {
            if (entity.MemberID == 0)
                return 0;

            return mailVerificationRepository.Insert(entity);
        }

        public int Update(MailVerification oldEntity, MailVerification newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
