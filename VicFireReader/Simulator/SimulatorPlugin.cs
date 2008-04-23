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

using VicFireReader.Simulator.General;
using NoeticTools.PlugIns;
using VicFireReader.Simulator.Incidents;
using WeifenLuo.WinFormsUI.Docking;


namespace VicFireReader.Simulator
{
	public class SimulatorPlugin : IPlugin, IOnOpenListener
	{
		private readonly ConnectionView generalView;
		private readonly IIncidentEditView incidentEditView;
		private IPluginHostServices hostServices;

		public SimulatorPlugin(ConnectionView generalView, IIncidentEditView incidentEditView)
		{
			this.generalView = generalView;
			this.incidentEditView = incidentEditView;
		}

		void IPlugin.Accept(IPluginHostServices services)
		{
			services.AddOnOpenListener(this);
		}

		void IOnOpenListener.OnOpen(IPluginHostServices services)
		{
			hostServices = services;

			hostServices.Show(generalView, DockState.DockRight);
			hostServices.Show((DockContent)incidentEditView, DockState.DockRight);
		}

		void IOnOpenListener.OnClosing()
		{
		}
	}
}
