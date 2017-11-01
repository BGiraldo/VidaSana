using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Eam.Ingenieria.Matagym.Models
{
    public class PersonDb
    {
        private Entities db;

        public PersonDb()
        {
            db = new Entities();
        }

        public int cant()
        {
            return db.Persons.Count();
        }

        public void Delete(Person person)
        {
            db.Persons.Remove(person);
        }
    }
}