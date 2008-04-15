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

using System.Collections.Generic;
using CFAReader.CFA;
using CFAReader.CFA.Data;
using CFAReader.CFA.FireDangerIndex.RSS;
using CFAReader.CFA.FireDangerIndex.View;
using CFAReader.CFA.Incidents.RSS;
using CFAReader.CFA.Incidents.View;
using CFAReader.CFA.Regions;
using CFAReader.CFA.TotalFireBans;
using CFAReader.Interfaces;
using NDependencyInjection.interfaces;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Persistence;


namespace CFAReader
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
					new RegionsPluginBuilder(),
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