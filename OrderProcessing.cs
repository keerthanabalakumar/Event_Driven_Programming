using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Waymo_Assignment2
{
    class OrderProcessing
    {
        private OrderClass abc;

        public OrderProcessing(OrderClass abc)
        {
            this.abc = abc;
        }
            
        public void ProcessNewOrder()
        {
            if (abc.GetCardNo() >= 5000 && abc.GetCardNo() <= 7000)
            {       //order is processed 
                    //credit card check & charges calculation is handled.
                 
                    int total_charge;
                    int tax = Convert.ToInt32(0.08 * abc.GetUnitPrice());
                    int location_charge;
                    if (abc.GetAmount() > 20)
                    {
                        location_charge = Convert.ToInt32(0.05 * abc.GetUnitPrice());
                    }
                    else
                    {
                        location_charge = Convert.ToInt32(0.10 * abc.GetUnitPrice());
                    }
                    total_charge = (abc.GetAmount() * abc.GetUnitPrice()) + (tax * abc.GetUnitPrice()) + (location_charge * abc.GetUnitPrice());
                    Console.WriteLine(" Credit card number is valid .Total charge for {1} cars is {0}k $ order placed by {2} each {3}k $. Order is processed ", total_charge,abc.GetAmount(),abc.GetSenderId(),abc.GetUnitPrice());
            }
            else
            {
                Console.WriteLine(" Credit card number is not valid. Order not processed. Placed by {0}", abc.GetSenderId());
            }
        }
        }

       
       
    }

