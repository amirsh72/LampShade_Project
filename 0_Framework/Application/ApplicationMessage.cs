using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class ApplicationMessage
    {
        public const string DuplicatedRecord = "امکان ثبت رکورد تکراری وجود ندارد";
        public const string RecordNotFound = "رکورد با اطلاعات درخواست شده یافت نشد";
        public const string PasswordNotMatch = "پسورد و تکرار آن با هم مطابقت ندارد";
        public const string WrongUserPass = "نام کاربری یا کلمه عبوراشتباه است";
    }
}
