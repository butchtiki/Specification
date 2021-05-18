using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specification;

namespace SpecificationTest
{
    [TestClass]
    public class ValidNameSpecificationTest
    {
        OrderRequest newOrderRequest;
        ICollection<string> errorList;
        ValidNameSpecification validNameSpecification;
        bool isSatisfied;

        [TestInitialize]
        public void SetUp()
        {
            this.errorList = new List<string>() as ICollection<string>;
            this.validNameSpecification = new ValidNameSpecification();
        }

        [TestMethod]
        public void IsSatisfiedBy_NotNullSenderNameANDNotWhitespace_ValidName()
        {
            this.newOrderRequest = new OrderRequest()
            {
                SenderName = "Lito",
                SenderEmail = "lsalud@gmail.com"
            };

            isSatisfied = this.validNameSpecification.IsSatisfiedBy(this.newOrderRequest, ref this.errorList);
            Assert.IsTrue(isSatisfied);
        }

        [TestMethod]
        public void IsSatisfiedBy_NotNullSenderNameANDWhitespace_InvalidName()
        {
            this.newOrderRequest = new OrderRequest()
            {
                SenderName = "",
                SenderEmail = "lsalud@gmail.com"
            };

            isSatisfied = this.validNameSpecification.IsSatisfiedBy(this.newOrderRequest, ref this.errorList);
            Assert.IsFalse(isSatisfied);
        }

        [TestMethod]
        public void IsSatisfiedBy_NullSenderName_InvalidName()
        {
            this.newOrderRequest = new OrderRequest()
            {
                SenderName = null,
                SenderEmail = "lsalud@gmail.com"
            };

            isSatisfied = this.validNameSpecification.IsSatisfiedBy(this.newOrderRequest, ref this.errorList);
            Assert.IsFalse(isSatisfied);
        }

        
    }
}
