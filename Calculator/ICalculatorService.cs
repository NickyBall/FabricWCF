using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract(IsOneWay = false)]
        int Add(int a, int b);
    }
}
