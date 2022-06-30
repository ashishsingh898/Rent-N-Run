using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RentNRunLib
{
    public class Myclass
    {
        CarrentContext dc = new();


        public List<Car> Cars()
        {
            var res = dc.Cars.ToList();
            return res;
        }


        public int Signupmethod(Signup r)
        {
            dc.Signups.Add(r);
            int res = dc.SaveChanges();
            return res;
        }
        

        public int Signinmethod(string uname, string pwd)
        {
            var res = (from t in dc.Signups
                       where t.Email == uname & t.Password == pwd
                       select t).Count();
            dc.SaveChanges();
            return res;
        }


        public int Contactmethod(Contactus y)
        {
            dc.Contactus.Add(y);
            int res = dc.SaveChanges();
            return res;
        }

        public Car Cart(int mycarid)
        {
            var res = (from t in dc.Cars
                       where t.CarId == mycarid
                       select t).FirstOrDefault();
            return res;
        }

        public Car Booking(int mycarid)
        {

            var res = (from t in dc.Cars
                       where t.CarId == mycarid
                       select t).FirstOrDefault();
            return res;
        }

    }
}