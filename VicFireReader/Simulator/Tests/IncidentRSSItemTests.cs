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

using System;
using VicFireReader.Simulator.Incidents;
using NUnit.Framework;
using NUnit.Extensions;


namespace VicFireReader.Simulator.Tests
{
	[TestFixture]
	public class IncidentRSSItemTests : MockingTestFixture
	{
		private IIncidentRSSItem item;
		private DateTime timeStamp;
		private int itemID;

		protected override void SetUp()
		{
			timeStamp = new DateTime(2008, 4, 3, 13, 2, 59).ToLocalTime();
			itemID = 1992274965;

			item = new IncidentRSSItem(10, "Test Incident", timeStamp, itemID, "going", "small", 1);
		}

		[Test]
		public void AppendNode_AddsIncidentXml()
		{
			string incidentxml = item.GetXml();

string expected =
@"<item>
<title>TEST INCIDENT</title>
<link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274965</link>
<description>&lt;strong&gt;Region:&lt;/strong&gt; 10&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TEST INCIDENT&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:28:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 1</description>
<pubDate>Thu, 03 Apr 2008 13:02:59 GMT</pubDate>
<guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274965</guid>
<dc:date>2008-04-03T13:02:59Z</dc:date>
</item>
".Replace('\'', '"');

			Assert.AreEqual(expected, incidentxml);	
		}
	}
}
