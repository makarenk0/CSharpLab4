using System;
using CSharpLab4.View;
using UserAddingView = CSharpLab4.View.UserAddingView;
using UsersTableView = CSharpLab4.View.UsersTableView;
using UserEditingView = CSharpLab4.View.UserEditingView;

namespace CSharpLab4.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.UserAdding:
                    ViewsDictionary.Add(viewType, new UserAddingView());
                    break;
                case ViewType.UsersTable:
                    ViewsDictionary.Add(viewType, new UsersTableView());
                    break;
                case ViewType.UserEditing:
                    ViewsDictionary.Add(viewType, new UserEditingView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }

        }
    }
}
