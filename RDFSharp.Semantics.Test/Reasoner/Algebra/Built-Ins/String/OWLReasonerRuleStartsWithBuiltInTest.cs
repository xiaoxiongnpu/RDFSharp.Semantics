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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using RDFSharp.Query;
using System.Data;

namespace RDFSharp.Semantics.Reasoner.Test
{
    [TestClass]
    public class OWLReasonerRuleStartsWithBuiltInTest
    {
        #region Tests
        [TestMethod]
        public void ShouldCreateStartsWithBuiltIn()
        {
            OWLReasonerRuleStartsWithBuiltIn builtin = new OWLReasonerRuleStartsWithBuiltIn(new RDFVariable("?L"), "val");

            Assert.IsNotNull(builtin);
            Assert.IsNotNull(builtin.BuiltInFilter);
            Assert.IsNotNull(builtin.Predicate);
            Assert.IsTrue(builtin.Predicate.Equals(new RDFResource("swrlb:startsWith")));
            Assert.IsNotNull(builtin.LeftArgument);
            Assert.IsTrue(builtin.LeftArgument.Equals(new RDFVariable("?L")));
            Assert.IsNotNull(builtin.RightArgument);
            Assert.IsTrue(builtin.RightArgument.Equals(new RDFPlainLiteral("val")));
            Assert.IsTrue(builtin.IsBuiltIn);
            Assert.IsTrue(string.Equals("swrlb:startsWith(?L,\"val\")", builtin.ToString()));
        }

        [TestMethod]
        public void ShouldThrowExceptionOnCreatingStartsWithBuiltInBecauseNullLeftArgument()
            => Assert.ThrowsException<OWLSemanticsException>(() => new OWLReasonerRuleStartsWithBuiltIn(null, "val"));

        [TestMethod]
        public void ShouldThrowExceptionOnCreatingStartsWithBuiltInBecauseNullRightArgument()
            => Assert.ThrowsException<OWLSemanticsException>(() => new OWLReasonerRuleStartsWithBuiltIn(new RDFVariable("?L"), null));
        
        [TestMethod]
        public void ShouldEvaluateStartsWithBuiltIn()
        {
            DataTable antecedentTable = new DataTable();
            antecedentTable.Columns.Add("?C");
            antecedentTable.Rows.Add("ex1:indiv");
            antecedentTable.Rows.Add("ex2:indiv2");
            antecedentTable.Rows.Add("ex2:indiV2");

            OWLReasonerRuleStartsWithBuiltIn builtin = new OWLReasonerRuleStartsWithBuiltIn(new RDFVariable("?C"), "ex1");
            DataTable result = builtin.Evaluate(antecedentTable, null);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Rows.Count == 1);
        }
        #endregion
    }
}