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
using System.Globalization;
using System.Xml;
using SolrNet.Utils;

namespace SolrNet.Impl.FieldParsers {
    /// <summary>
    /// Parses datetime fields
    /// </summary>
    public class DateTimeFieldParser : ISolrFieldParser {
        public bool CanHandleSolrType(string solrType) {
            return solrType == "date";
        }

        public bool CanHandleType(Type t) {
            return t == typeof (DateTime);
        }

        public object Parse(XmlNode field, Type t) {
            return ParseDate(field.InnerText);
        }

        public DateTime ParseDate(string s) {
            var p = s.Split('-');
            s = p[0].PadLeft(4, '0') + '-' + string.Join("-", Func.ToArray(Func.Tail(p)));
            return DateTime.ParseExact(s, "yyyy-MM-dd'T'HH:mm:ss.FFF'Z'", CultureInfo.InvariantCulture);
        }
    }
}