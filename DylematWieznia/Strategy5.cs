using System;
using System.Collections.Generic;
using System.Text;

namespace C6
{
    class Strategy5:IStrategy
    {
        private List<bool> myList = new List<bool>();
        private bool IfLastWin(List<bool> knownMoves)
        {
            if(knownMoves[knownMoves.Count - 1] == true &&myList[myList.Count - 1]==true)
            {
                return true;
            }
            if (knownMoves[knownMoves.Count - 1] == true && myList[myList.Count - 1] == false)
            {
                return true;
            }
            return false;
        } 
        public bool GetNextMove(List<bool> knownMoves)
        {
            if(knownMoves.Count == 0)
            {
                myList = new List<bool>();
                myList.Add(false);
                return false;
            }
            if (IfLastWin(knownMoves))
            {
                myList.Add(myList[myList.Count - 1]);
                return myList[myList.Count - 1];
            }
            else
            {
                if(myList[myList.Count - 1])
                {
                    myList.Add(false);
                    return false;
                }
                myList.Add(true);
                return true;
            }
        }
    }
}
