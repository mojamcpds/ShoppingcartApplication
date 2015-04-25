using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppingcart.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSettings;
        }
    }
}
