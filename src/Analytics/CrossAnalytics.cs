using System;
using System.Threading;
using Analytics.Abstractions;

namespace Analytics
{
    public class CrossAnalytics
    {
        private static Lazy<IGaService> Implementation = new Lazy<IGaService>(CreateAnalytics,
            LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///     Current settings to use
        /// </summary>
        public static IGaService Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static IGaService CreateAnalytics()
        {
            return null;
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return
                new NotImplementedException(
                    "This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }


        /// <summary>
        ///     Dispose of everything
        /// </summary>
        public static void Dispose()
        {
            if (Implementation != null && Implementation.IsValueCreated)
            {
                Implementation = new Lazy<IGaService>(CreateAnalytics, LazyThreadSafetyMode.PublicationOnly);
            }
        }
    }
}