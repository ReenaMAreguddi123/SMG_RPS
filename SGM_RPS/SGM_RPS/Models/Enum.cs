using System;
using System.Collections.Generic;
using System.Text;

namespace SGM_RPS.Models
{
    public enum Choice
    {
        Rock = 'R',
        Paper = 'P',
        Scissors = 'S',
    }

    public enum Result
    {
        Player_Won,
        System_Won,
        Draw,
    }
}
