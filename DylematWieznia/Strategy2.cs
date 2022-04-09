using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class Strategy2:IStrategy
    {
        private bool parity;
        public bool GetNextMove(List<bool> knownMoves)
        {
            ChangeParity();
            if(knownMoves.Count == 0)
            {
                return true;
            }
            if(parity == true)
            {
                return knownMoves[knownMoves.Count - 1];
            }
            else
            {
                return true;
            }
        }
        private void ChangeParity()
        {
            if (parity)
            {
                parity = false;
            }
            else
            {
                parity = true;
            }
        }
        public Strategy2()
        {
            parity = false;
        }
    }
}
