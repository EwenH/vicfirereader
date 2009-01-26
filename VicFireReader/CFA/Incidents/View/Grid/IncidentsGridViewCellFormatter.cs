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
using System.Drawing;
using System.Windows.Forms;
using NoeticTools.PlugIns.Menus;
using NoeticTools.Utilities;
using VicFireReader.CFA.Regions;


namespace VicFireReader.CFA.Incidents.View.Grid
{
    public class IncidentsGridViewCellFormatter : IIncidentGridViewCellFormatter, ICfaRegionsChangedListener,
                                                 IFormClosedListener
    {
        private readonly ICfaRegions cfaRegions;
        private readonly IClock clock;
        private readonly IFormatterListener listener;

        public IncidentsGridViewCellFormatter(ICfaRegions cfaRegions, IFormatterListener listener, IClock clock)
        {
            this.cfaRegions = cfaRegions;
            this.listener = listener;
            this.clock = clock;
            cfaRegions.AddListener(this);
        }

        public void OnSelectedRegionChanged()
        {
            listener.OnFormattingChanged();
        }

        void IFormClosedListener.FormClosed()
        {
            cfaRegions.RemoveListener(this);
        }

        void IIncidentGridViewCellFormatter.Format(DataGridViewCellFormattingEventArgs e, DataGridViewRow viewRow)
        {
            short regionNumber = (short) viewRow.Cells[1].Value;

            bool isRegion = cfaRegions.IsSelectedRegion(regionNumber);

            string status = (string) viewRow.Cells[6].Value;
            string incidentType = (string) viewRow.Cells[5].Value;
            string size = (string) viewRow.Cells[7].Value;

            if (status == "SAFE")
            {
                //e.CellStyle.BackColor = Color.LightGreen;
            }
            else if (isRegion)
            {
                if (incidentType != "INCIDENT" && incidentType != "OTHER" && incidentType != "RESCUE")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

                    Color baseColor = Color.IndianRed;
                    Color endColor = Color.White;

                    int intensity = 0; // 0 is max

                    if (status == "CONTROLLED" || status == "UNDER CONTROL")
                    {
                        intensity += 2;
                    }
                    else if (status == "CONTAINED")
                    {
                        intensity += 1;
                    }

                    if (size == "SMALL")
                    {
                        intensity += 1;
                    }

                    e.CellStyle.BackColor = Color.FromArgb(
                        GetIntensity(baseColor.R, endColor.R, intensity),
                        GetIntensity(baseColor.G, endColor.G, intensity),
                        GetIntensity(baseColor.B, endColor.B, intensity));
                }

                if (e.ColumnIndex == 0) // Update time
                {
                    DateTime time = (DateTime) e.Value;
                    TimeSpan expiredTime = clock.Now - time;

                    // TODO: Scaled color class
                    Color baseColor = Color.IndianRed;
                    Color endColor = Color.Gray;

                    e.CellStyle.BackColor = Color.FromArgb(
                        GetIntensity(baseColor.R, endColor.R, expiredTime.TotalMinutes + 4),
                        GetIntensity(baseColor.G, endColor.G, expiredTime.TotalMinutes + 4),
                        GetIntensity(baseColor.B, endColor.B, expiredTime.TotalMinutes + 4));
                }
            }

            if (!isRegion)
            {
                e.CellStyle.ForeColor = Color.SlateGray;
            }
        }

        private static byte GetIntensity(byte zeroValue, byte maxValue, double value)
        {
            return (byte) (maxValue + (zeroValue - maxValue)*(4/(4 + value)));
        }
    }
}