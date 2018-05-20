using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estate.Models;

namespace Estate.Models
{
    public class AppartmentsListModel
    {
        public int TopPrice { get; set; }
        public int LowPrice { get; set; }

        public String Street { get; set; }
        public List<Appartment> Appartments { get; set; }
        public List<Appartment> favorite { get; set; }

        public AppartmentsListModel(List<Appartment> _appartments)
        {
            Appartments = _appartments;

            Street = "";
        }
    }
}
