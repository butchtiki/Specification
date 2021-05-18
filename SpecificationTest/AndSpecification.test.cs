using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Specification;

namespace SpecificationTest
{
    [TestClass]
    public class AndSpecificationTest
    {
        Mock<ValidEmailSpecification> mockValidEmailSpecification;
        Mock<ValidNameSpecification> mockValidNameSpecification;
        AndSpecification<OrderRequest> andSpecification;
        OrderRequest newRequest;
        ICollection<string> errorList;
        bool isSatisfied;

        [TestInitialize]
        public void SetUp()
        {
            mockValidEmailSpecification = new Mock<ValidEmailSpecification>();
            mockValidNameSpecification = new Mock<ValidNameSpecification>();
            errorList = new List<string>() as ICollection<string>;
        }

        [TestMethod]
        public void IsSatisfiedBy_ValidEmailANDValidName_TestPassed()
        {
            newRequest = new OrderRequest()
            {
                SenderName = "Chris",
                SenderEmail = "chris@gmail.com"
            };
            mockValidNameSpecification.Setup(mockValidNameSpecification
                => mockValidNameSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(true);
            mockValidEmailSpecification.Setup(mockValidEmailSpecification
                => mockValidEmailSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(true);
            andSpecification = new AndSpecification<OrderRequest>
                (this.mockValidNameSpecification.Object,
                this.mockValidEmailSpecification.Object);

            isSatisfied = andSpecification.IsSatisfiedBy(newRequest, ref errorList);

            Assert.IsTrue(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_ValidEmailInvalidName_TestFails()
        {
            newRequest = new OrderRequest()
            {
                SenderName = "",
                SenderEmail = "chris@gmail.com"
            };
            mockValidNameSpecification.Setup(mockValidNameSpecification
                => mockValidNameSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(false);
            mockValidEmailSpecification.Setup(mockValidEmailSpecification
                => mockValidEmailSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(true);
            andSpecification = new AndSpecification<OrderRequest>
                (this.mockValidNameSpecification.Object,
                this.mockValidEmailSpecification.Object);

            isSatisfied = andSpecification.IsSatisfiedBy(newRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_EmailReturnsFalseAndNameReturnsTrue_TestFails()
        {
            newRequest = new OrderRequest()
            {
                SenderName = "Chris",
                SenderEmail = "chris@.com"
            };
            mockValidNameSpecification.Setup(mockValidNameSpecification
                => mockValidNameSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(true);
            mockValidEmailSpecification.Setup(mockValidEmailSpecification
                => mockValidEmailSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(false);
            andSpecification = new AndSpecification<OrderRequest>
                (this.mockValidNameSpecification.Object,
                this.mockValidEmailSpecification.Object);

            isSatisfied = andSpecification.IsSatisfiedBy(newRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }

        [TestMethod]
        public void IsSatisfiedBy_InvalidEmailInvalidName_TestFails()
        {
            newRequest = new OrderRequest()
            {
                SenderName = "",
                SenderEmail = ""
            };
            mockValidNameSpecification.Setup(mockValidNameSpecification
                => mockValidNameSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(false);
            mockValidEmailSpecification.Setup(mockValidEmailSpecification
                => mockValidEmailSpecification.IsSatisfiedBy(newRequest, ref errorList))
                .Returns(false);
            andSpecification = new AndSpecification<OrderRequest>
                (this.mockValidNameSpecification.Object,
                this.mockValidEmailSpecification.Object);

            isSatisfied = andSpecification.IsSatisfiedBy(newRequest, ref errorList);

            Assert.IsFalse(isSatisfied);

        }
    }
}

