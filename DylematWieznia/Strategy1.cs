using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class Strategy1:IStrategy //true then wet for 
    {
        private List<bool> myMoves = new List<bool>();
        public bool GetNextMove(List<bool> knownMoves)
        {
            if(knownMoves.Count == 0)
            {
                return true;
            }
            else
            {
                return knownMoves[knownMoves.Count-1];
            }
        }
    }
}
