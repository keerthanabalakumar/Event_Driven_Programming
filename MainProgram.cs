using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Waymo_Assignment2
{
    class MainProgram
    {
        public static MultiCellBuffer orderBuffer = new MultiCellBuffer();
        public static int plantcount = 1;

        public static void Main()
        {           
            Plant plant = new Plant();
            Dealer dealer = new Dealer();

            //plant thread created
            Thread t  = new Thread(new ThreadStart(plant.plantfunc));
            t.Name = "Plant";
            t.Start();
            
            //dealer threads created
            Thread[] dealers = new Thread[5];

            for (int i = 0; i <= 4; i++)
            {
                dealers[i] = new Thread(new ThreadStart(dealer.dealerfunc));
                dealers[i].Name = "Dealer" + i;
                dealers[i].Start();
            }


            // Event Handler
            Plant.PriceCutEvent += new PriceCutDelegate(dealer.PriceCutEvent);

            // Waiting for all threads to start
            Thread.Sleep(500);
            orderBuffer.sem.Release(2);
            Console.ReadLine();
        }
    }
}