using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.CRUD.Models;

namespace WebApi.CRUD.Controllers
{
    public class ValuesController : ApiController
    {
        private ValueContext context = null;

        public ValuesController()
        {
            context = new ValueContext(); //ConfigurationManager.ConnectionStrings["valueContext"].ConnectionString
        }

        // GET api/values
        public IEnumerable<Value> Get()
        {
            return context.ValueSet;
        }

        // GET api/values/5
        public Value Get(Guid id)
        {
            return context.ValueSet.Find(id);
        }

        // POST api/values
        public void Post(string value)
        {
            context.ValueSet.Add(new Value { Text = value });
            context.SaveChanges();
        }

        // PUT api/values/5
        public void Put(Guid id, string value)
        {
            Value entity = context.ValueSet.Find(id);
            if (entity != null)
                entity.Text = value;
            else
                context.ValueSet.Add(new Value { Text = value });

            context.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(Guid id)
        {
            Value entity = context.ValueSet.Find(id);
            if(entity != null)
            {
                context.ValueSet.Remove(entity);
                context.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing && context != null)
            {
                context.Dispose();
                context = null;
            }

            base.Dispose(disposing);
        }
    }
}
