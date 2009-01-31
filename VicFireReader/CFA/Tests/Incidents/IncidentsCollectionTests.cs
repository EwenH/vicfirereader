using NoeticTools.Utilities;
using NUnit.Extensions;
using NUnit.Framework;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.Tests.Incidents
{
    [TestFixture]
    public class IncidentsCollectionTests : MockingTestFixture
    {
        private IClock clock;
        private IncidentsCollection incidents;

        protected override void SetUp()
        {
            clock = NewMock<IClock>();

            incidents = new IncidentsCollection(clock);
        }

        [Test]
        public void CanInstantiate()
        {}
    }
}
