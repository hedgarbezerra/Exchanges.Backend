using Hedgar.Exchanges.Backend.Domain.Models;
using Hedgar.Exchanges.Backend.Repository.Context.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hedgar.Exchanges.Backend.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=connectionString")
        {

        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ErrorLogConfiguration());
        }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
