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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDFSharp.Semantics
{
    /// <summary>
    /// OWLValidatorRuleset implements a subset of RDFS/OWL-DL/OWL2 validator rules
    /// </summary>
    internal static class OWLValidatorRuleset
    {
        #region Rule:Vocabulary_Disjointness
        /// <summary>
        /// OWL-DL validator rule checking for vocabulary disjointness of classes, properties and individuals
        /// </summary>
        internal static OWLValidatorReport Vocabulary_Disjointness(OWLOntology ontology)
        {
            OWLValidatorReport validatorRuleReport = new OWLValidatorReport();

            #region ClassModel
            foreach (RDFResource owlClass in ontology.Model.ClassModel)
            {
                if (ontology.Model.PropertyModel.Properties.ContainsKey(owlClass.PatternMemberID))
                {
                    validatorRuleReport.AddEvidence(new OWLValidatorEvidence(
                        OWLSemanticsEnums.OWLValidatorEvidenceCategory.Error,
                        nameof(Vocabulary_Disjointness),
                        $"Disjointess of class model and property model is violated because the name '{owlClass}' refers both to a class and a property",
                        "Remove or rename one of the two entities: at the moment the ontology is OWL Full!"
                    ));
                }
                if (ontology.Data.Individuals.ContainsKey(owlClass.PatternMemberID))
                {
                    validatorRuleReport.AddEvidence(new OWLValidatorEvidence(
                        OWLSemanticsEnums.OWLValidatorEvidenceCategory.Error,
                        nameof(Vocabulary_Disjointness),
                        $"Disjointess of class model and data is violated because the name '{owlClass}' refers both to a class and an individual",
                        "Remove or rename one of the two entities: at the moment the ontology is OWL Full!"
                    ));
                }
            }
            #endregion

            #region PropertyModel
            foreach (RDFResource owlProperty in ontology.Model.PropertyModel)
                if (ontology.Data.Individuals.ContainsKey(owlProperty.PatternMemberID))
                {
                    validatorRuleReport.AddEvidence(new OWLValidatorEvidence(
                        OWLSemanticsEnums.OWLValidatorEvidenceCategory.Error,
                        nameof(Vocabulary_Disjointness),
                        $"Disjointess of property model and data is violated because the name '{owlProperty}' refers both to a property and an individual",
                        "Remove or rename one of the two entities: at the moment the ontology is OWL Full!"
                    ));
                }
            #endregion

            return validatorRuleReport;
        }
        #endregion
    }
}