using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Loan.MvcServices.Tests
{
    public class LoanServiceTests
    {
        private static Fixture _fixture;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _fixture = new Fixture();
        }


    }
}
