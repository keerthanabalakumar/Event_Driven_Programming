using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waymo_Assignment2
{
    class Encoder
    {

        //Encodes the given order
        public static String EncodeOrder(OrderClass order)
        { string []a = new string [4];
            a[0] = order.GetSenderId();
            a[1] = Convert.ToString(order.GetCardNo());
            a[2] = Convert.ToString(order.GetAmount());
            a[3] = Convert.ToString(order.GetUnitPrice());
            string abc = string.Join(":", a);
            return abc;
        }
    }
}