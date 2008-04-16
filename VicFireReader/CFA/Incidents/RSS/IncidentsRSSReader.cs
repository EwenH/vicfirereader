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

using System.Collections.Generic;
using System.Data;
using System.Xml;
using VicFireReader.CFA.Data;
using NoeticTools.RSS;


namespace VicFireReader.CFA.Incidents.RSS
{
	public class IncidentsRSSReader : IIncidentsRSSReader, IRSSReaderListener, IRSSOptionsChangedListener
	{
		private readonly ICFADataSet dataSet;
		private readonly IIncidentFactory incidentFactory;
		private readonly List<IIncidentsListener> listeners = new List<IIncidentsListener>();
		private readonly IRSSReaderFactory rssReaderFactory;
		private IIncidentsRSSReaderOptions options;
		private IRSSReader rssReader;

		public IncidentsRSSReader(IRSSReaderFactory rssReaderFactory, ICFADataSet dataSet, IIncidentFactory incidentFactory)
		{
			this.rssReaderFactory = rssReaderFactory;
			this.dataSet = dataSet;
			this.incidentFactory = incidentFactory;
		}

		void IIncidentsRSSReader.AddListener(IIncidentsListener listener)
		{
			listeners.Add(listener);
		}

		void IIncidentsRSSReader.RemoveListener(IIncidentsListener listener)
		{
			listeners.Remove(listener);
		}

		void IIncidentsRSSReader.Start(IIncidentsRSSReaderOptions readerOptions)
		{
			options = readerOptions;
			readerOptions.SetListener(this);
			CreateRssReader();
			rssReader.Start(readerOptions);
		}

		void IIncidentsRSSReader.Refresh()
		{
			rssReader.Refresh();
		}

		void IIncidentsRSSReader.Stop()
		{
			rssReader.Stop();
		}

		void IRSSOptionsChangedListener.OnOptionsChanged()
		{
			rssReader.Stop();
			CreateRssReader();
			rssReader.Start(options);
		}

		void IRSSReaderListener.OnRefresh(XmlDocument document)
		{
			CFADataSet.IncidentsDataTable incidentsTable = dataSet.Incidents;
			List<CFADataSet.IncidentsRow> incidentRows = CopyIncidentRows(incidentsTable);

			UpdateIncidents(document, incidentRows);

			RemoveIncidentsNotUpdated(incidentRows);

			foreach (IIncidentsListener listener in listeners)
			{
				listener.OnSuccessfullUpdate();
			}
		}

		void IRSSReaderListener.OnFailure()
		{
			foreach (IIncidentsListener listener in listeners)
			{
				listener.OnFailure();
			}
		}

		private void CreateRssReader()
		{
			rssReader = rssReaderFactory.Create(this);
		}

		private void UpdateIncidents(XmlNode xmlNode, ICollection<CFADataSet.IncidentsRow> incidentRows)
		{
			XmlNodeList incidentNodes = xmlNode.SelectNodes("/rss/channel/item");
			foreach (XmlNode incidentNode in incidentNodes)
			{
				IIncident incident = incidentFactory.Create(incidentNode);
				CFADataSet.IncidentsRow updatedRow = incident.Update(dataSet.Incidents);

				if (incidentRows.Contains(updatedRow))
				{
					incidentRows.Remove(updatedRow);
				}
			}
		}

		private void RemoveIncidentsNotUpdated(IEnumerable<CFADataSet.IncidentsRow> incidentRows)
		{
			foreach (CFADataSet.IncidentsRow unupdatedRow in incidentRows)
			{
				dataSet.Incidents.RemoveIncidentsRow(unupdatedRow);
			}
		}

		private static List<CFADataSet.IncidentsRow> CopyIncidentRows(DataTable incidentsTable)
		{
			List<CFADataSet.IncidentsRow> incidentRows = new List<CFADataSet.IncidentsRow>();
			foreach (CFADataSet.IncidentsRow row in incidentsTable.Rows)
			{
				incidentRows.Add(row);
			}
			return incidentRows;
		}
	}
}