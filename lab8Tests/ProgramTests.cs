using NUnit.Framework;
using lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        Program met = new Program();

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(3.14)]
        public void FindSinTest(double input)
        {
            Assert.AreEqual(Math.Sin(input), met.FindSin(input), 1e-5);
        }

        [TestCase(0)]
        [TestCase(5)]
        [TestCase(3.14)]
        public void FindCosTest(double input)
        {
            Assert.AreEqual(Math.Cos(input), met.FindCos(input), 1e-4);
        }

        [TestCase(1)]
        [TestCase(0.5)]
        public void LnTest(double input)
        {
            Assert.AreEqual(Math.Log(input), met.Ln(input), 1e-4);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        public void ModuleTest(double input)
        {
            Assert.AreEqual(Math.Abs(input), met.Module(input), 1e-4);
        }

        [TestCase(4)]
        [TestCase(8)]
        [TestCase(-10)]
        public void RootTest(double input)
        {
            Assert.AreEqual(Math.Sqrt(input), met.Root(input), 1e-4);
        }
    }

    [TestFixture()]
    public class IntegrationTests
    {
        Program met = new Program();

        [TestCase(1)]
        [TestCase(0.5)]
        public void Cos_LnModule(double input)
        {
            Assert.AreEqual(Math.Cos(Math.Log(Math.Abs(input))),
                met.FindCos(met.Ln(met.Module(input))), 1e-4);
        }

        [TestCase(1)]
        [TestCase(0.5)]
        public void Sin_Cos_LnModule(double input)
        {
            Assert.AreEqual(Math.Sin(input) *
            Math.Cos(Math.Log(Math.Abs(input))), met.FindSin(input) *
            met.FindCos(met.Ln(met.Module(input))), 1e-4);
        }

        [TestCase(0)]
        public void Root_Sin_Cos_LnModule(double input)
        {
            Assert.AreEqual(Math.Sqrt(Math.Sin(input) *
            Math.Cos(Math.Log(Math.Abs(input)))), met.Root(met.FindSin(input) *
            met.FindCos(met.Ln(met.Module(input)))), 1e-4);
        }

        [TestCase(0)]
        [TestCase(4)]
        [TestCase(3.14)]
        public void One_Cos(double input)
        {
            Assert.AreEqual(1 - Math.Cos(input), 1 - met.FindCos(input), 1e-4);
        }

        [TestCase(1)]
        [TestCase(5)]
        public void One_Cos_Sin(double input)
        {
            Assert.AreEqual((1 - Math.Cos(input)) / Math.Sin(input),
                (1 - met.FindCos(input)) / met.FindSin(input), 1e-4);
        }
    }
}
