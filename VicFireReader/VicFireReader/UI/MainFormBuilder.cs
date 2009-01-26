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

using System.Windows.Forms;
using NDependencyInjection.interfaces;
using NoeticTools.DotNetWrappers;
using NoeticTools.PlugIns;
using VicFireReader.CFA.Options;
using WeifenLuo.WinFormsUI.Docking;
using MenuStrip=System.Windows.Forms.MenuStrip;
using StatusStrip=System.Windows.Forms.StatusStrip;
using ToolStrip=System.Windows.Forms.ToolStrip;


namespace VicFireReader.UI
{
    public class MainFormBuilder : ISubsystemBuilder
    {
        private readonly string title;

        public MainFormBuilder(string title)
        {
            this.title = title;
        }

        public void Build(ISystemDefinition system)
        {
            system.HasInstance(title).Provides<string>();

            system.HasSingleton<OptionsViewPlugin>()
                .Provides<OptionsViewPlugin>()
                .Provides<IOptionsView>();

            system.HasSingleton<PlugInHost>()
                .Provides<IPluginHost>();

            system.HasSingleton<PlugInHostServices>()
                .Provides<IPluginHostServices>();

            system.HasSingleton<DockPanel>()
                .Provides<DockPanel>();

            system.HasSingleton<MDIParent>()
                .Provides<Form>();

            system.HasInstance(system.Get<Form>().Controls["menuStrip"])
                .Provides<MenuStrip>();

            system.HasSingleton<NoeticTools.DotNetWrappers.MenuStrip>()
                .Provides<IMenuStrip>();

            system.HasInstance(system.Get<Form>().Controls["toolStrip"])
                .Provides<ToolStrip>();
            system.HasSingleton<NoeticTools.DotNetWrappers.ToolStrip>()
                .Provides<IToolStrip>();

            system.HasInstance(system.Get<Form>().Controls["statusStrip"])
                .Provides<StatusStrip>();
            system.HasSingleton<NoeticTools.DotNetWrappers.StatusStrip>().Provides<IStatusStrip>();
        }
    }
}