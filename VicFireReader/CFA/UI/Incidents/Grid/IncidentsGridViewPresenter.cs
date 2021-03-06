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
using VicFireReader.CFA.Data;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.UI.Incidents.Grid
{
    public class IncidentsGridViewPresenter : IIncidentsGridViewPresenter
    {
        private readonly IIncidentsGridViewPresenterListener controller;
        private readonly IIncidentsGridView view;
        private readonly IIncidentsGridViewRowPresenterFactory rowPresenterFactory;
        private readonly Dictionary<IIncident, IIncidentsGridViewRowPresenter> rowPresenters =
            new Dictionary<IIncident, IIncidentsGridViewRowPresenter>();

        public IncidentsGridViewPresenter(IIncidentsGridViewRowPresenterFactory rowPresenterFactory,
                                          IIncidentsGridViewPresenterListener controller, IIncidentsGridView view)
        {
            this.rowPresenterFactory = rowPresenterFactory;
            this.controller = controller;
            this.view = view;
        }

        public void ShowIncident(IIncident incident)
        {
            IIncidentsGridViewRowPresenter rowPresenter = rowPresenterFactory.Create(incident);
            rowPresenters.Add(incident, rowPresenter);
            rowPresenter.Show();
        }

        public void OnDoubleClick(CFADataSet.IncidentsRow row)
        {
            controller.OnShowOnMap(row.Location);
        }

        public void OnFormattingChanged()
        {
            view.Invalidate(true);
        }

        public void OnIncidentChanged(IIncident incident)
        {
            rowPresenters[incident].OnChanged();
        }
    }
}