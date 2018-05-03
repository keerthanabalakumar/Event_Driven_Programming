using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Waymo_Assignment2
{
    public delegate void PriceCutDelegate(int unitprice); //event 

    class Plant
    {
       
        public int unitprice =300;
        private int orderCounter = 0;
        private int priceCutCounter=0;


        public static event PriceCutDelegate PriceCutEvent;
        public int Getunitprice()
        {
            return unitprice;
        }

        public void plantfunc()
        {
            while (priceCutCounter <= 20)
            {
                Thread.Sleep(1000);
                GenerateCarPrice();
                if (MultiCellBuffer.count > 0)
                {
                    String orderStr = MainProgram.orderBuffer.GetOneCell();  //retrieve string from the multi cell buffer
                    if (orderStr != null)
                    {
                        OrderClass order = Decoder.DecodeOrder(orderStr);   //decode the order
                        MainProgram.orderBuffer.sem.Release(1);
                        orderCounter++;
                        OrderProcessing orderProc = new OrderProcessing(order);
                        Thread orderProcThread = new Thread(new ThreadStart(orderProc.ProcessNewOrder)); //processing order
                        orderProcThread.Start();
                    }

                }
            }

            if (priceCutCounter > 20)         
                //terminating threads after 20 price cuts.
            {
                Console.WriteLine("Twenty Pricecuts occured");
                Console.WriteLine("Terminating the plant & dealer threads");
                Environment.Exit(Environment.ExitCode);
            }
          
        }

        public int PricingModel()
        {
            Random r1 = new Random();
            int current = r1.Next(50, 500);
          
            return current;
        }
        public void GenerateCarPrice()
        {   
            int current;

            current = PricingModel();

          
            if (current < unitprice)
            {
                
                if (PriceCutEvent != null)
                { 
                    Console.WriteLine("******Price cut event occured ******");
                    PriceCutEvent(unitprice);
                    
                }
                priceCutCounter++;
                unitprice = current;
                Thread.Sleep(3000);
             
            }
            else
                unitprice = current;
           
        }
    }
}
