﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
