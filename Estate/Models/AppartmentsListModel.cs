using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estate.Models;

namespace Estate.Models
{
    public class AppartmentsListModel
    {
        public string TopPrice { get; set; }
        public string LowPrice { get; set; }

        public String Street { get; set; }
        public List<Appartment> Appartments { get; set; }

        public AppartmentsListModel(List<Appartment> _appartments)
        {
            Appartments = _appartments;
            TopPrice = "";
            LowPrice = "";
            Street = "";
        }
    }
}
