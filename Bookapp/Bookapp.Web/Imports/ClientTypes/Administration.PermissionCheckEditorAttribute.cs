using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bookapp.Administration;

public partial class PermissionCheckEditorAttribute : CustomEditorAttribute
{
    public const string Key = "Bookapp.Administration.PermissionCheckEditor";

    public PermissionCheckEditorAttribute()
        : base(Key)
    {
    }

    public bool ShowRevoke
    {
        get { return GetOption<bool>("showRevoke"); }
        set { SetOption("showRevoke", value); }
    }
}