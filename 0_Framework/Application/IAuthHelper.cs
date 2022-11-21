using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public interface IAuthHelper
    {
        void Singout();
        bool IsAuthenticated();
        void Singin(AuthViewModel account);
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
    }
}
