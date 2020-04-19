using System.Collections.Generic;

namespace EntityFrameworkCore.Scaffolding.Handlebars
{
    /// <summary>
    /// Provides files to the template service.
    /// </summary>
    public interface ITemplateConfigurationService
    {
        /// <summary>
        /// Sets the options.
        /// </summary>
        /// <param name="options">Options passed down from the constructor.</param>
        HandlebarsScaffoldingOptions SetOptions(HandlebarsScaffoldingOptions options);

        /// <summary>
        /// Gets all variables from a variable file.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> SetVariables(IDictionary<string, object> templateData);
    }
}