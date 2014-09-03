using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CR_SortFormatTokens;
namespace CR_SortFormatTokens_Tests
{
    [TestFixture]
    public class RenumberRequired_Tests
    {
        #region RenumberRequired
        private static bool RenumberRequired(List<int> Numbers)
        {
            return CR_SortFormatTokens.SequenceRenumberer.RequiresRenumbering(Numbers);
        }
        #endregion

        [Test]
        public void SimpleSequence_Test()
        {
            Assert.AreEqual(false, RenumberRequired(Sequences.Sequence012345()));
        }
        [Test]
        public void ReverseSequence_Test()
        {
            Assert.AreEqual(true, RenumberRequired(Sequences.Sequence543210()));
        }
        [Test]
        public void MixedSequence_Test()
        {
            Assert.AreEqual(true, RenumberRequired(Sequences.Sequence021()));
        }
        [Test]
        public void OneOutOfPlaceSequence_Test()
        {
            Assert.AreEqual(true, RenumberRequired(Sequences.Sequence012354()));
        }
        [Test]
        public void CorrectWithDupeSimple1_Test()
        {
            Assert.AreEqual(false, RenumberRequired(Sequences.Sequence00()));
        }
        [Test]
        public void CorrectWithDupeSimple2_Test()
        {
            Assert.AreEqual(false, RenumberRequired(Sequences.Sequence011()));
        }
        [Test]
        public void CorrectWithDupeSimple3_Test()
        {
            Assert.AreEqual(false, RenumberRequired(Sequences.Sequence010()));
        }
        [Test]
        public void CorrectWithDupeSimple4_Test()
        {
            Assert.AreEqual(false, RenumberRequired(Sequences.Sequence0010()));
        }
    }
}