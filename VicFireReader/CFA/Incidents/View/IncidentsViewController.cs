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

using NoeticTools.PlugIns;
using VicFireReader.CFA.Regions.View;
using VicFireReader.CFA.UI;
using WeifenLuo.WinFormsUI.Docking;


namespace VicFireReader.CFA.Incidents.View
{
    public class IncidentsViewController : IIncidentsViewController
    {
        private readonly ContentForm contentForm;
        private readonly IRegionsComboBoxController regionSelectionController;
        private readonly IIncidentsView view;

        public IncidentsViewController(IIncidentsView view, ContentForm contentForm,
                                       IRegionsComboBoxController regionSelectionController)
        {
            this.view = view;
            this.contentForm = contentForm;
            this.regionSelectionController = regionSelectionController;
        }

        public void Show(IPluginHostServices hostServices)
        {
            hostServices.Show(contentForm, DockState.Document);
            regionSelectionController.Start();
        }

        public void Close()
        {
            contentForm.Close();
        }
    }
}