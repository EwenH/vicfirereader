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
using NDependencyInjection.interfaces;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Persistence;
using VicFireReader.CFA.Data;
using VicFireReader.CFA.FireDangerIndex.RSS;
using VicFireReader.CFA.FireDangerIndex.View;
using VicFireReader.CFA.Incidents.RSSReader;
using VicFireReader.CFA.Incidents.View;
using VicFireReader.CFA.TotalFireBans.View;
using VicFireReader.Interfaces;


namespace VicFireReader
{
    public class PluginsBuilder : ISubsystemBuilder
    {
        public void Build(ISystemDefinition system)
        {
            system.HasSubsystem(new IncidentsRssReaderBuilder())
                .Provides<IIncidentsRSSReaderOptions>()
                .Provides<IIncidentsRSSReader>();

            List<ISubsystemBuilder> pluginBuilders = new List<ISubsystemBuilder>(
                new ISubsystemBuilder[]
                    {
                        new PluginBuilder<PersistenceServicePlugIn>(),
                        new PluginBuilder<DataSetPlugIn>(),
                        new PluginBuilder<FireDangerForecastRSSReaderPlugin>(),
                        new PluginBuilder<FireDangerForecastViewPlugin>(),
                        new PluginBuilder<IncidentsRSSReaderPlugin>(),
                        new IncidentsViewPluginBuilder(),
                        new TotalFireBanViewPluginBuilder()
                    }
                );

            List<IPluginBuilder> plugins = system.Get<List<IPluginBuilder>>();
            foreach (IPluginBuilder pluginBuilder in plugins)
            {
                pluginBuilders.Add(pluginBuilder);
            }

            system.HasCollection(pluginBuilders.ToArray()).Provides<IPlugin[]>();
        }
    }
}