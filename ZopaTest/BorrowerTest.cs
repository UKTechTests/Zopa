using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zopa;
using System.Collections.Generic;

namespace ZopaTest
{
    [TestClass]
    public class BorrowerTest
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestNotNumericAmount()
        {
            Borrower br = new Borrower("TEST");
        }

        [TestMethod]
        [ExpectedException(typeof(BorrowerIncorrectAmountException))]
        public void TestNotValidAmount1()
        {
            Borrower br = new Borrower(5);
        }

        [TestMethod]
        [ExpectedException(typeof(BorrowerIncorrectAmountException))]
        public void TestNotValidAmount2()
        {
            Borrower br = new Borrower(5555);
        }

        [TestMethod]
        [ExpectedException(typeof(BorrowerIncorrectAmountException))]
        public void TestNotValidAmount3()
        {
            Borrower br = new Borrower(20000);
        }

        [TestMethod]
        [ExpectedException(typeof(LendersNotAvailableException))]
        public void TestLendersNotAvailable()
        {
            IList<Lender> lenders = new List<Lender>();
            Borrower br = new Borrower(15000);
            br.CalculateLoan(lenders);
        }

        [TestMethod]       
        public void TestCalculateLoan()
        {
            IList<Lender> lenders = new List<Lender>();
            lenders.Add(new Lender("TEST", 0.1m, 10000));
            Borrower br = new Borrower(5000);
            br.CalculateLoan(lenders);

            Assert.AreEqual("10.0", (br.Rate * 100).ToString("0.0"));
            Assert.AreEqual("187.25", br.MonthlyRepayment.ToString("0.00"));
            Assert.AreEqual("6740.91", br.TotalRepayment.ToString("0.00"));
        }

        [TestMethod]
        public void TestCalculateLoan2()
        {
            IList<Lender> lenders = new List<Lender>();
            lenders.Add(new Lender("TEST", 0.1m, 1000));
            lenders.Add(new Lender("TEST", 0.2m, 1000));
            Borrower br = new Borrower(1500);
            br.CalculateLoan(lenders);

            Assert.AreEqual("13.3", (br.Rate * 100).ToString("0.0"));
            Assert.AreEqual("62.02", br.MonthlyRepayment.ToString("0.00"));
            Assert.AreEqual("2232.81", br.TotalRepayment.ToString("0.00"));
        }

    }
}
