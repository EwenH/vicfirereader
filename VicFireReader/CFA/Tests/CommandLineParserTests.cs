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

using NUnit.Framework;
using NUnit.Extensions;


namespace VicFireReader.CFA.Tests
{
	[TestFixture]
	public class CommandLineParserTests : MockingTestFixture
	{
		private CommandLineParser parser;

		protected override void SetUp()
		{
			parser = new CommandLineParser();
		}

		[Test]
		public void Simulate_IsFalse_WithEmptyCommandLine()
		{
			parser.Parse(new string[] {"executable"});

			Assert.AreEqual(false, parser.Simulate);
		}

		[Test]
		public void Simulate_IsFalse_WithUnknownCommandLineArgument()
		{
			parser.Parse(new string[] { "executable", "/unknown" });

			Assert.AreEqual(false, parser.Simulate);
		}

		[Test]
		public void Simulate_IsTrue_WithSimulateCommandLineArgument()
		{
			parser.Parse(new string[] { "executable", "/Simulate" });

			Assert.AreEqual(true, parser.Simulate);
		}

		[Test]
		public void Simulate_IsTrue_WithLowerCaseSimulateCommandLineArgument()
		{
			parser.Parse(new string[] { "executable", "/simulate" });

			Assert.AreEqual(true, parser.Simulate);
		}
	}
}
