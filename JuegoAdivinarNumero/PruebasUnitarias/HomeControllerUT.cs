using Microsoft.VisualStudio.TestTools.UnitTesting;
using JuegoAdivinarNumero.Controllers;
using System.Web.Mvc;

namespace PruebasUnitarias
{
    /// <summary>
    /// Unit test del Controller Home.
    /// </summary>
    [TestClass]
    public class HomeControllerUT
    {
        [TestMethod]
        public void QuienJuegaUT()
        {
            var controller = new HomeController();
            var result = controller.QuienJuega("persona");
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
            Assert.AreEqual("_JuegoPersona", result.ViewName);
        }

        [TestMethod]
        public void CompararMayorUT()
        {
            var controller = new HomeController();
            var result = controller.Comparar(3, 2);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("Mi número es más grande", result);
        }

        [TestMethod]
        public void CompararMenorUT()
        {
            var controller = new HomeController();
            var result = controller.Comparar(1, 2);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("Mi número es más chico", result);
        }

        [TestMethod]
        public void CompararIgualUT()
        {
            var controller = new HomeController();
            var result = controller.Comparar(1, 1);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("Felicidades", result);
        }
        
    }
}
