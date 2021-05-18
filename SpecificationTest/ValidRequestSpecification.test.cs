using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specification;
using System.Collections.Generic;

namespace SpecificationTest
{
    [TestClass]
    public class ValidRequestSpecificationTest
    {
        ValidRequestSpecification validRequestSpecification;
        OrderRequest newOrderRequest;
        ICollection<string> errorList;
        bool isSatisfied;

        [TestInitialize]
        public void SetUp()
        {
            errorList = new List<string>() as ICollection<string>;
            validRequestSpecification = new ValidRequestSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidRecipientNameEmailAndContactNumber_TestPassed()
        {
            newOrderRequest = new OrderRequest()
            {
                RecipientName = "Chris",
                RecipientEmail = "chris@gmail.com",
                RecipientContactNumber = "+639156420773"
            };

            isSatisfied = validRequestSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsTrue(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidRecipientNameEmailAndContactNumber_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                RecipientName = "",
                RecipientEmail = "",
                RecipientContactNumber = ""
            };

            isSatisfied = validRequestSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_NullRecipientNameEmailAndContactNumber_TestFails()
        {
            newOrderRequest = new OrderRequest()
            {
                RecipientName = null,
                RecipientEmail = null,
                RecipientContactNumber = null
            };

            isSatisfied = validRequestSpecification.IsSatisfiedBy(newOrderRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }
    }
}