using CSharpLab4.Tools.DataStorage;
using System.Collections.Generic;

namespace CSharpLab4.Tools.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.Content = ViewsDictionary[viewType];

            switch (viewType)
            {
                case ViewType.UsersTable:
                    TableUpdate.Update();
                    break;
                case ViewType.UserEditing:
                    TableUpdate.InitEdit();
                    break;
                default:
                    break;
            }
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
