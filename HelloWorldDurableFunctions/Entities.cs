using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class PersonsList
    {
        public List<Person> Persons {get; set;}
    }

    public class Person
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
    }
}
