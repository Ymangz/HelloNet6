using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace HelloNet6;

public class DefaultModuleRegister : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(ThisAssembly)
            .Where(e => e.BaseType == typeof(ControllerBase)).AsSelf();
        base.Load(builder);
    }
}