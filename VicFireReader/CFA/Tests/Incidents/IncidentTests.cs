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
        private IIncidentChangeListener incidentChangeListener;

        protected override void SetUp()
        {
            clock = NewMock<IClock>();
            incidentChangeListener = NewMock<IIncidentChangeListener>();

            incident = new Incident(clock, incidentChangeListener, "ID 1", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
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
            Incident incident2 = new Incident(clock, incidentChangeListener, "ID 2", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
                                    "Status", "Size", 150);

            Assert.IsTrue(incident.CompareTo(incident) == 0);
            Assert.IsTrue(incident.CompareTo(incident2) < 0);
            Assert.IsTrue(incident2.CompareTo(incident) > 0);
        }

        [Test]
        public void GetHashCode_IsEqual_ForSameIncident()
        {
            Assert.AreEqual(incident.GetHashCode(), incident.GetHashCode());
        }

        [Test]
        public void GetHashCode_IsDifferent_ForIncidentsWithDifferentIDs()
        {
            Incident incident2 = new Incident(clock, incidentChangeListener, "ID 2", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
                                    "Status", "Size", 150);

            Assert.AreNotEqual(incident.GetHashCode(), incident2.GetHashCode());
        }

        [Test]
        public void GetHashCode_IsEqual_ForIncidentsWithSameID()
        {
            Incident incident2 = new Incident(clock, incidentChangeListener, "ID 1", 13, "Location", new DateTime(2009, 2, 1, 9, 30, 0), "Name", "Type",
                                    "Status", "Size", 150);

            Assert.AreEqual(incident.GetHashCode(), incident2.GetHashCode());
        }

        [Test]
        public void GetHashCode_IsEqual_ForIncidentsWithSameIDButDifferentValues()
        {
            Incident incident2 = new Incident(clock, incidentChangeListener, "ID 1", 13, "Location2", new DateTime(2010, 2, 1, 9, 30, 0), "MyName", "AnotherType",
                                    "AnotherStatus", "Large", 7);

            Assert.AreEqual(incident.GetHashCode(), incident2.GetHashCode());
        }
    }
}
