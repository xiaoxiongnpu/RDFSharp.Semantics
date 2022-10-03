﻿/*
   Copyright 2012-2022 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using RDFSharp.Model;
using System;

namespace RDFSharp.Semantics.Extensions.SKOS
{
    /// <summary>
    /// SKOSConceptSchemeHelper contains methods for analyzing relations describing SKOS concept schemes
    /// </summary>
    public static class SKOSConceptSchemeHelper
    {
        #region Methods
        /// <summary>
        /// Checks if the given concept can be topConcept of the given concept scheme without tampering SKOS integrity
        /// </summary>
        internal static bool CheckTopConceptCompatibility(this SKOSConceptScheme conceptScheme, RDFResource skosConcept)
        {
            throw new NotImplementedException(); //TODO: reason like a class to not have superclasses
        }
        #endregion
    }
}