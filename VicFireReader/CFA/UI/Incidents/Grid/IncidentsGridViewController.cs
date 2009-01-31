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

using NoeticTools.GoogleMaps;
using VicFireReader.CFA.Data;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.UI.Incidents.Grid
{
    public class IncidentsGridViewController : IIncidentsGridViewListener, IIncidentsGridViewController,
                                               IFormatterListener, IIncidentsListener
    {
        private readonly IMapView mapView;
        private readonly IIncidentsGridView view;

        public IncidentsGridViewController(IIncidentsGridView incidentsGirdView, IMapView mapViewer)
        {
            view = incidentsGirdView;
            mapView = mapViewer;
        }

        void IFormatterListener.OnFormattingChanged()
        {
            view.Invalidate(true);
        }

        void IIncidentsGridViewListener.OnDoubleClick(CFADataSet.IncidentsRow incident)
        {
            IncidentLocation incidentLocation = new IncidentLocation(incident.Location);
            mapView.Show(incidentLocation.ToString());
        }

        void IIncidentsListener.OnIncidentChanged(IIncident existingIncident)
        {
        }

        void IIncidentsListener.OnIncidentAdded(IIncident readIncident)
        {
        }

        void IIncidentsListener.OnIncidentRemoved()
        {
        }
    }
}