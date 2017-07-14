using System;
using System.Collections.Generic;

namespace HousingTenant.Data.Library.Models
{
    public partial class Supplies
    {
        public int RequestId { get; set; }
        public bool Soap { get; set; }
        public bool PaperTowels { get; set; }
        public bool TrashBags { get; set; }
        public bool Sponges { get; set; }
        public string Content { get; set; }
        public bool Active { get; set; }

        public virtual Request Request { get; set; }
    }
}
