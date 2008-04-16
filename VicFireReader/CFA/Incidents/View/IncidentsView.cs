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
using System.Windows.Forms;
using VicFireReader.CFA.Incidents.RSS;
using VicFireReader.CFA.UI;
using NDependencyInjection;


namespace VicFireReader.CFA.Incidents.View
{
	public partial class IncidentsView : ContentForm, IIncidentsListener
	{
		private readonly IFormClosedListener formClosedListener;
		private readonly IIncidentsRSSReader incidentsReader;

		public IncidentsView()
		{
			InitializeComponent();
		}

		[InjectionConstructor]
		public IncidentsView(IIncidentsGridView incidentsGridView, IIncidentsRSSReader incidentsReader,
		                     IFormClosedListener formClosedListener)
			: this()
		{
			this.incidentsReader = incidentsReader;
			this.formClosedListener = formClosedListener;
			incidentsGridViewPlaceHolder.AddControl((Control) incidentsGridView);
		}

		void IIncidentsListener.OnSuccessfullUpdate()
		{
			ClearError();
		}

		void IIncidentsListener.OnFailure()
		{
			SetError("Unable to read incidents.");
		}

		private void IncidentsView_Load(object sender, EventArgs e)
		{
			incidentsReader.AddListener(this);
		}

		private void IncidentsView_FormClosing(object sender, FormClosingEventArgs e)
		{
			incidentsReader.RemoveListener(this);
			formClosedListener.FormClosed();
		}
	}
}