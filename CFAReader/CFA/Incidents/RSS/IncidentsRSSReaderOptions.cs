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

using System;
using System.ComponentModel;
using NoeticTools.RSS;


namespace CFAReader.CFA.Incidents.RSS
{
	public class IncidentsRSSReaderOptions : IIncidentsRSSReaderOptions
	{
		private string rssUrl = defaultUrl;
		private TimeSpan updatePeriod = TimeSpan.FromMinutes(1);
		public const string defaultUrl = @"http://www.cfa.vic.gov.au/incidents/incident_summary_rss.xml";
		private IRSSOptionsChangedListener listener;

		[Browsable(true), Category("RSS"), DisplayName("URL"), Description("Incidents RSS URL.")]
		[DefaultValue(defaultUrl)]
		public string Url
		{
			get { return rssUrl; }
			set
			{
				rssUrl = value;
				OptionsChangedNotification();
			}
		}

		[Browsable(true), Category("RSS"), DisplayName("Update period"), Description("Incidents update period.")]
		[DefaultValue("1:00")]
		public TimeSpan UpdatePeriod
		{
			get { return updatePeriod; }
			set
			{
				updatePeriod = value;
				OptionsChangedNotification();
			}
		}

		[Browsable(false)]
		public string OptionsName
		{
			get { return "Incidents"; }
		}

		void IRSSReaderOptions.SetListener(IRSSOptionsChangedListener changedListener)
		{
			listener = changedListener;
		}

		protected void OptionsChangedNotification()
		{
			if (listener != null)
			{
				listener.OnOptionsChanged();
			}
		}
	}
}
