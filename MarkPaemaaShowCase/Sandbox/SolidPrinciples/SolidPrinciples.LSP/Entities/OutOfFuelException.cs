using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LSP.Entities
{
    class OutOfFuelException : SystemException
    {
        public OutOfFuelException(string exceptionMessage)
        {
           Assert.Fail(String.Format("Out of Fuel : {0}", exceptionMessage));
        }
    }
}
