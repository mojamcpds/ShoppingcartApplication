using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppingcart.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NumberOfResultsPerPage { get; }
        string EmailAddress { get; }
        string Credential { get; }
    }
}
