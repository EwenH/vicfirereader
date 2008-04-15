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
using CFAReader.Interfaces;
using CFAReader.Simulator.General;
using NDependencyInjection.interfaces;
using NoeticTools.DotNetWrappers;
using NoeticTools.Utilities;


namespace CFAReader.Simulator
{
	public class SimulatorBuilder : ISubsystemBuilder
	{
		public void Build(ISystemDefinition system)
		{
			system.HasSingleton<SimulatedClock>()
				.Provides<ISimulatedClock>()
				.Provides<IClock>();

			system.HasSingleton<ConnectionView>().Provides<ConnectionView>();

			system.HasSingleton<SimulatedHttpWebRequestFactory>()
				.Provides<IHttpWebRequestFactory>();

			List<IPluginBuilder> pluginBuilders = system.Get<List<IPluginBuilder>>();
			pluginBuilders.Add(new SimulatorPluginBuilder());
		}
	}
}
