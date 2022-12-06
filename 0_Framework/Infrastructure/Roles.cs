using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administator = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "3";
        public const string ColleagueUser = "4";

        public static string GetRoleBy(long roleId)
        {
            switch(roleId)
            {
                case 1:
                    return "مدیر سیستم";
                case 3:
                    return "محتوا گذار";
                default:
                    return " ";
            }
        }
    }
}
