
using CSharpLab4.Tools.Navigation;
using CSharpLab4.ViewModel.Registration;
using System.Windows.Controls;


namespace CSharpLab4.View
{
    /// <summary>
    /// Логика взаимодействия для UserEditingView.xaml
    /// </summary>
    public partial class UserEditingView : UserControl, INavigatable
    {
        public UserEditingView()
        {
            DataContext = new UserEditingViewModel();
            InitializeComponent();
        }
    }
}
