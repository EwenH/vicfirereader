using System;
using NUnit.Framework;
using NUnit.Extensions;
using VicFireReader.CFA.Incidents;
using NoeticTools.Utilities;


namespace VicFireReader.CFA.Tests.Incidents
{
    [TestFixture]
    public class IncidentTests : MockingTestFixture
    {
        private IClock clock;
        private Incident incident;

        protected override void SetUp()
        {
            clock = NewMock<IClock>();

            incident = new Incident(clock, "ID 1", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
                                    "Status", "Size", 150);
        }

        [Test]
        public void EqualsOperator()
        {
            Assert.AreEqual(incident, incident);
        }

        [Test]
        public void Compare()
        {
            Incident incident2 = new Incident(clock, "ID 2", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
                                    "Status", "Size", 150);

            Assert.IsTrue(incident.CompareTo(incident) == 0);
            Assert.IsTrue(incident.CompareTo(incident2) < 0);
            Assert.IsTrue(incident2.CompareTo(incident) > 0);
        }
    }
}
