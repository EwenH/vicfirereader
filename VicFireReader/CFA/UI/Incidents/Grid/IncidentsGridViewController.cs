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

using System.Collections.Generic;
using NoeticTools.GoogleMaps;
using VicFireReader.CFA.Data;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.UI.Incidents.Grid
{
    public class IncidentsGridViewController : IIncidentsGridViewPresenterListener, IIncidentsGridViewController,
                                               IFormatterListener, IIncidentsListener, IIncidentChangeListener
    {
        private readonly Dictionary<IIncident, IIncident> displayedIncidents = new Dictionary<IIncident, IIncident>();
        private readonly IMapView mapViewer;
        private readonly IIncidentsGridViewPresenter presenter;

        public IncidentsGridViewController(IMapView mapViewer, IIncidentsGridViewPresenter presenter)
        {
            this.mapViewer = mapViewer;
            this.presenter = presenter;
        }

        void IFormatterListener.OnFormattingChanged()
        {
            presenter.OnFormattingChanged();
        }

        void IIncidentChangeListener.OnIncidentChanged(IIncident changedIncident)
        {
            if (displayedIncidents.ContainsKey(changedIncident))
            {
                // >>> TODO - Filter incidents
                // >>> TODO - update view
            }
            else
            {
                ((IIncidentsListener) this).OnIncidentAdded(changedIncident);
            }
        }

        void IIncidentsGridViewPresenterListener.OnShowOnMap(CFADataSet.IncidentsRow incident)
        {
            IncidentLocation incidentLocation = new IncidentLocation(incident.Location);
            mapViewer.Show(incidentLocation.ToString());
        }

        void IIncidentsListener.OnIncidentAdded(IIncident newIncident)
        {
            // >>> TODO - Filter incidents
            displayedIncidents.Add(newIncident, newIncident);
            presenter.ShowIncident(newIncident);
        }

        void IIncidentsListener.OnIncidentRemoved(IIncident removedIncident)
        {
            // >>> TODO
        }
    }
}