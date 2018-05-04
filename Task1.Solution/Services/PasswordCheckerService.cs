using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution.Api;
using Task1.Solution.ViewModels;

namespace Task1.Solution.Services
{
    class PasswordCheckerService : IPasswordCheckerService
    {
        private ISqlRepository _sqlRepository;

        public PasswordCheckerService(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        public Tuple<bool, string> VerifyPassword(User vm)
        {
            if (vm == null)
            {
                throw new ArgumentNullException($"{nameof(vm)} is null arg");
            }

            string password = vm.Password;

            if (password == null)
            {
                throw new ArgumentException($"{nameof(vm.Password)} is null arg");
            }

            if (password == string.Empty)
            {
                return Tuple.Create(false, $"{nameof(vm.Password)} is empty ");
            }
                
            // check if length more than 7 chars 
            if (password.Length <= 7)
            {
                return Tuple.Create(false, $"{nameof(vm.Password)} length too short");
            }
                
            // check if length more than 10 chars for admins
            if (vm.Role == Role.Admin && password.Length <= 10)
            {
                return Tuple.Create(false, $"{nameof(vm.Password)} length too long");
            }

            // check if password conatins at least one alphabetical character 
            if (password.Any(char.IsLetter) == false)
            {
                return Tuple.Create(false, $"{nameof(vm.Password)} hasn't alphanumerical chars");
            }

            // check if password conatins at least one digit character 
            if (password.Any(char.IsNumber) == false)
            {
                return Tuple.Create(false, $"{nameof(vm.Password)} hasn't digits");
            }
                
            _sqlRepository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }
    }
}
