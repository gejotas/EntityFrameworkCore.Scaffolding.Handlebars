using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EntityFrameworkCore.Scaffolding.Handlebars.Helpers;
using EntityFrameworkCore.Scaffolding.Handlebars.Internal;
using Newtonsoft.Json;

namespace EntityFrameworkCore.Scaffolding.Handlebars
{
    /// <summary>
    /// Provides files to the template service from the file system.
    /// </summary>
    public class TemplateConfigurationService : ITemplateConfigurationService
    {
        /// <summary>
        /// Sets the options.
        /// </summary>
        /// <param name="options">Options passed down from the constructor.</param>
        public virtual HandlebarsScaffoldingOptions SetOptions(HandlebarsScaffoldingOptions options)
        {
            options.TemplateData = SetVariables(options.TemplateData);
            return options;
        }

        /// <summary>
        /// Gets all variables from a variable file.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> SetVariables(IDictionary<string, object> templateData)
        {
            // If templateData is null we know that variables have not been loaded.
            if (templateData != null)
                return (Dictionary<string, object>)templateData;

            var path = Path.Combine(GetWorkingDirectory(), $"{Constants.ConfigurationFiles.FilePrefix}.{Constants.ConfigurationFiles.VariablesFile}.{Constants.ConfigurationFiles.FileExtension}");
            var data = (Dictionary<string, object>)templateData ?? new Dictionary<string, object>();

            if (File.Exists(path))
            {
                var contents = File.ReadAllText(path);
                var variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(contents);

                foreach (var variable in variables)
                {
                    data.Add(variable.Key, variable.Value);
                }
            }
            return data;
        }

        /// <summary>
        /// Gets working directory.
        /// </summary>
        /// <returns>Path to working directory.</returns>
        protected virtual string GetWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
