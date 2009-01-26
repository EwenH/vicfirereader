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
using System.Windows.Forms;


namespace VicFireReader.UI
{
    public class TaskBarNotifyIcon
    {
        private readonly NotifyIcon notifyIcon;

        // TODO: Requires background task and creation 'as required' of the UI

        public TaskBarNotifyIcon(IContainer components, Form form)
        {
            notifyIcon = new NotifyIcon(components);
            notifyIcon.Icon = form.Icon;
            notifyIcon.Text = "VicFireReader";
            notifyIcon.Visible = true;
            ContextMenu contextMenu = new ContextMenu(
                new MenuItem[]
                    {
                        new MenuItem("Show Window", ShowWindowClick),
                        new MenuItem("Exit", ExitClick),
                    });
            notifyIcon.ContextMenu = contextMenu;
        }

        private void ShowWindowClick(object sender, EventArgs eventArgs)
        {
        }

        private void ExitClick(object sender, EventArgs eventArgs)
        {
        }
    }
}