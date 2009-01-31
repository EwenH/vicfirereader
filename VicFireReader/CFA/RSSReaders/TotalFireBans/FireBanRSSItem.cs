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

using System.Text.RegularExpressions;
using System.Xml;


namespace VicFireReader.CFA.RSSReaders.TotalFireBans
{
    public class FireBanRSSItem
    {
        private readonly XmlNode xmlNode;

        public FireBanRSSItem(XmlNode xmlNode)
        {
            this.xmlNode = xmlNode;
        }

        public string GetHtmlDocumentText()
        {
            string rssItemTitle = xmlNode.SelectSingleNode("title").InnerText;
            string rssItemDescription = xmlNode.SelectSingleNode("description").InnerText;

            Regex regex = new Regex(@"<img.*>");
            Match match = regex.Match(rssItemDescription);
            if (match.Success)
            {
                rssItemDescription = regex.Match(rssItemDescription).Value;
            }

            string htmlStyleElement =
                @"
<style>

body {
 font-family: verdana, tahoma;
 font-size: 0.7em;
 line-height: 1.3em;
 padding: 0;
 margin: 0;
}


a, a:link, a:active, a:visited {
 text-decoration: none;
 color: #0088ff;
}

div.entry {
 padding: 0 20px 20px 25px;
 border-bottom: 1px solid #ddd;
}

div.content img {
}

div.active {
 background-color: #f1f5fa;;
}

.read .title a {
 color: #aaa;
}

.read .content {
 color: #555;
}

div.entry .read .title a {
 color: gray;
}

.header {
 padding-top: 20px;
 margin: 0 0 0.2em 0;
}

.title {
 font-size: 1.6em;
 font-family: arial, verdana, tahoma;
 font-weight: bold;
 letter-spacing: -1px;
 line-height: 1.1em;
}

div.details {
 color: gray;
 margin-bottom: 0.5em;
}
div.clear {
 clear:both;
 height: 1px;
 width: 1px;
 font-size: 1px;
 line-height: 1px;
}
span.modified, span.author, span.category {
}

.starred a {
 display:block;
 line-height: 0;
 font-size: 0;
 width: 12px; 
 height: 12px;
 background-repeat: no-repeat;
}

.unstarred a {
 display:block;
 line-height: 0;
 font-size: 0;
 width: 12px; 
 height: 12px;
 background-repeat: no-repeat;
}

.status a {
 display:block;
 line-height: 0;
 font-size: 0;
 width: 8px; 
 height: 8px;
 margin-top: -1.5em;
 background-repeat: no-repeat;
}

</style>
";

            string template =
                @"<html xmlns:feed='http://www.w3.org/2005/Atom'>

<head>
  <META http-equiv='Content-Type' content='text/html; charset=UTF-8'>
  <title>CFA - Total Fire Ban</title>
  <link rel='stylesheet' href='atom.css'>
  {1}
  <base href='http://cfaonline.cfa.vic.gov.au/mycfa/Show?pageId=publicTotalFireBans/'>
</head>

<body>
  <div class='header'>
    <span class='title'><a href='http://cfaonline.cfa.vic.gov.au/mycfa/Show?pageId=publicTotalFireBans'>{0}</a></span>
    <span class='status' style='float:right;'><a id='togglelink1055' href='fr:toggleread/1055' onclick='this.blur();'></a></span>
  </div>
  <div class='details'>
    <span id='star1055' class='unstarred' style='float:left;'><a id='togglestar1055' href='fr:togglestar/1055' onclick='this.blur();'></a></span>
    <span class='source'>CFA - Total Fire Ban  </span>
  </div>
  <div class='content'>{2}</div>
  <div class='clear'></div>
</body>

</html>"
                    .Replace('\'', '"');

            return string.Format(template, rssItemTitle, htmlStyleElement, rssItemDescription);
        }
    }
}