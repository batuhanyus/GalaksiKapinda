using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Galaxy.Entities.UserTypes;

namespace Galaxy.BusinessLogic.Concrete
{
    public class MemberService : IMemberService
    {
        IMemberRepository memberRepository;

        public MemberService(IMemberRepository repository)
        {
            memberRepository = repository;
        }

        public int Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        public Member DoLogin(string email, string password)
        {
            //TODO: Encrypt password.
            return memberRepository.GetAll().Where(a => a.Mail == email && a.Password == password).SingleOrDefault();
        }

        public ICollection<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public int Insert(Member entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
