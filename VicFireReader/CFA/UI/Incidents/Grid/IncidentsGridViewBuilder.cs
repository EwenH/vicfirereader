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
using NoeticTools.PlugIns.Menus;
using VicFireReader.CFA.Incidents;
using VicFireReader.CFA.Regions;


namespace VicFireReader.CFA.UI.Incidents.Grid
{
    public class IncidentsGridViewBuilder : ISubsystemBuilder
    {
        public void Build(ISystemDefinition system)
        {
            system.HasSingleton<IncidentsGridView>()
                .Provides<IIncidentsGridView>();

            system.HasSingleton<IncidentsGridViewCellFormatter>()
                .Provides<IIncidentGridViewCellFormatter>()
                .Provides<ICfaRegionsChangedListener>()
                .Provides<IFormClosedListener>();

            system.HasSingleton<IncidentsGridViewRowPresenterFactory>()
                .Provides<IIncidentsGridViewRowPresenterFactory>();

            system.HasSingleton<IncidentsGridViewPresenter>()
                .Provides<IIncidentsGridViewPresenter>();

            system.HasSingleton<IncidentsGridViewController>()
                .ListensTo<IIncidentsListener>()
                .ListensTo<IIncidentChangeListener>()
                .Provides<IFormatterListener>()
                .Provides<IIncidentsGridViewPresenterListener>();
        }
    }
}