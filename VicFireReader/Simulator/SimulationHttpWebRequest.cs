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

using NoeticTools.DotNetWrappers;


namespace VicFireReader.Simulator
{
    public class SimulationHttpWebRequest : IHttpWebRequest
    {
        private readonly ISimulatedWebResponse[] responseHandlers;
        private readonly string url;
        private int timeout;
        private string userAgent;

        public SimulationHttpWebRequest(string url)
        {
            this.url = url;
            responseHandlers = new ISimulatedWebResponse[]
                                   {
                                       new IncidentsRSSSimulatedWebResponse(),
                                       new FireBanRSSSimulatedWebResponse()
                                   };
        }

        public IWebResponse GetResponse()
        {
            IWebResponse response = null;

            foreach (ISimulatedWebResponse handler in responseHandlers)
            {
                if (handler.CanHandle(url))
                {
                    response = handler;
                    break;
                }
            }

            return response;
        }

        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        public string UserAgent
        {
            get { return userAgent; }
            set { userAgent = value; }
        }
    }
}