using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartBook.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SmartBook.Tests.Controllers
{
    [TestClass]

    public class UnitTestsControllerTest
    {
        [TestMethod]
        public void UnitTestIndex()
        {
            //  Arrange
            UnitTestsController objUnitTestController = new UnitTestsController();

            // Act
            ViewResult objViewResult = objUnitTestController.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", objViewResult.ViewName);

        }
    }
}
