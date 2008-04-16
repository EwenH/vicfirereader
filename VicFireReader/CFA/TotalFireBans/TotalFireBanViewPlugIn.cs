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
using NoeticTools.Html.UI;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Menus;
using NoeticTools.PlugIns.Persistence;
using NoeticTools.RSS;
using WeifenLuo.WinFormsUI.Docking;


namespace VicFireReader.CFA.TotalFireBans
{
	public class TotalFireBanViewPlugin : IPlugin, IOnOpenListener, IViewController
	{
		private readonly IRSSReaderFactory rssReaderFactory;
		private HtmlView totalFireBansView;
		private IPluginHostServices hostServices;
		private readonly ITotalFireBanOptions options;

		public TotalFireBanViewPlugin(IRSSReaderFactory rssReaderFactory, ITotalFireBanOptions options)
		{
			this.rssReaderFactory = rssReaderFactory;
			this.options = options;
		}

		void IOnOpenListener.OnOpen(IPluginHostServices services)
		{
			hostServices = services;
			IViewFormMenuItem menuItem = new ViewFormMenuItem("Fire &Bans", hostServices, this);
			menuItem.ToggleViewShown();
		}

		void IOnOpenListener.OnClosing()
		{
		}

		void IPlugin.Accept(IPluginHostServices services)
		{
			hostServices = services;

			IPersistenceService persistenceService = hostServices.GetService<IPersistenceService>();
			options.RssOptions = persistenceService.RegisterScope("TotalFireBanRSSReader", UpdatePersistence, options.RssOptions);
			hostServices.OptionsView.AddProperties(options.RssOptions);

			hostServices.AddOnOpenListener(this);
		}

		Form IViewController.Show()
		{
			totalFireBansView = new HtmlView();
			totalFireBansView.Text = "Total Fire Bans";
			totalFireBansView.TabText = "Total Fire Bans";
			TotalFireBanViewController totalFireBanViewController = new TotalFireBanViewController(rssReaderFactory, totalFireBansView);
			hostServices.Show(totalFireBansView, DockState.DockLeft);

			totalFireBanViewController.Start(options);

			return totalFireBansView;
		}

		void IViewController.Close()
		{
			totalFireBansView.Close();
		}

		private object UpdatePersistence()
		{
			return options.RssOptions;
		}
	}
}