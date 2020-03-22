using CSharpLab4.Tools.Navigation;
using CSharpLab4.ViewModel;
using System.Windows.Controls;

namespace CSharpLab4.View
{
    /// <summary>
    /// Логика взаимодействия для UserAddingView.xaml
    /// </summary>
    public partial class UserAddingView : UserControl, INavigatable
    {
        public UserAddingView()
        {
            DataContext = new UserAddingViewModel();
            InitializeComponent();
        }
    }
}
