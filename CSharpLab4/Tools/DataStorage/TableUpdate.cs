using System;

namespace CSharpLab4.Tools.DataStorage
{
    internal static class TableUpdate
    {
        public delegate void UpdateTable();
        public static UpdateTable Update;

        public delegate void InitializeEditing();
        public static InitializeEditing InitEdit;
        public static Guid userToChange;

    }
}
