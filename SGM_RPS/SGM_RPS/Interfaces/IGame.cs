using System;
using System.Collections.Generic;
using System.Text;
using SGM_RPS.Models;

namespace SGM_RPS.Interfaces
{
    public interface IGame
    {
        Choice PlayerChoice();
        Choice SystemChoice();
        Result RoundResult(Choice player, Choice system);
        Result FinalResult();
        Choice MostUsedMove();
    }
}
