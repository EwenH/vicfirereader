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
using NMock2;
using NUnit.Extensions;
using NUnit.Framework;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.Tests.Incidents
{
    [TestFixture]
    public class IncidentsCollectionTests : MockingTestFixture
    {
        private IIncident incident1;
        private IIncident incident2;
        private IIncidentFactory incidentFactory;
        private IncidentsCollection incidents;
        private IIncidentsListener listener;

        protected override void SetUp()
        {
            listener = NewMock<IIncidentsListener>();
            incidentFactory = NewMock<IIncidentFactory>();

            incidents = new IncidentsCollection(listener, incidentFactory);

            incident1 = NewMock<IIncident>();
            incident2 = NewMock<IIncident>();
        }

        [Test]
        public void OnIncidentRead_NotifiesIncidentAdded_WhenNewIncidentID()
        {
            AddTwoIncidents();
        }

        [Test]
        public void OnIncidentRead_UpdatesIncident_WhenIncidentIDAlreadyAddedAndIncidentHasChanged()
        {
            AddTwoIncidents();

            DateTime time = new DateTime(2008, 3, 1);
            Expect.Once.On(incident1).Method("Update").With(13, "location", time, "name2", "type",
                                                            "status", "size", 33);
            incidents.OnIncidentRead("ID 1", 13, "location", time, "name2", "type", "status", "size",
                                     33);
        }

        [Test]
        public void OnIncidentRead_UpdatesIncident_WhenIncidentIsUnchanged()
        {
            AddTwoIncidents();

            Expect.Once.On(incident2).Method("Update").With(13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
            incidents.OnIncidentRead("ID 2", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);

            Expect.Once.On(incident1).Method("Update").With(13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
            incidents.OnIncidentRead("ID 1", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
        }

        private void AddTwoIncidents()
        {
            Expect.Once.On(incidentFactory).Method("Create").WithAnyArguments().Will(Return.Value(incident1));
            Expect.Once.On(listener).Method("OnIncidentAdded").WithAnyArguments();
            incidents.OnIncidentRead("ID 1", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);

            Stub.On(incident1).Method("CompareTo").WithAnyArguments().Will(Return.Value(-1));
            Stub.On(incident2).Method("CompareTo").WithAnyArguments().Will(Return.Value(-1));
            Expect.Once.On(incidentFactory).Method("Create").WithAnyArguments().Will(Return.Value(incident2));
            Expect.Once.On(listener).Method("OnIncidentAdded").WithAnyArguments();
            incidents.OnIncidentRead("ID 2", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
        }
    }
}