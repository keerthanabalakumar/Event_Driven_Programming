using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waymo_Assignment2
{
    class Decoder
    {

        //decodes the current order
        public static OrderClass DecodeOrder(String abc)
        {
            string[] words = abc.Split(':');
            OrderClass a = new OrderClass();
            a.SetSenderId( words[0]);
            a.SetCardNo(Convert.ToInt32(words[1]));
            a.SetAmount(Convert.ToInt32(words[2]));
            a.SetUnitPrice(Convert.ToInt32(words[3]));
            return a;
        }
    }
}
