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

using NDependencyInjection.interfaces;
using NoeticTools.PlugIns;
using CFAReader.CFA.Regions;


namespace CFAReader.CFA.Incidents.View
{
	public class IncidentsViewPluginBuilder : ISubsystemBuilder
	{
		public void Build(ISystemDefinition system)
		{
			system.HasInstance(new IncidentsViewFactory(system.Get<ICfaRegions>(), system)).Provides<IIncidentsViewFactory>();
			system.HasSingleton<IncidentsViewPlugIn>().Provides<IPlugin>();
		}
	}
}
