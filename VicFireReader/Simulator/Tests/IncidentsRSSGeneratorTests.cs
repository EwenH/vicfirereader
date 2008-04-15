#region Copyright

/*---------------------------------------------------------------------------
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in compliance
 * with the License. You may obtain a copy of the License at
 * 
 * http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an "AS IS"
 * basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
 * License for the specific language governing rights and limitations under 
 * the License.
 * 
 * The Initial Developer of the Original Code is Robert Smyth.
 * Portions created by Robert Smyth are Copyright (C) 2008.
 * 
 * All Rights Reserved.
 *---------------------------------------------------------------------------*/

#endregion

using System.Xml;
using CFAReader.Simulator.Incidents;
using NMock2;
using NUnit.Framework;
using NUnit.Extensions;


namespace CFAReader.Simulator.Tests
{
	[TestFixture]
	public class IncidentsRSSGeneratorTests : MockingTestFixture
	{
		private IncidentsRSSGenerator generator;

		protected override void SetUp()
		{
			generator = new IncidentsRSSGenerator();
		}

		[Test]
		public void Create_ReturnsValidEmptyRSSXmlWithTitleLinkAndDescription_WhenNotGivenAnyIncidents()
		{
			generator = new IncidentsRSSGenerator();

			string rss = generator.GetXml(new IIncidentRSSItem[0]);

			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(rss);

			HasCorrectHeader(xmlDocument);
		}

		[Test]
		public void Create_AddsXmlFromGivenIncidents()
		{
			IIncidentRSSItem incident1 = NewMock<IIncidentRSSItem>();

			Expect.Once.On(incident1).Method("GetXml").WithNoArguments().Will(Return.Value("<item>TEST ITEM 1</item>\r\n"));

			string rss = generator.GetXml(incident1);

			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(rss);

			Assert.AreEqual("TEST ITEM 1",
							xmlDocument.SelectSingleNode("/rss/channel/item").InnerText);

			HasCorrectHeader(xmlDocument);
		}

		private static void HasCorrectHeader(XmlNode xmlDocument)
		{
			Assert.AreEqual("Country Fire Authority - Victoria, Australia - Statewide Current Incident Summary",
							xmlDocument.SelectSingleNode("/rss/channel/title").InnerText);

			Assert.AreEqual("http://www.cfa.vic.gov.au/incidents/incident_summary.htm",
							xmlDocument.SelectSingleNode("/rss/channel/link").InnerText);

			Assert.AreEqual("Country Fire Authority - Victoria, Australia - CFA responds to a range of incidents across Victoria. Our current activity (over the previous 5 hours) is listed below.",
							xmlDocument.SelectSingleNode("/rss/channel/description").InnerText);
		}
	}
}
