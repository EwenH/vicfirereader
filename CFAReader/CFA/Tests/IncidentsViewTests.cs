using System.Text.RegularExpressions;
using NUnit.Framework;

 

namespace Tests
{
	[TestFixture]
	public class IncidentsViewTests
	{
		[Test]
		public void DSEIncidentParsing() // Spike
		{
			string location = "DSE - 12KM W BEECHWORTH, vic";
			Regex regex = new Regex(@"^(?:DSE - \w* \w{1,3} )?(?<location>.*?)$");

			MatchCollection matches = regex.Matches(location);

			Assert.AreEqual(1, matches.Count);

			Assert.AreEqual("BEECHWORTH, vic", matches[0].Groups["location"].Value);
		}
	}
}
