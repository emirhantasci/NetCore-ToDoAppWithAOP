using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApp.Core.Helpers;
using TodoApp.Entities.Concrete;
using System;
using TodoApp.Core.Entities.Concrete;

namespace ToDoApp.DataAccess.Concrete.EntityFrw
{
    public class ToDoContext: Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            string useEncryption = CommonHelper.GetUseEncryptionFromRegistery();
            string toDoConnectionString = "";
            if (useEncryption == "1" || useEncryption == "2")
            {
                toDoConnectionString = CryptologyHelper.DecryptAES256(configuration.GetConnectionString("ToDoConnection"));
            }
            if (useEncryption == "0")
            {
                toDoConnectionString = configuration.GetConnectionString("ToDoConnection");
            }

            optionsBuilder.UseSqlServer(toDoConnectionString);

        }
        
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<ToDoGroups> ToDoGroups { get; set; }
        public DbSet<ToDoGroupElement> ToDoGroupElement { get; set; }

        public IConfiguration Configuration { get; private set; }

    }
}
