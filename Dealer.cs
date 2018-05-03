using System;
using System.Threading;

namespace Waymo_Assignment2
{
    class Dealer
    {
        
        private int currentPrice;
        private int unitprice0;
        
        private bool placeOrder;

        int i = 10;
        int j = 100;

       
        public Dealer()
        {
            currentPrice = 500;
            unitprice0 = 0;
            placeOrder = false;
           
        }

       
        public void dealerfunc()
        {
            while (MainProgram.plantcount > 0)
            {
                Thread.Sleep(500);

                if (placeOrder)
                {

                    OrderClass orderToBePlaced = new OrderClass();
                    Plant p = new Plant();
                    Random r2 = new Random();
                    int orderAmount0 = 0;
                    int cardno = 0;
                    orderAmount0 = r2.Next(i, j);
                    cardno = r2.Next(4500, 7000);

                    i = r2.Next(10, 50);
                    j = r2.Next(60, 110);
                    orderToBePlaced.SetSenderId(Thread.CurrentThread.Name);
                    orderToBePlaced.SetCardNo(cardno);
                    orderToBePlaced.SetAmount(orderAmount0);
                    orderToBePlaced.SetUnitPrice(unitprice0);
                    Console.WriteLine(orderToBePlaced.GetSenderId() + " has placed an order for " + orderToBePlaced.GetAmount()
                    + " cars for " + orderToBePlaced.GetUnitPrice() + "k $ each");
                    String orderStr = Encoder.EncodeOrder(orderToBePlaced);   //encode


                    MainProgram.orderBuffer.sem.WaitOne();
                    MainProgram.orderBuffer.SetOneCell(orderStr);  //updating buffer
                    currentPrice = orderToBePlaced.GetUnitPrice();
                    placeOrder = false;
                }
            }
     
        }

      
        public void PriceCutEvent(int unitprice)       //price cut event
        {
            unitprice0 = unitprice;
            if (!placeOrder)
                placeOrder = true;
        }
    }
}