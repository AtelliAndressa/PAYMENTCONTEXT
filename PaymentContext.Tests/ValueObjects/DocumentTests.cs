using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {

        //Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(false); ;
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsValid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsValid()
        {
            Assert.Fail();
        }
    }
}