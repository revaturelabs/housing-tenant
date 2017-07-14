using System;
using System.Collections.Generic;
using System.Text;

namespace HousingTenant.Data.Library.DataModels
{
    public enum Gender { male, female };
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
    }
}
