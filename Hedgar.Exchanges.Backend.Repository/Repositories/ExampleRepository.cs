using Hedgar.Exchanges.Backend.Domain.Business;
using Hedgar.Exchanges.Backend.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Backend.Repository.Repositories
{
    public class ExampleRepository : BaseRepository<ExampleClass>
    {
        public ExampleRepository(DataContext context = null) : base(context)
        {
        }
    }
}
