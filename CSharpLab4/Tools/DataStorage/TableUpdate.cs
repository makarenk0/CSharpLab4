using CSharpLab4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
