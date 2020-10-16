using Hedgar.Exchanges.Backend.Domain.Business;
using Hedgar.Exchanges.Backend.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Backend.Services.Hedgar.Exchanges.Backend.Services
{
    public class ExampleService
    {
        private ExampleRepository repo;

        public ExampleService()
        {
            repo = new ExampleRepository();
        }

        public void Add(ExampleClass example)
        {
            repo.Inserir(example);

            repo.Savechanges();
        }

        public List<ExampleClass> Listar()
        {
            return repo.Listar().ToList();
        }
    }
}
