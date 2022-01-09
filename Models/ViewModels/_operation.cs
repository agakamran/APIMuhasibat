using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMuhasibat.Models.ViewModels
{
    public class _operation
    {
        bool _b;
        public bool _int(string str)
        {
            try
            {
                int ss = int.Parse(str);
                _b = true;
            }
            catch (Exception e) { _b = false; }
            return _b;
        }
        public bool _decimal(string str)
        {
            try
            {
                float ss = float.Parse(str);
                _b = true;
            }
            catch (Exception e) { _b = false; }
            return _b;
        }
    }
}
