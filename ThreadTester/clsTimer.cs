using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTester
{
    internal class clsTimer
    {
        // interval v ms
        int mintIntervalIn_ms;

        // thread pro časování timeru
        Thread mobjVlákno1;

        // zastavit thread
        bool mblStop;

        /// deklarace ukazatele na funkci - "public delegate void ..."
        // definice tvaru eventu
        public delegate void dlgTick();
        // deklarace eventu ticku
        public event dlgTick Tick;

        // formulář kde existuje muj objekt
        public Form1 mobjForm; 

        //-------------------------------------
        // interval tick timeru
        //-------------------------------------
        public int Interval
        {
            get { return mintIntervalIn_ms; }
            set { mintIntervalIn_ms = value; }
        }
        
        //-------------------------------------
        // konstruktor timeru
        //-------------------------------------
        public clsTimer(int intIntervalIn_ms) 
        {
            mintIntervalIn_ms = intIntervalIn_ms;
        }

        //-------------------------------------
        // start timeru
        //-------------------------------------
        public bool Start()
        {
            // vytvoření threadu
            mobjVlákno1 = new Thread(MojeRutina);

            //spustit thread
            mblStop = false;
            mobjVlákno1.Start();

            return true;
        }

        //-------------------------------------
        // thread timeru
        //-------------------------------------
        private void MojeRutina()
        {
            do
            {
                {
                    // zavolat eventy v threadu formuláře
                    if (mobjForm!=null)
                        mobjForm.Invoke(Tick);

                    // pozastavit thread
                    Thread.Sleep(mintIntervalIn_ms);
                    // do{ } while ();
                }
            } while (mblStop == false);
        }

        //-------------------------------------
        // stop timeru
        //-------------------------------------
        public bool Stop()
        {
            mobjForm = null;
            
            // stop thread
            mblStop = true;

            return true;
        }
    }
}
