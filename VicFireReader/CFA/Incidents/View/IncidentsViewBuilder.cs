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

using NDependencyInjection.interfaces;
using NoeticTools.DotNetWrappers.Windows.Forms;
using NoeticTools.GoogleMaps;
using NoeticTools.PlugIns.Menus;
using VicFireReader.CFA.Incidents.View.Grid;
using VicFireReader.CFA.Regions;
using VicFireReader.CFA.Regions.View;
using VicFireReader.CFA.UI;


namespace VicFireReader.CFA.Incidents.View
{
    public class IncidentsViewBuilder : ISubsystemBuilder
    {
        private readonly int viewID;

        public IncidentsViewBuilder(int viewID)
        {
            this.viewID = viewID;
        }

        public void Build(ISystemDefinition system)
        {
            system.Broadcasts<IFormClosedListener>();

            system.HasSingleton<CfaRegions>()
                .Provides<ICfaRegions>();

            system.HasInstance(viewID)
                .Provides<int>();

            system.HasSingleton<BrowserMapView>()
                .Provides<IMapView>();

            system.HasSubsystem(new RegionsComboBoxBuilder())
                .Provides<IRegionsComboBoxController>()
                .Provides<IComboBox>();

            system.HasSubsystem(new IncidentsGridViewBuilder())
                .ListensTo<IFormClosedListener>()
                .Provides<IIncidentsGridView>();

            system.HasSingleton<IncidentsViewController>()
                .Provides<IIncidentsViewController>();

            system.HasSingleton<IncidentsView>()
                .Provides<IIncidentsView>()
                .Provides<ContentForm>();
        }
    }
}