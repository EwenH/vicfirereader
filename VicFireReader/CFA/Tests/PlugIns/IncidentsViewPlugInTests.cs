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

using VicFireReader.CFA.Incidents.View;
using NMock2;
using NoeticTools.PlugIns;
using NUnit.Extensions;
using NUnit.Framework;


namespace VicFireReader.CFA.Tests.PlugIns
{
	[TestFixture]
	public class IncidentsViewPluginTests : MockingTestFixture
	{
		private IncidentsViewPlugIn plugIn;
		private IPluginHostServices hostServices;
		private IIncidentsViewFactory factory;

		protected override void SetUp()
		{
			hostServices = NewMock<IPluginHostServices>();
			factory = NewMock<IIncidentsViewFactory>();

			plugIn = new IncidentsViewPlugIn(factory);
		}

		[Test]
		public void Accept_RegistersOnOpenHandler()
		{
			Expect.Once.On(hostServices).Method("AddOnOpenListener").With(plugIn);

			((IPlugin)plugIn).Accept(hostServices);
		}
	}
}
