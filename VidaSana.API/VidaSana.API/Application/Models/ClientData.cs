using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VidaSana.API.Application.SeedWork;

namespace VidaSana.API.Application.Models
{
    public class ClientData : IAggregateRoot
    {

        public string Document { get; set; }

        public string CompleteName { get; set; }

        public DateTime Birthdate { get; set; }

        /*
        public ClientData(string document, string completeName, DateTime birthdate)
        {
            Document = document;
            CompleteName = completeName;
            Birthdate = birthdate;
        }*/
        
    }
}
