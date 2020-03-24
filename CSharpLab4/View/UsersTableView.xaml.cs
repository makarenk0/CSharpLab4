using CSharpLab4.Tools.Navigation;
using CSharpLab4.ViewModel.Registration;
using System.Windows.Controls;


namespace CSharpLab4.View
{
    /// <summary>
    /// Логика взаимодействия для UserTableView.xaml
    /// </summary>
    public partial class UsersTableView : UserControl, INavigatable
    {
        public UsersTableView()
        {
            DataContext = new UsersTableViewModel();
            InitializeComponent();
        }
    }
}
