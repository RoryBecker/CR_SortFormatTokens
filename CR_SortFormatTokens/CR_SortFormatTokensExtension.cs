using System.ComponentModel.Composition;
using DevExpress.CodeRush.Common;

namespace CR_SortFormatTokens
{
    [Export(typeof(IVsixPluginExtension))]
    public class CR_SortFormatTokensExtension : IVsixPluginExtension { }
}