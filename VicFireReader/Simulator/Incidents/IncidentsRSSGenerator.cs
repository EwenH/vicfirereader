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

using System.Text;


namespace VicFireReader.Simulator.Incidents
{
    public class IncidentsRSSGenerator
    {
        public string GetXml(params IIncidentRSSItem[] incidents)
        {
            string header =
                @"<?xml version='1.0' encoding='UTF-8'?>
<rss xmlns:taxo='http://purl.org/rss/1.0/modules/taxonomy/' xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#' xmlns:dc='http://purl.org/dc/elements/1.1/' version='2.0'>
  <channel>
    <title>Country Fire Authority - Victoria, Australia - Statewide Current Incident Summary</title>
    <link>http://www.cfa.vic.gov.au/incidents/incident_summary.htm</link>
    <description>Country Fire Authority - Victoria, Australia - CFA responds to a range of incidents across Victoria. Our current activity (over the previous 5 hours) is listed below.</description>
"
                    .Replace('\'', '"');
            string trailer =
                @"  </channel>
</rss>
".Replace('\'', '"');

            StringBuilder xml = new StringBuilder();
            xml.Append(header);

            foreach (IIncidentRSSItem incident in incidents)
            {
                xml.Append(incident.GetXml());
            }

            xml.Append(trailer);

            return xml.ToString();
        }
    }
}