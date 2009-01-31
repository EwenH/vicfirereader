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

using System;
using System.ComponentModel;
using NoeticTools.RSS;


namespace VicFireReader.CFA.RSSReaders.TotalFireBans
{
    public class TotalFireBanRSSReaderOptions : ITotalFireBanRssOptions
    {
        public const string defaultUrl = @"http://www.cfa.vic.gov.au/incidents/tfb_rss.xml";
        private IRSSOptionsChangedListener listener;
        private string rssUrl = defaultUrl;
        private TimeSpan updatePeriod = TimeSpan.FromMinutes(15);

        [Browsable(true), Category("RSS"), DisplayName("URL"), Description("Total Fire Ban RSS URL.")]
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

        [Browsable(true), Category("RSS"), DisplayName("Update period"), Description("Total Fire Ban update period.")]
        [DefaultValue("15:00")]
        public TimeSpan UpdatePeriod
        {
            get { return updatePeriod; }
            set
            {
                if (value >= TimeSpan.FromSeconds(15))
                {
                    updatePeriod = value;
                    OptionsChangedNotification();
                }
            }
        }

        [Browsable(false)]
        public string OptionsName
        {
            get { return "Total Fire Ban"; }
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