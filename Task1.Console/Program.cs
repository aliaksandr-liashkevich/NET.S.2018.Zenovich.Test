using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task1.Solution.Api;
using Task1.Solution.Repositories;
using Task1.Solution.Services;
using Task1.Solution.ViewModels;

using SysConsole = System.Console;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ISqlRepository repository = new SqlRepositoryStub();
            IPasswordCheckerService service = new PasswordCheckerService(repository);

            var result = service.VerifyPassword(new User
            {
                Password = "12322222A"
            });

            SysConsole.WriteLine($"Result: {result.Item1}, Message: {result.Item2}");

            SysConsole.ReadKey();
        }
    }
}
