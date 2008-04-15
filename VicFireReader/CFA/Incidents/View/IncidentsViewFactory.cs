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

using CFAReader.CFA.Data;
using CFAReader.CFA.Incidents.RSS;
using CFAReader.CFA.Regions;
using CFAReader.CFA.UI;
using NDependencyInjection;
using NDependencyInjection.interfaces;
using NoeticTools.GoogleMaps;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Persistence;


namespace CFAReader.CFA.Incidents.View
{
	public class IncidentsViewFactory : IIncidentsViewFactory
	{
		private readonly ICfaRegions cfaRegions;
		private readonly ISystemDefinition parentDefinition;

		public IncidentsViewFactory(ICfaRegions cfaRegions, ISystemDefinition parentDefinition)
		{
			this.cfaRegions = cfaRegions;
			this.parentDefinition = parentDefinition;
		}

		public ContentForm Create(IPluginHostServices hostServices)
		{
			ICFADataSet cfaDataSet = hostServices.GetService<ICFADataSet>();
			IPersistenceService persistenceService = hostServices.GetService<IPersistenceService>();
			IIncidentsRSSReader incidentsRSSReader = hostServices.GetService<IIncidentsRSSReader>();

#pragma warning disable 612,618
			ISystemDefinition system = new SystemDefinition((SystemDefinition)parentDefinition);
#pragma warning restore 612,618

			system.HasInstance(cfaRegions).Provides<ICfaRegions>();

			system.HasInstance(incidentsRSSReader).Provides<IIncidentsRSSReader>();
			system.HasInstance(cfaDataSet).Provides<ICFADataSet>();
			system.HasInstance(persistenceService).Provides<IPersistenceService>();

			system.HasSingleton<BrowserMapView>().Provides<IMapView>();

			system.HasSubsystem(new IncidentsViewBuilder()).Provides<ContentForm>();

			return system.Get<ContentForm>();
		}
	}
}
