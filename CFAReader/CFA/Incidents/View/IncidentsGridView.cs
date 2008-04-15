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

using System.Data;
using System.Windows.Forms;
using CFAReader.CFA.Data;
using NDependencyInjection;


namespace CFAReader.CFA.Incidents.View
{
	public partial class IncidentsGridView : UserControl, IIncidentsGridView
	{
		private readonly IIncidentGridViewCellFormatter cellFormatter;
		private readonly IIncidentsGridViewListener controller;

		public IncidentsGridView()
		{
			InitializeComponent();
		}

		[InjectionConstructor]
		public IncidentsGridView(ICFADataSet dataSet, IIncidentsGridViewListener controller,
		                         IIncidentGridViewCellFormatter cellFormatter)
			: this()
		{
			this.controller = controller;
			this.cellFormatter = cellFormatter;
			dataGridView.DataSource = dataSet.Incidents;
		}

		private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewRow viewRow = dataGridView.Rows[e.RowIndex];
			cellFormatter.Format(e, viewRow);
		}

		private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow viewRow = dataGridView.CurrentRow;
				if (viewRow != null)
				{
					DataRowView rowView = (DataRowView) viewRow.DataBoundItem;
					CFADataSet.IncidentsRow incidentRow = (CFADataSet.IncidentsRow) rowView.Row;

					controller.OnDoubleClick(incidentRow);
				}
			}
		}
	}
}