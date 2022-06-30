using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarUnitTest
{

public class Class1
    {
        CarrentContext1 dc = new CarrentContext1();

        public int Signup(string s)
        {
            var res = (from t in dc.Signups
                       where t.Email == s
                       select t).Count();
            return res;
        }

        public int Signin(string t1, string t2)
        {
            var res = (from t in dc.Signups
                       where t.Email == t1 && t.Password == t2
                       select t).Count();
            return res;
        }

        public List<Car> displaydatabyname(string st)
        {
            var res = from t in dc.Cars
                      where t.Model == st
                      select t;

            return res.ToList();
        }
    }
}
