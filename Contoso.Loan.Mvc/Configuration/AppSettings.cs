using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Contoso.Loan.Mvc.Configuration
{
    public static class AppSettings
    { 
        public static int DefaultLoanAmount
        {
            get
            {
                string value = ConfigurationManager.AppSettings["DefaultLoanAmount"];

                if (value == null)
                {
                    throw new Exception(String.Format("Could not find setting for DefaultLoanAmount in web.config"));
                }

                return Convert.ToInt32(value);
            }
        }

        public static int DefaultLoanTerm
        {
            get
            {
                string value = ConfigurationManager.AppSettings["DefaultLoanTerm"];

                if (value == null)
                {
                    throw new Exception(String.Format("Could not find setting for DefaultLoanTerm in web.config"));
                }

                return Convert.ToInt32(value);
            }
        }

        public static decimal DefaultInterestRate
        {
            get
            {
                string value = ConfigurationManager.AppSettings["DefaultInterestRate"];

                if (value == null)
                {
                    throw new Exception(String.Format("Could not find setting for DefaultInterestRate in web.config"));
                }

                return Convert.ToDecimal(value);
            }
        }
    }
}