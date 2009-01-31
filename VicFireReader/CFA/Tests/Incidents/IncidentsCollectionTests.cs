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
using NoeticTools.Utilities;
using NUnit.Extensions;
using NUnit.Framework;
using VicFireReader.CFA.Incidents;


namespace VicFireReader.CFA.Tests.Incidents
{
    [TestFixture]
    public class IncidentsCollectionTests : MockingTestFixture
    {
        private IClock clock;
        private IncidentsCollection incidents;
        private IIncidentsListener listener;

        protected override void SetUp()
        {
            clock = NewMock<IClock>();
            listener = NewMock<IIncidentsListener>();

            incidents = new IncidentsCollection(clock, listener);
        }

        [Test]
        public void OnIncidentRead_NotifiesIncidentAdded_WhenNewIncidentID()
        {
            AddTwoIncidents();
        }

        [Test]
        public void OnIncidentRead_NotifiesIncidentChanged_WhenIncidentIDAlreadyAddedAndIncidentHasChanged()
        {
            AddTwoIncidents();

            Stub.On(clock).GetProperty("Now").Will(Return.Value(new DateTime(2008, 3, 1, 10, 30, 17)));
            Expect.Once.On(listener).Method("OnIncidentChanged").WithAnyArguments();

            incidents.OnIncidentRead("ID 1", 13, "location", new DateTime(2008, 3, 1), "name2", "type", "status", "size",
                                     33);
        }

        [Test]
        public void OnIncidentRead_DoesNotNotifyListener_WhenIncidentIsUnchanged()
        {
            AddTwoIncidents();

            incidents.OnIncidentRead("ID 2", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);

            incidents.OnIncidentRead("ID 1", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
        }

        private void AddTwoIncidents()
        {
            Expect.Once.On(listener).Method("OnIncidentAdded").WithAnyArguments();
            incidents.OnIncidentRead("ID 1", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);

            Expect.Once.On(listener).Method("OnIncidentAdded").WithAnyArguments();
            incidents.OnIncidentRead("ID 2", 13, "location", new DateTime(2008, 3, 1), "name", "type", "status", "size",
                                     33);
        }
    }
}