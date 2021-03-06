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

namespace SolrNet {
    /// <summary>
    /// Queries a field for a range
    /// </summary>
    /// <typeparam name="RT"></typeparam>
	public class SolrQueryByRange<RT> : AbstractSolrQuery {
		private readonly string q;
		public SolrQueryByRange(string fieldName, RT from, RT to) : this(fieldName, from, to, true) {}

		public SolrQueryByRange(string fieldName, RT from, RT to, bool inclusive) {
			q = "$field:$ii$from TO $to$if"
				.Replace("$field", fieldName)
				.Replace("$ii", inclusive ? "[" : "{")
				.Replace("$if", inclusive ? "]" : "}")
				.Replace("$from", from.ToString())
				.Replace("$to", to.ToString());
		}

		/// <summary>
		/// query string
		/// </summary>
		public override string Query {
			get { return q; }
		}
	}
}