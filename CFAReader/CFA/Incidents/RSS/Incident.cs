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

#endregion //Copyright

using System;
using System.Text.RegularExpressions;
using System.Xml;
using CFAReader.CFA.Data;
using NoeticTools.Utilities;


namespace CFAReader.CFA.Incidents.RSS
{
	public class Incident : IIncident
	{
		private readonly XmlNode incidentNode;
		private readonly IClock clock;

		public Incident(XmlNode incidentNode, IClock clock)
		{
			this.incidentNode = incidentNode;
			this.clock = clock;
		}

		public CFADataSet.IncidentsRow Update(CFADataSet.IncidentsDataTable incidents)
		{
			return GetNewIncidentsRow(incidents);
		}

		private CFADataSet.IncidentsRow GetNewIncidentsRow(CFADataSet.IncidentsDataTable incidents)
		{
			string guid = incidentNode.SelectSingleNode("guid").InnerText;
			CFADataSet.IncidentsRow incidentRow = incidents.FindByGUID(guid);

			string description = incidentNode.SelectSingleNode("description").InnerText;

			if (incidentRow == null)
			{
				incidentRow = incidents.NewIncidentsRow();
				incidentRow.GUID = guid;

				UpdateFields(incidentRow, description);

				if (FilterRow(incidentRow))	// TODO: This is a view issue
				{
					incidents.Rows.Add(incidentRow);
				}
			}
			else
			{
				UpdateFields(incidentRow, description);
			}

			return incidentRow;
		}

		private void UpdateFields(CFADataSet.IncidentsRow incidentRow, string description)
		{
			Regex regex =
				new Regex(
					@".*Region:\</strong\> (?<region>..).*Location:\</strong\> (?<location>[^,\<]*),?(?<name>[^\<]*).*Date/Time:\</strong\> (?<timeStamp>[^\<]+).*Type\:\</strong\> (?<type>[^\<]*).*Status:</strong> (?<status>[^\<]*).*Size:</strong> (?<size>[^\<]*).*Vehicles:</strong> (?<appliances>[^\<]*).*");

			Match match = regex.Match(description);

			incidentRow.Region = GetInteger(match.Groups["region"].Value);
			incidentRow.Location = match.Groups["location"].Value.Trim();
			incidentRow.Time = DateTime.Parse(match.Groups["timeStamp"].Value);

			string name = match.Groups["name"].Value.Trim();
			string incidentType = match.Groups["type"].Value;
			string status = match.Groups["status"].Value;
			string size = match.Groups["size"].Value;
			short appliances = GetInteger(match.Groups["appliances"].Value);

			if (incidentRow.Name != name ||
			    incidentRow.Type != incidentType ||
			    incidentRow.Status != status ||
			    incidentRow.Size != size ||
			    incidentRow.Appliances != appliances)
			{
				incidentRow.UpdateTime = clock.Now;

				incidentRow.Name = name;
				incidentRow.Type = incidentType;
				incidentRow.Status = status;
				incidentRow.Size = size;
				incidentRow.Appliances = appliances;
			}
		}

		private static bool FilterRow(CFADataSet.IncidentsRow incidentRow)
		{
			return
				//incidentRow.Region == 13 && 

				incidentRow.Type != "INCIDENT" &&
				incidentRow.Type != "HAZMAT INCIDENT" &&
				incidentRow.Type != "OTHER" &&
				incidentRow.Type != "FALSE ALARM";
		}

		private static short GetInteger(string text)
		{
			return (text == string.Empty) ? (short)0 : short.Parse(text);
		}
	}
}