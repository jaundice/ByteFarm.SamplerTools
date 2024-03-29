using System;
using System.Linq;
using Commons.Music.Midi;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var connection = MidiAccessManager.Default;

            connection.Inputs.ToList().ForEach(a => Console.WriteLine(a.ToString()));

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var connection = MidiAccessManager.Default;


            var inputPort = connection.Inputs.First(a => a.Name == TestConstants.S3000XLPortInput);

            var outputPort = connection.Outputs.First(a => a.Name == TestConstants.S3000XLPortOutput);


            Assert.Pass();
        }
    }
}