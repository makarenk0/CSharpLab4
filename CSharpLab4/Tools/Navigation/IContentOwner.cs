using System.Windows.Controls;

namespace CSharpLab4.Tools.Navigation
{
    internal interface IContentOwner
    {
        INavigatable Content { get; set; }
    }
}
