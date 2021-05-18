using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specification;
using System.Collections.Generic;

namespace SpecificationTest
{
    [TestClass]
    public class ValidEmailSpecificationTest
    {
        ValidEmailSpecification validEmailSpecification;
        OrderRequest newOrderRequest;
        ICollection<string> errorList;
        bool isSatisfied;

        [TestInitialize]
        public void SetUp()
        {
            errorList = new List<string>() as ICollection<string>;
            validEmailSpecification = new ValidEmailSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidFormat_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderEmail = "chris@.com"
            };

            isSatisfied = validEmailSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidFormat_TestPassed()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderEmail = "chris@gmail.com"
            };

            isSatisfied = validEmailSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsTrue(isSatisfied);
        }

        [TestMethod]
        public void IsSatisfiedBy_NullSenderEmail_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                SenderEmail = null
            };

            isSatisfied = validEmailSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);
        }
    }
}
