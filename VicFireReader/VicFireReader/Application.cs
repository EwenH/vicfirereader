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

using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using NDependencyInjection;
using NDependencyInjection.interfaces;
using NoeticTools.DotNetWrappers;
using NoeticTools.PlugIns;
using NoeticTools.PlugIns.Menus;
using NoeticTools.PlugIns.Persistence;
using NoeticTools.PlugIns.StatusBar;
using NoeticTools.PlugIns.ToolBar;
using NoeticTools.Utilities;
using VicFireReader.CFA;
using VicFireReader.CFA.Data;
using VicFireReader.CFA.Incidents;
using VicFireReader.CFA.Options;
using VicFireReader.Images;
using VicFireReader.Interfaces;
using VicFireReader.Simulator;
using VicFireReader.UI;
using Timer=System.Windows.Forms.Timer;


namespace VicFireReader
{
    public class VicFireReaderApplication
    {
        private readonly IApplicationOptions applicationOptions;
        private readonly string[] toolBarOdering = new string[] {"Refresh", "Options"};

        public VicFireReaderApplication(IApplicationOptions applicationOptions)
        {
            this.applicationOptions = applicationOptions;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        public void Run()
        {
            ISystemDefinition system = new SystemDefinition();

            system.Broadcasts<IIncidentsListener>();

            system.HasInstance(new NoeticTools.DotNetWrappers.Timer(new Timer())).Provides<ITimer>();

            system.HasSingleton<Scheduler>()
                .Provides<IScheduler>();

            system.HasSingleton<ScheduledEventFactory>()
                .Provides<IScheduledEventFactory>();

            system.HasSingleton<ImageResources>()
                .Provides<IImageResources>();

            system.HasInstance(new List<IPluginBuilder>()).Provides<List<IPluginBuilder>>();

            system.HasSubsystem(new IncidentsBuilder())
                .Provides<IIncidents>();

            string title;
            if (!applicationOptions.Simulate)
            {
                system.HasSingleton<Clock>()
                    .Provides<IClock>();
                system.HasSingleton<HttpWebRequestFactory>()
                    .Provides<IHttpWebRequestFactory>();
                title = "VicFireReader";
            }
            else
            {
                system.HasSubsystem(new SimulatorBuilder())
                    .Provides<ISimulatedClock>()
                    .Provides<IClock>()
                    .Provides<IHttpWebRequestFactory>();

                title = "VicFireReader == SIMULATED ==";
            }

            system.HasSingleton<VicFireReaderSettings>()
                .Provides<VicFireReaderSettings>();

            system.HasSingleton<CFADataSet>()
                .Provides<ICFADataSet>();

            system.HasInstance(GetType().Assembly)
                .Provides<Assembly>();

            system.HasSingleton<PersistenceService>()
                .Provides<IPersistenceService>();

            system.HasSubsystem(new MainFormBuilder(title))
                .Provides<Form>()
                .Provides<IPluginHost>()
                .Provides<OptionsViewPlugin>()
                .Provides<IMenuStrip>()
                .Provides<IToolStrip>()
                .Provides<IStatusStrip>();

            system.Get<IPluginHost>().Register(new ToolStripMenuServicePlugIn(system.Get<IMenuStrip>()));
            system.Get<IPluginHost>().Register(new ToolBarServicePlugin(system.Get<IToolStrip>(), toolBarOdering));
            system.Get<IPluginHost>().Register(new StatusStripPlugin(system.Get<IStatusStrip>()));
            system.Get<IPluginHost>().Register(system.Get<OptionsViewPlugin>());

            system.HasSubsystem(new PluginsBuilder())
                .Provides<IPlugin[]>();

            system.Get<IPluginHost>().Register(system.Get<IPlugin[]>());

            system.Get<IScheduler>().Start();
            Application.Run(system.Get<Form>());
        }

        public static void Exit()
        {
            Application.Exit();
        }
    }
}