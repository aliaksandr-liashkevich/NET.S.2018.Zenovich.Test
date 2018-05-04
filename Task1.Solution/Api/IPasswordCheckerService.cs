using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution.ViewModels;

namespace Task1.Solution.Api
{
    public interface IPasswordCheckerService
    {
        Tuple<bool, string> VerifyPassword(User vm);
    }
}
