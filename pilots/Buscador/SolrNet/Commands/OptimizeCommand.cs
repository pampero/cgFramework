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
using System.Xml;

namespace SolrNet.Commands {
    /// <summary>
    /// Optimizes Solr's index
    /// See the <see cref="http://wiki.apache.org/jakarta-lucene/LuceneFAQ">Lucene FAQ</see> for more information.
    /// </summary>
	public class OptimizeCommand : ISolrCommand {

		/// <summary>
		/// Block until index changes are flushed to disk
		/// Default is true
		/// </summary>
		public bool? WaitFlush { get; set; }

		/// <summary>
		/// Block until a new searcher is opened and registered as the main query searcher, making the changes visible. 
		/// Default is true
		/// </summary>
		public bool? WaitSearcher { get; set; }

        /// <summary>
        /// Executes this command
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
		public string Execute(ISolrConnection connection) {
			var xml = new XmlDocument();
			var node = xml.CreateElement("optimize");
			foreach (var p in new[] {new KeyValuePair<bool?, string>(WaitSearcher, "waitSearcher"), new KeyValuePair<bool?, string>(WaitFlush, "waitFlush")}) {
				if (p.Key.HasValue) {
					var att = xml.CreateAttribute(p.Value);
					att.InnerText = p.Key.Value.ToString().ToLower();
					node.Attributes.Append(att);
				}
			}
			return connection.Post("/update", node.OuterXml);
		}
	}
}