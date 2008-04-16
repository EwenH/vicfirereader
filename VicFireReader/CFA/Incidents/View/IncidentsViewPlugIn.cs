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

#endregion //Copyright

using System.Windows.Forms;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Menus;
using NoeticTools.PlugIns.Persistence;
using WeifenLuo.WinFormsUI.Docking;


namespace VicFireReader.CFA.Incidents.View
{
	public class IncidentsViewPlugIn : IPlugin, IOnOpenListener, IViewController
	{
		private readonly IIncidentsViewFactory factory;
		private DockContent incidentsView = null;
		private IncidentsViewPlugInConfig config;
		private IPluginHostServices hostServices;

		public IncidentsViewPlugIn(IIncidentsViewFactory factory)
		{
			this.factory = factory;
		}

		void IOnOpenListener.OnOpen(IPluginHostServices services)
		{
			hostServices = services;

			IPersistenceService persistenceService = hostServices.GetService<IPersistenceService>();

			config = persistenceService.RegisterScope("IncidentsViewPlugIn", UpdateConfig, new IncidentsViewPlugInConfig());

			IViewFormMenuItem menuItem = new ViewFormMenuItem("&Incidents", hostServices, this);
			menuItem.ToggleViewShown();
		}

		void IOnOpenListener.OnClosing()
		{
		}

		void IPlugin.Accept(IPluginHostServices hostServices)
		{
			hostServices.AddOnOpenListener(this);
		}

		private object UpdateConfig()
		{
			return config;
		}

		private void ShowIncidentsView()
		{
			incidentsView = factory.Create(hostServices);
			hostServices.Show(incidentsView, DockState.Document);
		}

		Form IViewController.Show()
		{
			ShowIncidentsView();
			return incidentsView;
		}

		void IViewController.Close()
		{
			incidentsView.Close();
			incidentsView = null;
		}
	}
}