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
        private short appliances;
        private readonly IClock clock;
        private readonly string incidentID;
        private string location;
        private string name;
        private readonly int region;
        private string size;
        private string status;
        private readonly DateTime time;
        private string type;
        private DateTime lastUpdatedTime;

        public Incident(IClock clock, string incidentID, int region, string location, DateTime time, string name,
                        string type, string status, string size, short appliances)
        {
            this.clock = clock;
            this.incidentID = incidentID;
            this.region = region;
            this.location = location;
            this.time = time;
            this.name = name;
            this.type = type;
            this.status = status;
            this.size = size;
            this.appliances = appliances;
        }

        public IncidentUpdateResult Update(IIncident incident)
        {
            return Update((Incident) incident);
        }

        private IncidentUpdateResult Update(Incident incident)
        {
            if (incidentID != incident.incidentID)
            {
                throw new InvalidOperationException(
                    "Attempted to update an incident from an incident with a different incident ID.");
            }

            if (region != incident.region)
            {
                throw new InvalidOperationException(
                    "Attempted to update an incident from an incident from a different region. Possible CFA operator error.");
            }

            IncidentUpdateResult result;

            if (incident.name != name ||
                incident.type != type ||
                incident.status != status ||
                incident.size != size ||
                incident.appliances != appliances ||
                incident.location != location)
            {
                lastUpdatedTime = incident.lastUpdatedTime = clock.Now;

                name = incident.name;
                type = incident.type;
                status = incident.status;
                size = incident.size;
                appliances = incident.appliances;
                location = incident.location;

                result = IncidentUpdateResult.Changed;
            }
            else
            {
                result = IncidentUpdateResult.NoChanges;
            }

            return result;
        }
    }
}