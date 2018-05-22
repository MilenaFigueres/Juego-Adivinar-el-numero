using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JuegoAdivinarNumero.Services;

namespace PruebasUnitarias
{
    /// <summary>
    /// Unit test del service encargado de realizar la búsqueda binaria.
    /// </summary>
    [TestClass]
    public class AdivinaNumeroServiceUT
    {
        [TestMethod]
        public void BusquedaBinariaGrandeUT()
        {
            var adivinarService = new AdivinarNumeroServices();
            var result = adivinarService.busquedaBinaria(50, "grande", 1, 100);
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, int>));
            Assert.AreEqual(50, result["limiteIzquierdo"]);
            Assert.AreEqual(100, result["limiteDerecho"]);
            Assert.AreEqual(true, result["numeroElegido"] > 50);
        }
        [TestMethod]
        public void BusquedaBinariaChicoUT()
        {
            var adivinarService = new AdivinarNumeroServices();
            var result = adivinarService.busquedaBinaria(50, "chico", 1, 100);
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, int>));
            Assert.AreEqual(1, result["limiteIzquierdo"]);
            Assert.AreEqual(50, result["limiteDerecho"]);
            Assert.AreEqual(true, result["numeroElegido"] < 50);
        }
    }
}
