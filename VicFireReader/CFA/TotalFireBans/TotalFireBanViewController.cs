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

using System.Xml;
using NoeticTools.Html.UI;
using NoeticTools.RSS;


namespace VicFireReader.CFA.TotalFireBans
{
    public class TotalFireBanViewController : IRSSReaderListener
    {
        private readonly IRSSReader rssReader;
        private readonly IHtmlView view;

        public TotalFireBanViewController(IRSSReaderFactory rssReaderFactory, IHtmlView view)
        {
            rssReader = rssReaderFactory.Create(this);
            this.view = view;
        }

        void IRSSReaderListener.OnRefresh(XmlDocument document)
        {
            XmlNodeList incidentNodes = document.SelectNodes("/rss/channel/item");

            if (incidentNodes.Count == 0)
            {
                view.Refresh("Error reading feed.");
            }
            else
            {
                FireBanItem fireBanItem = new FireBanItem(incidentNodes[incidentNodes.Count - 1]);
                view.Refresh(fireBanItem.GetHtmlDocumentText());
            }
        }

        public void OnFailure()
        {
            view.Refresh(@"<html>
<body>
<p>RSS read error.</p>
</body>
</html>
");
        }

        public void Start(ITotalFireBanOptions rssOptions)
        {
            rssReader.Start(rssOptions.RssOptions);
        }
    }
}