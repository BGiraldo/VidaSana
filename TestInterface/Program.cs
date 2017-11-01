using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInterface.Tests;
using System.Data.SqlClient;

namespace TestInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            
            PeopleCreate people = new PeopleCreate();
            var personDocument = people.Create();

            Measurements m = new Measurements();
            m.Create(personDocument);

            Stage s = new Stage();
            s.Create();

            Routine r = new Routine();
            r.Create();

        }
    }
}
