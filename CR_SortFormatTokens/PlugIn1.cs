using System;
using System.Linq;
using DevExpress.CodeRush.Core;
using System.Collections.Generic;
using DevExpress.CodeRush.PlugInCore;
using DevExpress.CodeRush.StructuralParser;

namespace CR_SortFormatTokens
{
    public partial class PlugIn1 : StandardPlugIn
    {
        // DXCore-generated code...
        #region InitializePlugIn
        public override void InitializePlugIn()
        {
            base.InitializePlugIn();
            registerSortFormatTokens();
        }
        #endregion
        #region FinalizePlugIn
        public override void FinalizePlugIn()
        {
            base.FinalizePlugIn();
        }
        #endregion

        private List<Token> _tokens;
        private PrimitiveExpression _PrimitiveString;
        public void registerSortFormatTokens()
        {
            DevExpress.CodeRush.Core.CodeProvider SortFormatTokens = new DevExpress.CodeRush.Core.CodeProvider(components);
            ((System.ComponentModel.ISupportInitialize)(SortFormatTokens)).BeginInit();
            SortFormatTokens.ProviderName = "SortFormatTokens"; // Should be Unique
            SortFormatTokens.DisplayName = "Sort Format Tokens";
            SortFormatTokens.CheckAvailability += SortFormatTokens_CheckAvailability;
            SortFormatTokens.Apply += SortFormatTokens_Execute;
            ((System.ComponentModel.ISupportInitialize)(SortFormatTokens)).EndInit();
        }
        private void SortFormatTokens_CheckAvailability(Object sender, CheckContentAvailabilityEventArgs ea)
        {
            _PrimitiveString = (CodeRush.Source.Active as PrimitiveExpression);
            if (_PrimitiveString == null)
                return;
            if (_PrimitiveString.PrimitiveType != PrimitiveType.String)
                return;
            LanguageElement Parent = _PrimitiveString.Parent;
            if (Parent == null)
                return;
            MethodCallExpression MCE = (Parent as MethodCallExpression);
            if (MCE == null)
                return;
            if (MCE.Name != "Format")
                return;
            _tokens = new TokenGatherer().GetTokens(_PrimitiveString.Name);
            if (!SequenceRenumberer.RequiresRenumbering(from item in _tokens select item.Index))
                return;
            ea.Available = true;
        }
        private void SortFormatTokens_Execute(Object sender, ApplyContentEventArgs ea)
        {

            MethodCallExpression TheStringFormat = _PrimitiveString.Parent as MethodCallExpression;
            string TheString = _PrimitiveString.Name;
            List<Expression> TheArguments = TheStringFormat.Arguments.ToList<Expression>().Skip(1).ToList<Expression>();
            SourceRange TheStringFormatRange = TheStringFormat.Range;

            //Get List of Tokens
            var Tokens = new TokenGatherer().GetTokens(TheString);

            // Determine "Sort" map.
            List<MapItem> Map = MapGenerator.GenerateMap(from item in Tokens select item.Index);

            // Affect string using map
            TheString = new StringTokenRenumberer().Renumber(TheString, Tokens, Map);

            // Affect params using map?
            TheArguments = new ListReorderer().Reorder(TheArguments, Tokens, Map);

            // Write TheString and TheList back to the code.
            TheStringFormat.Arguments.Clear();
            TheStringFormat.Arguments.Add(new PrimitiveExpression(TheString));
            TheStringFormat.Arguments.AddRange(TheArguments);
            string TheNewCode = CodeRush.CodeMod.GenerateCode(TheStringFormat, true);
            ea.TextDocument.SetText(TheStringFormatRange, TheNewCode);
        }
    }
}