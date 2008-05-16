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

using VicFireReader.CFA.Data;


namespace VicFireReader.Simulator.Incidents
{
	public class IncidentEditPanelController : IIncidentEditPanelController
	{
		private readonly CFADataSet.IncidentsDataTable incidents;
		private readonly IIncidentEditPanel panel;
		private int currentIndicentIndex = 0;

		public IncidentEditPanelController(IIncidentEditPanel panel, ICFADataSet dataSet)
		{
			this.panel = panel;
			incidents = dataSet.Incidents;
		}

		public void OnNextButtonClick()
		{
			SelectIncident(currentIndicentIndex + 1);
		}

		public void OnPrevButtonClick()
		{
			SelectIncident(currentIndicentIndex - 1);
		}

		private void SelectIncident(int incidentIndex)
		{
			if (incidentIndex < 0)
			{
				incidentIndex = incidents.Rows.Count - 1;
			}
			else if (incidentIndex >= incidents.Rows.Count)
			{
				incidentIndex = 0;
			}
			currentIndicentIndex = incidentIndex;

			UpdatePanel();
		}

		public void Start()
		{
			UpdatePanel();

			incidents.IncidentsRowChanging += incidents_IncidentsRowChanging;
		}

		private void incidents_IncidentsRowChanging(object sender, CFADataSet.IncidentsRowChangeEvent e)
		{
			UpdatePanel();
		}

		private void UpdatePanel()
		{
			if (incidents.Rows.Count > 0)
			{
				if (currentIndicentIndex >= incidents.Rows.Count)
				{
					currentIndicentIndex = incidents.Rows.Count - 1;
				}

				CFADataSet.IncidentsRow incident = GetIncident();

				panel.SetGuid(incident.GUID);
				panel.SetName(incident.Name);
				panel.SetLocation(incident.Location);
				panel.SetType(incident.Type);
				panel.SetStatus(incident.Status);
				panel.SetSize(incident.Size);
				panel.SetPublicationTime(incident.Time);
				panel.SetUpdateTime(incident.UpdateTime);
				panel.SetRegion(incident.Region);
				panel.SetVehicles(incident.Appliances);
			}
		}

		private CFADataSet.IncidentsRow GetIncident()
		{
			return (CFADataSet.IncidentsRow) incidents.Rows[currentIndicentIndex];
		}
	}
}