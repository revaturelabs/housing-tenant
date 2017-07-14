using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        public int GenderId { get; set; }
        public string Gender1 { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
