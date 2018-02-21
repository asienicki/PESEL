using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PESEL.Models;
using PESEL.Validators.Impl;

namespace PESEL.NugetClientTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void ModelMethodTest()
        {
            var model = new Model
            {
                Pesel = "02070803628"
            };

            var context = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();

            Assert.IsTrue(Validator.TryValidateObject(model, context, validationResults, true));
        }

        [TestMethod]
        public void ModelMethodTest1()
        {
            var model = new Model
            {
                Pesel = "02070803621"
            };

            var context = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();

            Assert.IsFalse(Validator.TryValidateObject(model, context, validationResults, true));
        }

        [TestMethod]
        public void PeselTest1()
        {
            var validator = new PeselValidator();

            var entity = new Entity("02070803628");

            var validationResult = validator.Validate(entity);

            Assert.IsTrue(validationResult.IsValid);
        }

    }
}