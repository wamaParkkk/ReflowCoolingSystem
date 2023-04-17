using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReflowCoolingSystem.Squence
{
    class Cooling : TBaseThread
    {
        Thread thread;        

        public Cooling()
        {
            ModuleName = "PM1";
            module = (byte)MODULE._PM1;            

            thread = new Thread(new ThreadStart(Execute));                        
            thread.Start();            
        }

        public void Dispose()
        {
            thread.Abort();
        }

        private void Execute()
        {           
            try
            {
                while (true)
                {                    
                    Task.Delay(500);
                }
            }
            catch (Exception ex)
            {                
                Global.EventLog(ex.Message, ModuleName, "Event");
                Dispose();
                return;
            }
        }                  
    }
}
