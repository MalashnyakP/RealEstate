﻿using System.Collections.Generic;

namespace Estate.Models
{
    public class Appartment
    {
        public virtual int Id { get; set; }
        public virtual string Adress { get; set; }
        public virtual int Price { get; set; }
        public virtual string Images { get; set; }
        public virtual string UserEmail { get; set; }
        public virtual string Description { get; set; }

        public Appartment() { }

        public Appartment(int id, string addres, int price,
            string path, string email, string description)
        {
            Id = id;
            Adress = addres;
            Price = price;
            Images = path;
            UserEmail = email;
            Description = description;
        }
    }

}
