using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Double.Context;

namespace Web_Double.Models
{
    public class DatabaseIO 
    {
        Model1 mydb = new Model1();


        public List<Shirt> GetShirts()
        {
            return mydb.Shirts.ToList();
        }
        public List<Tshirt> GetAllTshirt()
        {
            return mydb.Tshirts.ToList();
        }
        public List<PoloShirt> GetAllPoloshirt()
        {
            return mydb.PoloShirts.ToList();
        }
        public List<Aokhoac> GetAokhoacs()
        {
            return mydb.Aokhoacs.ToList();
        }
        public List<Hoodee> GetHoodees()
        {
            return mydb.Hoodees.ToList();
        }
        public List<Quan> GetQuans()
        {
            return mydb.Quans.ToList();
        }
        public List<Somi> GetSomis()
        {
            return mydb.Somis.ToList();
        }
        public List<Phukien> GetPhukiens()
        {
            return mydb.Phukiens.ToList();
        }
        public List<User> GetUsers()
        {
            return mydb.Users.ToList();
        }

        //-----------------------------------------------------
        public List<Tshirt> GetTshirt()
        {
            return mydb.Tshirts.Take(4).ToList();
        }
        public List<PoloShirt> GetPoloShirts()
        {
            return mydb.PoloShirts.Take(4).ToList();
        }
    }
}