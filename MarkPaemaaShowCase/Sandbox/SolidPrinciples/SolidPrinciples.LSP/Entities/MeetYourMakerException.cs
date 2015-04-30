using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LSP.Entities
{
    class MeetYourMakerException : SystemException
    {
        public MeetYourMakerException(string exceptionMessage)
        {
            Assert.Fail(String.Format("Meet your maker : {0}", exceptionMessage));
        }
    }
}
