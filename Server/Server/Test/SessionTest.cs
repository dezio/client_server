// (C) 2013 - Dennis Ziolkowski
// Server : SessionTest.cs

#region Usings

using System;
using System.Diagnostics;
using System.Threading;
using Client;
using NUnit.Framework;

#endregion

namespace Server.Test {
    [TestFixture]
    public class SessionTest {
        [SetUp]
        public void SetUpServer() {
            _serverBundle.StartBundle();
        }

        [TearDown]
        public void Dispose() {
            Thread.Sleep(5000);
            _serverBundle.StopBundle();
        }

        private readonly ServerBundle _serverBundle = new ServerBundle();
        private readonly ClientInstance _client = new ClientInstance();

        public void MessageServerHello() {
            _client.LogInToMessageServer();
        }

        [Test]
        public void FirstMessageTest() {
            _client.InitSession();
            Console.WriteLine("Got SessionId: " + _client.SessionId);
            Assert.NotNull(_client.SessionId);
            Assert.IsTrue(_client.MessagePort > 0);
            MessageServerHello();
            _client.Authenticate("DeZio1991", "181191");
        }
    }
}