//==================================================
// Copyright (c) Coalition of Good-Hearted Engineers
// Free To Use For Reliable File Conversion
//==================================================

using System.Collections.Generic;
using MetaXPorterApp.Web.Models.Foundations.Persons;
using MetaXPorterApp.Web.Models.Foundations.Pets;

namespace MetaXPorterApp.Web.Models.Orchestrations.PersonPets
{
    public class PersonPet
    {
        public Person Person { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
