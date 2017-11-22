using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadsetEmulator;
using System.Diagnostics;
using HeadsetEmulator.Events;

namespace EmulatorFunctionalTest
{
    [TestClass]
    public class EmulatorTester : ICallStatusObserver
    {
        readonly Emulator _emulator;

        public EmulatorTester()
        {
            _emulator = new Emulator();
        }

        //[TestInitialize]
        //public void Init()
        //{
        //    _emulator = new Emulator();
        //}

        [TestMethod]
        public void TestGetModels()
        {
            var models = _emulator.GetModels();
            Assert.IsTrue(models.Count > 0, $"Models count: { models?.Count }");
        }

        [TestMethod]
        public void TestSelectModel()
        {
            var models = _emulator.GetModels();
            Assert.IsTrue(models.Count > 0, $"Models count: { models?.Count }");

            _emulator.SetCurrentHeadset(models[0]);
            Assert.ThrowsException<ArgumentException>(() => _emulator.SetCurrentHeadset("iPhone"));
        }

        [TestMethod]
        public void TestCall()
        {
            var models = _emulator.GetModels();
            _emulator.SetCurrentHeadset(models[0]);
            _emulator.AddCallStatusChangedObserver(this);
            _emulator.Call("555 23523");
        }

        public void CallStatusChanged(CallStatus status)
        {
            Assert.IsTrue(status.Status);
        }
    }
}
