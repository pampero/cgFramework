﻿#region license
// Copyright (c) 2007-2009 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System.Collections.Generic;
using System.Text;

namespace SolrNet {
    /// <summary>
    /// Manages HTTP connection with Solr
    /// </summary>
	public interface ISolrConnection {
        /// <summary>
        /// Solr url (e.g. http://localhost:8983/solr)
        /// </summary>
		string ServerURL { get; set; }

        /// <summary>
        /// Solr's response format. 2.2 by default. Do not modify this unless you really know what you're doing.
        /// </summary>
		string Version { get; set; }

        /// <summary>
        /// POSTs to Solr
        /// </summary>
        /// <param name="relativeUrl">Path to post to</param>
        /// <param name="s">POST content</param>
        /// <returns></returns>
		string Post(string relativeUrl, string s);

        /// <summary>
        /// GETs from Solr
        /// </summary>
        /// <param name="relativeUrl">Path to get from</param>
        /// <param name="parameters">Query string parameters</param>
        /// <returns></returns>
		string Get(string relativeUrl, IEnumerable<KeyValuePair<string, string>> parameters);
	}
}