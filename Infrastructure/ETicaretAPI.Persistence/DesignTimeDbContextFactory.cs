using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ETicaretAPIDbContext>
    {
        

        public ETicaretAPIDbContext CreateDbContext(string[] args)//cmd veya powershell den Migration almak için gerekli izin  
        {
            DbContextOptionsBuilder<ETicaretAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
