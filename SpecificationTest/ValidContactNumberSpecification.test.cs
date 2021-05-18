using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specification;
using System.Collections.Generic;

namespace SpecificationTest
{
    [TestClass]
    public class ValidContactNumberSpecificationTest
    {
        ValidContactNumberSpecification validContactNumberSpecification;
        OrderRequest newOrderRequest;
        ICollection<string> errorList;
        bool isSatisfied;

        [TestInitialize]
        public void SetUp()
        {
            errorList = new List<string>() as ICollection<string>;
            validContactNumberSpecification = new ValidContactNumberSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_PreceededWithPlus639AND13Numbers_TestPassed()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderContactNumber = "+639156420773"
            };

            isSatisfied = validContactNumberSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsTrue(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_NotPreceededWithPlus639AND13Numbers_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderContactNumber = "+631156420773"
            };

            isSatisfied = validContactNumberSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_PreceededWithPlus639ANDNot13Numbers_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderContactNumber = "+63915642077"
            };

            isSatisfied = validContactNumberSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_NotPreceededWithPlus639ANDNot13Numbers_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderContactNumber = "+63115642077"
            };

            isSatisfied = validContactNumberSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }
    }
}
