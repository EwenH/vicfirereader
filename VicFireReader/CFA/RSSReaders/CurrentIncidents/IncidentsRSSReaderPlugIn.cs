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
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Persistence;
using VicFireReader.Images;


namespace VicFireReader.CFA.RSSReaders.CurrentIncidents
{
    public class IncidentsRSSReaderPlugin : IPlugin, IOnOpenListener
    {
        private readonly IIncidentsRSSReader incidentsRSSReader;
        private IIncidentsRSSReaderOptions options;

        public IncidentsRSSReaderPlugin(IIncidentsRSSReader incidentsRSSReader, IIncidentsRSSReaderOptions options)
        {
            this.incidentsRSSReader = incidentsRSSReader;
            this.options = options;
        }

        void IOnOpenListener.OnOpen(IPluginHostServices hostServices)
        {
            incidentsRSSReader.Start(options);
        }

        void IOnOpenListener.OnClosing()
        {
            incidentsRSSReader.Stop();
        }

        void IPlugin.Accept(IPluginHostServices hostServices)
        {
            ImageResources imageResources = new ImageResources();
            hostServices.ToolStrip.AddButton("Refresh RSS", imageResources.GetImage("page_refresh.gif"),
                                             onRefreshRSSButtonClicked, "Refresh");

            IPersistenceService persistenceService = hostServices.GetService<IPersistenceService>();
            options = persistenceService.RegisterScope("IncidentsRSSReader", UpdatePersistence, options);
            hostServices.OptionsView.AddProperties(options);

            hostServices.AddService(incidentsRSSReader);

            hostServices.AddOnOpenListener(this);
        }

        private void onRefreshRSSButtonClicked(object sender, EventArgs e)
        {
            incidentsRSSReader.Refresh();
        }

        private object UpdatePersistence()
        {
            return options;
        }
    }
}