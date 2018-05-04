using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution.Api;

namespace Task1.Solution.Repositories
{
    public class SqlRepositoryStub : ISqlRepository
    {
        private List<string> passwords;

        public SqlRepositoryStub()
        {
            passwords = new List<string>();
        }

        public void Create(string password)
        {
            passwords.Add(password);
        }
    }
}
