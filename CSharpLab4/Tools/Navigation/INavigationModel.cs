namespace CSharpLab4.Tools.Navigation
{
    internal enum ViewType
    {
        UserAdding,
        UsersTable  
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
