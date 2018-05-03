using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waymo_Assignment2
{
    class OrderClass
    {
        private String senderID;
        private int creditnum;
        private int amount;
        private int unitprice;
       
        // set & get functions of all orderclass attributes.
        public void SetSenderId(String senderId)
        {
            this.senderID = senderId;
        }

        public String GetSenderId()
        {
            return senderID;
        }

        public void SetCardNo(int cardNo)
        {
            this.creditnum = cardNo;
        }

        public int GetCardNo()
        {
            return creditnum;
        }
        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public int GetAmount()
        {
            return amount;
        }

        public void SetUnitPrice(int unitprice)
        {
            this.unitprice = unitprice;
        }

        public int GetUnitPrice()
        {
            return unitprice;
        }

       


    }
}
