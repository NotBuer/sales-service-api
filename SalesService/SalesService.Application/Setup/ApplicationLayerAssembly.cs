using System.Reflection;

namespace SalesService.Application.Setup;

public static class ApplicationLayerAssembly
{
    public static System.Reflection.Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
}