using System;
using System.Threading;

namespace Waymo_Assignment2
{
    public class MultiCellBuffer
    {
        private String[] buffer = new String[2];
        public Semaphore sem = new Semaphore(0, 2);
        public static int no_of_orders = 0;
        public static int retriving_orders = 0;
        public static int count = 0;
        public static int buffercount=0;
        //Adding encoded string in buffer
        public void SetOneCell(String orderStr)
        {   no_of_orders++;
            lock (buffer)
            {
              
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        if (buffer[i] == null)
                        {
                            count++;
                            buffercount++;
                            buffer[i] = orderStr;
                            return;
                        }
                    }

            }
        }
        //retrieving encoded string from buffer
        public String GetOneCell()
        {
            retriving_orders = no_of_orders;
          
            lock (buffer)
            {
                String orderStr = null;
                int orderIndex = 0;

                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] != null)
                    {
                        orderStr = buffer[i];
                        orderIndex = i;
                        buffercount--;
                        break;
                    }
                    
                }

                if (orderStr != null)
                {
                    buffer[orderIndex] = null;
                }
                //switching buffer if buffer[0] is null.
                if (buffer[0] == null && buffer[1] != null)
                {
                    buffer[0] = buffer[1];
                    buffer[1] = null;
                 
                }
                return orderStr;
            }
        }
    }
}