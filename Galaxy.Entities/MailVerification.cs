using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities
{
    public sealed class MailVerification : BaseEntity
    {
        public int MemberID { get; set; }
        public string VerificatinCode { get; set; }
    }
}
