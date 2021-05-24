using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace APIContagem
{
    public class Contador
    {
        private static readonly string _LOCAL;
        private static readonly string _KERNEL;
        private static readonly string _TARGET_FRAMEWORK;

        static Contador()
        {
            _LOCAL = Environment.MachineName;
            _KERNEL = Environment.OSVersion.VersionString;
            _TARGET_FRAMEWORK = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;
        }

        private int _valorAtual = 0;

        public int ValorAtual { get => _valorAtual; }
        public string Local { get => _LOCAL; }
        public string Kernel { get => _KERNEL; }
        public string TargetFramework { get => _TARGET_FRAMEWORK; }

        public void Incrementar()
        {
            _valorAtual++;
        }
    }
}