namespace CSharpLab4.Tools.Navigation
{
    internal enum ViewType
    {
        UserAdding,
        UsersTable,
        UserEditing
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
