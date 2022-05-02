using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dominio;

namespace AgendaTarefas
{
    public class MyDBContext : DbContext
    {
        //const string ConnectionString = ;

        public MyDBContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }
        
        public static string GetConnectionString()
        {
           
            return ConfigurationManager.ConnectionStrings["sqlServerConnectionString"].ConnectionString;
        }

        public static MyDBContext Instance()
        {
            MyDBContext db = new MyDBContext(GetConnectionString());

            // Get the ObjectContext related to this DbContext
            var objectContext = (db as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 300;

            db.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
            return db;
        }

        public override int SaveChanges()
        {
            foreach (DbEntityEntry<CustomModel> entry in ChangeTracker.Entries<CustomModel>())
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.AntesAdicionar();
                else if (entry.State == EntityState.Modified)
                    entry.Entity.AntesAtualizar();
                entry.Entity.AntesSalvar();
            }
            return base.SaveChanges();
        }
    }
}