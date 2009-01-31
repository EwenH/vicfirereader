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
using System.Collections;
using System.Collections.Generic;
using NoeticTools.Utilities;


namespace VicFireReader.CFA.Incidents
{
    public class IncidentsCollection : IIncidents
    {
        private readonly IClock clock;
        private readonly List<IIncident> incidents = new List<IIncident>();

        public IncidentsCollection(IClock clock)
        {
            this.clock = clock;
        }

        public void OnIncidentRead(string incidentID, int region, string location, DateTime time, string name, string type,
                                   string status, string size, short appliances)
        {
            IIncident readIncident = new Incident(clock, incidentID, region, location, time, name, type, status, size, appliances);

            int incidentIndex = incidents.IndexOf(readIncident);
            if (incidentIndex >= 0)
            {
                IIncident existingIncident = incidents[incidentIndex];
                existingIncident.Update(readIncident);
            }
            else
            {
                incidents.Add(readIncident);
            }
        }
    }
}