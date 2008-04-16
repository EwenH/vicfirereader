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

using System.IO;
using System.Text;
using NoeticTools.DotNetWrappers;


namespace VicFireReader.Simulator
{
	public class IncidentsRSSSimulatedWebResponse : ISimulatedWebResponse
	{
		private readonly string sampleRSS =
@"<?xml version='1.0' encoding='UTF-8'?>
<rss xmlns:taxo='http://purl.org/rss/1.0/modules/taxonomy/' xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#' xmlns:dc='http://purl.org/dc/elements/1.1/' version='2.0'>
  <channel>
    <title>Country Fire Authority - Victoria, Australia - Statewide Current Incident Summary</title>
    <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm</link>
    <description>Country Fire Authority - Victoria, Australia - CFA responds to a range of incidents across Victoria. Our current activity (over the previous 5 hours) is listed below.</description>
    <item>
      <title>TRARALGON, CRAIGBURN PL</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274965</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 10&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TRARALGON, CRAIGBURN PL&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:29:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 03:29:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274965</guid>
      <dc:date>2008-01-28T03:29:00Z</dc:date>
    </item>
    <item>
      <title>MOUNT TASSIE</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274964</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 10&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; MOUNT TASSIE&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:28:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 1</description>
      <pubDate>Mon, 28 Jan 2008 03:28:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274964</guid>
      <dc:date>2008-01-28T03:28:00Z</dc:date>
    </item>
    <item>
      <title>FRANKSTON, FURNEAUX CT</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274963</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; FRANKSTON, FURNEAUX CT&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:27:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 3</description>
      <pubDate>Mon, 28 Jan 2008 03:27:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274963</guid>
      <dc:date>2008-01-28T03:27:00Z</dc:date>
    </item>
    <item>
      <title>MOE, VALE ST</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274940</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 09&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; MOE, VALE ST&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:22:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 03:22:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274940</guid>
      <dc:date>2008-01-28T03:22:00Z</dc:date>
    </item>
    <item>
      <title>YACKANDANDAH, BELLS FLAT RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274962</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 24&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; YACKANDANDAH, BELLS FLAT RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:22:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 1</description>
      <pubDate>Mon, 28 Jan 2008 03:22:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274962</guid>
      <dc:date>2008-01-28T03:22:00Z</dc:date>
    </item>
    <item>
      <title>WARRENHEIP, FOOS LA</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274938</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 15&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; WARRENHEIP, FOOS LA&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:19:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 2</description>
      <pubDate>Mon, 28 Jan 2008 03:19:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274938</guid>
      <dc:date>2008-01-28T03:19:00Z</dc:date>
    </item>
    <item>
      <title>WARRONG, WILLATOOK-WARRONG RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274939</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 05&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; WARRONG, WILLATOOK-WARRONG RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:18:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 3</description>
      <pubDate>Mon, 28 Jan 2008 03:18:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274939</guid>
      <dc:date>2008-01-28T03:18:00Z</dc:date>
    </item>
    <item>
      <title>ROXBURGH PARK, BICKERTON WAY</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274935</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 14&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; ROXBURGH PARK, BICKERTON WAY&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:04:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 03:04:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274935</guid>
      <dc:date>2008-01-28T03:04:00Z</dc:date>
    </item>
    <item>
      <title>TRARALGON SOUTH, DOWNIES LA</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274937</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 10&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TRARALGON SOUTH, DOWNIES LA&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:57:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:57:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274937</guid>
      <dc:date>2008-01-28T02:57:00Z</dc:date>
    </item>
    <item>
      <title>TRARALGON SOUTH, TRARALGON-BALOOK RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274936</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 10&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TRARALGON SOUTH, TRARALGON-BALOOK RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:51:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 2</description>
      <pubDate>Mon, 28 Jan 2008 02:51:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274936</guid>
      <dc:date>2008-01-28T02:51:00Z</dc:date>
    </item>
    <item>
      <title>SCOTSBURN, PLATTS RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274909</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 15&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; SCOTSBURN, PLATTS RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:44:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; CONTROLLED&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 7</description>
      <pubDate>Mon, 28 Jan 2008 02:44:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274909</guid>
      <dc:date>2008-01-28T02:44:00Z</dc:date>
    </item>
    <item>
      <title>BALLARAT EAST</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274934</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 15&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; BALLARAT EAST&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:42:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; RESCUE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:42:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274934</guid>
      <dc:date>2008-01-28T02:42:00Z</dc:date>
    </item>
    <item>
      <title>PEARCEDALE</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274932</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; PEARCEDALE&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:23:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:23:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274932</guid>
      <dc:date>2008-01-28T02:23:00Z</dc:date>
    </item>
    <item>
      <title>TYABB</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274933</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TYABB&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:22:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; INCIDENT&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:22:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274933</guid>
      <dc:date>2008-01-28T02:22:00Z</dc:date>
    </item>
    <item>
      <title>NORTH WARRANDYTE, OVERBANK RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274907</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 13&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; NORTH WARRANDYTE, OVERBANK RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:22:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:22:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274907</guid>
      <dc:date>2008-01-28T02:22:00Z</dc:date>
    </item>
    <item>
      <title>ROSEBUD, JETTY RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274931</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; ROSEBUD, JETTY RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 13:11:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 02:11:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274931</guid>
      <dc:date>2008-01-28T02:11:00Z</dc:date>
    </item>
    <item>
      <title>NORTH BENDIGO, HOLDSWORTH RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274908</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 02&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; NORTH BENDIGO, HOLDSWORTH RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 12:56:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 01:56:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274908</guid>
      <dc:date>2008-01-28T01:56:00Z</dc:date>
    </item>
    <item>
      <title>WONTHAGGI</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274906</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; WONTHAGGI&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 12:32:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 01:32:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274906</guid>
      <dc:date>2008-01-28T01:32:00Z</dc:date>
    </item>
    <item>
      <title>GREENVALE, FRENCH RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274905</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 14&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; GREENVALE, FRENCH RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 12:23:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 01:23:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274905</guid>
      <dc:date>2008-01-28T01:23:00Z</dc:date>
    </item>
    <item>
      <title>CRANBOURNE, SOUTH GIPPSLAND HWY</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274902</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; CRANBOURNE, SOUTH GIPPSLAND HWY&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 12:14:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; NON STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 01:14:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274902</guid>
      <dc:date>2008-01-28T01:14:00Z</dc:date>
    </item>
    <item>
      <title>HAMILTON</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274878</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 05&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; HAMILTON&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 12:03:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 01:03:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274878</guid>
      <dc:date>2008-01-28T01:03:00Z</dc:date>
    </item>
    <item>
      <title>BADGER CREEK, HANNOVER RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274901</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 13&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; BADGER CREEK, HANNOVER RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:56:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; NON STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:56:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274901</guid>
      <dc:date>2008-01-28T00:56:00Z</dc:date>
    </item>
    <item>
      <title>BEVERIDGE, HUME FWY</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274192</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 14&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; BEVERIDGE, HUME FWY&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:44:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:44:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274192</guid>
      <dc:date>2008-01-28T00:44:00Z</dc:date>
    </item>
    <item>
      <title>MARYBOROUGH, PALMERSTON ST</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274900</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 15&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; MARYBOROUGH, PALMERSTON ST&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:44:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; FALSE ALARM&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:44:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274900</guid>
      <dc:date>2008-01-28T00:44:00Z</dc:date>
    </item>
    <item>
      <title>CRANBOURNE, CODRINGTON ST</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274875</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; CRANBOURNE, CODRINGTON ST&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:32:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; FALSE ALARM&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:32:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274875</guid>
      <dc:date>2008-01-28T00:32:00Z</dc:date>
    </item>
    <item>
      <title>CRANBOURNE, CAMMS RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274876</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; CRANBOURNE, CAMMS RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:27:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:27:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274876</guid>
      <dc:date>2008-01-28T00:27:00Z</dc:date>
    </item>
    <item>
      <title>NORLANE, PLUME ST</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274877</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 07&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; NORLANE, PLUME ST&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:25:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; FALSE ALARM&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:25:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274877</guid>
      <dc:date>2008-01-28T00:25:00Z</dc:date>
    </item>
    <item>
      <title>BONEGILLA, UNNAMED -</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274874</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 24&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; BONEGILLA, UNNAMED -&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:21:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; NON STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:21:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274874</guid>
      <dc:date>2008-01-28T00:21:00Z</dc:date>
    </item>
    <item>
      <title>DEVON MEADOWS, DEVON RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274873</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; DEVON MEADOWS, DEVON RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 11:01:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; NON STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Mon, 28 Jan 2008 00:01:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274873</guid>
      <dc:date>2008-01-28T00:01:00Z</dc:date>
    </item>
    <item>
      <title>COWES, GAP RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274872</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; COWES, GAP RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:51:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; GRASS&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Sun, 27 Jan 2008 23:51:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274872</guid>
      <dc:date>2008-01-27T23:51:00Z</dc:date>
    </item>
    <item>
      <title>TYABB, PEACOCK RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274196</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; TYABB, PEACOCK RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:46:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; INCIDENT&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; CONTROLLED&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 3</description>
      <pubDate>Sun, 27 Jan 2008 23:46:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274196</guid>
      <dc:date>2008-01-27T23:46:00Z</dc:date>
    </item>
    <item>
      <title>JUNCTION VILLAGE, CRAIG RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274869</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; JUNCTION VILLAGE, CRAIG RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:42:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; FALSE ALARM&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Sun, 27 Jan 2008 23:42:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274869</guid>
      <dc:date>2008-01-27T23:42:00Z</dc:date>
    </item>
    <item>
      <title>RHYLL, JANSSON RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274871</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 08&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; RHYLL, JANSSON RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:40:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; FALSE ALARM&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Sun, 27 Jan 2008 23:40:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274871</guid>
      <dc:date>2008-01-27T23:40:00Z</dc:date>
    </item>
    <item>
      <title>MURMUNGEE, UNKNOWN -</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274195</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 24&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; MURMUNGEE, UNKNOWN -&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:37:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; INCIDENT&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Sun, 27 Jan 2008 23:37:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274195</guid>
      <dc:date>2008-01-27T23:37:00Z</dc:date>
    </item>
    <item>
      <title>LARA, BELLCHAMBERS CT</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274194</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 07&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; LARA, BELLCHAMBERS CT&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 10:10:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; SAFE&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 0</description>
      <pubDate>Sun, 27 Jan 2008 23:10:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274194</guid>
      <dc:date>2008-01-27T23:10:00Z</dc:date>
    </item>
    <item>
      <title>BEULAH, ROSEBERY EAST RD</title>
      <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274193</link>
      <description>&lt;strong&gt;Region:&lt;/strong&gt; 18&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; BEULAH, ROSEBERY EAST RD&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 09:55:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; STRUCTURE&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; GOING&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; SMALL&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; 3</description>
      <pubDate>Sun, 27 Jan 2008 22:55:00 GMT</pubDate>
      <guid>http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=1992274193</guid>
      <dc:date>2008-01-27T22:55:00Z</dc:date>
    </item>
  </channel>
</rss>
".Replace('\'', '"');

		Stream IWebResponse.GetResponseStream()
		{
			return new MemoryStream(Encoding.ASCII.GetBytes(sampleRSS));
		}

		public bool CanHandle(string url)
		{
			return url == @"http://www.cfa.vic.gov.au/incidents/incident_summary_rss.xml";
		}
	}
}