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
        public void TestDatabase()
        {
            admin_it_studies_devEntities db = new admin_it_studies_devEntities();
            Assert.IsNotNull(db.Database);            
        } 

        [Test]
        public void TestGetQualifications()
        {
            admin_it_studies_devEntities db = new admin_it_studies_devEntities();
            Assert.IsNotNull(db.qualification);
        }

        [Test]
        public void TestGetSubject()
        {
            admin_it_studies_devEntities db = new admin_it_studies_devEntities();
            Assert.IsNotNull(db.subject.Find("3PRJ"));
        }
    }
}