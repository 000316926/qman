using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using NUnit.Framework;
using QMAN.Controllers;
using System.Web.Mvc;
using QMAN.Models;

namespace QMAN.Tests
{
    [TestFixture]
    public class QMANTests
    {
        [Test]
        public void TestQualificationController()
        {
            var obj = new QualificationsController();

            var result = obj.Index("", "") as ViewResult;

            var expected = "Index";

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void TestSubjectController()
        {
            //var obj = new SubjectsController();

            //var result = obj.Index("", "") as ViewResult;

            //var expected = "Index";

            //Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void TestDatabase()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            //Assert.IsInstanceOf<List<Qualification>>(db.Qualifications.ToList());
        } 
    }
}