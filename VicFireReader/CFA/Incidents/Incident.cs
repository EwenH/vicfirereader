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
using NoeticTools.Utilities;


namespace VicFireReader.CFA.Incidents
{
    public class Incident : IIncident
    {
        private readonly IIncidentChangeListener changeListener;
        private readonly IClock clock;
        private readonly string incidentID;
        private readonly int region;
        private int appliances;
        private DateTime cfaIncidentTime;
        private DateTime lastUpdatedTime;
        private string location;
        private string name;
        private string size;
        private string status;
        private string type;

        public Incident(IClock clock, IIncidentChangeListener changeListener, string incidentID, int region,
                        string location, DateTime cfaIncidentTime, string name, string type, string status, string size,
                        int appliances)
        {
            this.clock = clock;
            this.changeListener = changeListener;
            this.incidentID = incidentID;
            this.region = region;
            this.location = location;
            this.cfaIncidentTime = cfaIncidentTime;
            this.name = name;
            this.type = type;
            this.status = status;
            this.size = size;
            this.appliances = appliances;
        }

        public int CompareTo(object obj)
        {
            return Compare((Incident) obj);
        }

        public void Update(int currentRegion, string currentLocation, DateTime currentcfaIncidentTime,
                           string currentName, string currentType, string currentStatus, string currentSize,
                           int currentAppliances)
        {
            if (region != currentRegion)
            {
                throw new InvalidOperationException(
                    "Attempted to update an incident from an incident from a different region. Possible CFA error.");
            }

            if (currentName != name ||
                currentType != type ||
                currentStatus != status ||
                currentSize != size ||
                currentAppliances != appliances ||
                currentLocation != location ||
                currentcfaIncidentTime != cfaIncidentTime)
            {
                name = currentName;
                type = currentType;
                status = currentStatus;
                size = currentSize;
                appliances = currentAppliances;
                location = currentLocation;
                cfaIncidentTime = currentcfaIncidentTime;

                lastUpdatedTime = clock.Now;

                changeListener.OnIncidentChanged(this);
            }
        }

        private int Compare(Incident incident)
        {
            return incidentID.CompareTo(incident.incidentID);
        }

        public override int GetHashCode()
        {
            return incidentID.GetHashCode();
        }
    }
}