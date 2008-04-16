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

using System.IO;
using System.Text;
using NoeticTools.DotNetWrappers;


namespace VicFireReader.Simulator
{
	public class FireBanRSSSimulatedWebResponse : ISimulatedWebResponse
	{
		private readonly string sampleRSS =
@"<?xml version='1.0' encoding='UTF-8'?>
<rss xmlns:taxo='http://purl.org/rss/1.0/modules/taxonomy/' xmlns:rdf='http://www.w3.org/1999/02/22-rdf-syntax-ns#' xmlns:dc='http://purl.org/dc/elements/1.1/' version='2.0'>
  <channel>
    <title>Country Fire Authority - Victoria, Australia - Declaration of Total Fire Ban</title>
    <link>http://cfaonline.cfa.vic.gov.au/mycfa/Show?pageId=publicTotalFireBans</link>
    <description>Country Fire Authority - Victoria, Australia - Declaration of Total Fire Ban.</description>
    <item>
      <title>Today Tue, 1 Apr 2008 is not a Day of Total Fire Ban.</title>
      <link>http://cfaonline.cfa.vic.gov.au/mycfa/Show?pageId=publicTotalFireBans</link>
      <description>North Western: No Total Fire Ban - Restrictions may apply &lt;br&gt;North Eastern: No Total Fire Ban - Restrictions may apply &lt;br&gt;South Western: No Total Fire Ban - Restrictions may apply &lt;br&gt;Central: No Total Fire Ban - Restrictions may apply &lt;br&gt;Eastern: No Total Fire Ban - Restrictions may apply &lt;br&gt;&lt;br&gt;&lt;img src='images/tfb_maps/tfb_0.gif' width='406' height='294' border='0' alt='Total Fire Ban Districts'&gt;</description>
      <guid>http://cfaonline.cfa.vic.gov.au/mycfa/Show?pageId=publicTotalFireBans</guid>
    </item>
  </channel>
</rss>
".Replace('\'', '"');

		Stream IWebResponse.GetResponseStream()
		{
			return new MemoryStream(Encoding.ASCII.GetBytes(sampleRSS));
		}

		public bool CanHandle(string url)
		{
			return url == @"http://www.cfa.vic.gov.au/incidents/tfb_rss.xml";
		}
	}
}
