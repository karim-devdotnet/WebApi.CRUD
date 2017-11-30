using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace WebApi.CRUD.Models
{
    public class ValueContext : DbContext
    {
        public ValueContext() : base(nameOrConnectionString: "valueContext")
        {
            Database.SetInitializer<ValueContext>(new ValueDbInitializer());
        }


        public ValueContext(string connectionString):base(connectionString)
        {
            Database.SetInitializer<ValueContext>(new ValueDbInitializer());
        }

        public DbSet<Value> ValueSet { get; set; }
    }

    internal class ValueDbInitializer : CreateDatabaseIfNotExists<ValueContext>
    {
        protected override void Seed(ValueContext context)
        {
            try
            {
                List<string> values = new List<string> { "Value11", "Value12", "Value13", "Value14", "Value15", "Value16", "Value17", "Value18", "Value19" };

                foreach (var item in values)
                {
                    context.ValueSet.Add(new Value { Text = item });
                }

                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            base.Seed(context);
        }
    }

    public class Value
    {
        public Value()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }
}