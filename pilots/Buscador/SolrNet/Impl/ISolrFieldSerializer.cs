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
using System.Collections.Generic;


namespace SolrNet.Impl {
    /// <summary>
    /// Serializes a value to be consumed by the Solr update handler
    /// </summary>
    public interface ISolrFieldSerializer {
        /// <summary>
        /// True if this serializer can handle the type
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool CanHandleType(Type t);

        /// <summary>
        /// Serializes a value to be consumed by the Solr update handler
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <returns>List of <see cref="PropertyNode"/>s, each represents a XML node to be passed to the Solr update handler</returns>
        IEnumerable<PropertyNode> Serialize(object obj);
    }
}