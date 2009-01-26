#region Copyright

// The contents of this file are subject to the Mozilla Public License
//  Version 1.1 (the "License"); you may not use this file except in compliance
//  with the License. You may obtain a copy of the License at
//  
//  http://www.mozilla.org/MPL/
//  
//  Software distributed under the License is distributed on an "AS IS"
//  basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
//  License for the specific language governing rights and limitations under 
//  the License.
//  
//  The Initial Developer of the Original Code is Robert Smyth.
//  Portions created by Robert Smyth are Copyright (C) 2008.
//  
//  All Rights Reserved.

#endregion

using System;
using System.Text;


namespace VicFireReader.Simulator.Incidents
{
    public class IncidentRSSItem : IIncidentRSSItem
    {
        private readonly int itemID;
        private readonly DateTime publicationTime;
        private readonly int regionID;
        private readonly string size;
        private readonly string status;
        private readonly string title;
        private readonly int vehicles;

        public IncidentRSSItem(int regionID, string title, DateTime publicationTime, int itemID, string status,
                               string size,
                               int vehicles)
        {
            this.regionID = regionID;
            this.title = title;
            this.publicationTime = publicationTime;
            this.itemID = itemID;
            this.status = status;
            this.size = size;
            this.vehicles = vehicles;
        }

        public string GetXml()
        {
            DateTime publicationTimeUTC = publicationTime.ToUniversalTime();

            StringBuilder xml = new StringBuilder();

            xml.AppendLine("<item>");

            AppendElement(xml, "title", title.ToUpper());
            AppendElement(xml, "link", "http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=" + itemID);

            string description = string.Format(
                "&lt;strong&gt;Region:&lt;/strong&gt; {0}&lt;br&gt;&lt;strong&gt;Location:&lt;/strong&gt; {1}&lt;br&gt;&lt;strong&gt;Date/Time:&lt;/strong&gt; 28/01/2008 14:28:00&lt;br&gt;&lt;strong&gt;Type:&lt;/strong&gt; OTHER&lt;br&gt;&lt;strong&gt;Status:&lt;/strong&gt; {2}&lt;br&gt;&lt;strong&gt;Size:&lt;/strong&gt; {3}&lt;br&gt;&lt;strong&gt;Vehicles:&lt;/strong&gt; {4}",
                regionID, title.ToUpper(), status.ToUpper(), size.ToUpper(), vehicles);

            AppendElement(xml, "description", description);

            AppendElement(xml, "pubDate", publicationTimeUTC.ToString("r"));
            AppendElement(xml, "guid", "http://www.cfa.vic.gov.au/incidents/incident_summary.htm?tm=" + itemID);

            string dcDate = string.Format("{0}-{1:d2}-{2:d2}T{3:d2}:{4:d2}:{5:d2}Z",
                                          publicationTimeUTC.Year, publicationTimeUTC.Month, publicationTimeUTC.Day,
                                          publicationTimeUTC.Hour, publicationTimeUTC.Minute, publicationTimeUTC.Second);
            AppendElement(xml, "dc:date", dcDate);

            xml.AppendLine("</item>");

            return xml.ToString();
        }

        private static void AppendElement(StringBuilder xml, string name, string innerText)
        {
            xml.AppendFormat("<{0}>{1}</{0}>\r\n", name, innerText);
        }
    }
}