﻿using Serenity.Localization;
using System.Reflection;

namespace Bookapp.AppServices;
public class TypeSource : DefaultTypeSource
{
    public TypeSource()
        : base(GetAssemblyList())
    {
    }

    private static Assembly[] GetAssemblyList()
    {
        return
        [
            typeof(LocalTextRegistry).Assembly,
            typeof(ISqlConnections).Assembly,
            typeof(IRow).Assembly,
            typeof(SaveRequestHandler<>).Assembly,
            typeof(IDynamicScriptManager).Assembly,
            typeof(EnvironmentSettings).Assembly,
            typeof(Serenity.Demo.Northwind.CustomerPage).Assembly,
            typeof(Serenity.Demo.BasicSamples.BasicSamplesPage).Assembly,
            typeof(Startup).Assembly
        ];
    }
}