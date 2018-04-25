using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToAStar.Example.EightPuzzle
{
    class BoardStateComparer : IComparer<BoardState>
    {
        int IComparer<BoardState>.Compare(BoardState x, BoardState y)
        {
            throw new NotImplementedException();
        }
    }
}
