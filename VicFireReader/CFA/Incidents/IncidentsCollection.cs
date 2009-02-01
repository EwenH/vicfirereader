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
using System.Collections.Generic;
using NoeticTools.Utilities;


namespace VicFireReader.CFA.Incidents
{
    public class IncidentsCollection : IIncidents
    {
        private readonly IIncidentsListener listener;
        private readonly IIncidentFactory incidentFactory;
        private readonly SortedList<string, IIncident> incidents = new SortedList<string, IIncident>();

        public IncidentsCollection(IIncidentsListener listener, IIncidentFactory incidentFactory)
        {
            this.listener = listener;
            this.incidentFactory = incidentFactory;
        }

        public void OnIncidentRead(string incidentID, int region, string location, DateTime time, string name,
                                   string type, string status, string size, short appliances)
        {
            if (incidents.ContainsKey(incidentID))
            {
                incidents[incidentID].Update(region, location, time, name,type, status, size, appliances);
            }
            else
            {
                IIncident newIncident = incidentFactory.Create(incidentID, region, location, time, name, type, status, size,
                                                      appliances);
                incidents.Add(incidentID, newIncident);
                listener.OnIncidentAdded(newIncident);
            }
        }
    }
}