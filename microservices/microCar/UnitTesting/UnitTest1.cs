
using _03_WebApi_With_MongoDB.Models;
using _03_WebApi_With_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting
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
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
        [Test]
        public void Test3()
        {
            Assert.Pass();
        }
        [Test]
        public void TestCandidate()
        {
            Candidate candidate = new Candidate();
            Assert.That(typeof(Candidate), Is.EqualTo(candidate.GetType()));

        }
        [Test]
        public void TestController()
        {

        }
    }
}