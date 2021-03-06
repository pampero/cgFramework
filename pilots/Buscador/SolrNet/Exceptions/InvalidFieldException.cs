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

using System;
using System.Runtime.Serialization;

namespace SolrNet.Exceptions {
    /// <summary>
    /// Solr did not understand one the specified fields
    /// </summary>
    [Serializable]
	public class InvalidFieldException : SolrNetException {
		public InvalidFieldException(Exception innerException) : base(innerException) {}
		public InvalidFieldException(string message) : base(message) {}
		public InvalidFieldException(string message, Exception innerException) : base(message, innerException) {}
		public InvalidFieldException() {}
        protected InvalidFieldException(SerializationInfo info, StreamingContext context) : base(info, context) {}
	}
}