using Microsoft.VisualStudio.TestTools.UnitTesting;
using AXA_zadanie;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DllConnectionTest()
        {
            var stc = new SharpTrooper.Core.SharpTrooperCore("https://swapi.dev/api", null);
            var films = stc.GetAllFilms();
            var allstarships = stc.GetAllStarships();


        }
    }
}
