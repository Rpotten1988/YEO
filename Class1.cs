using System.Collections.Generic;
using Woodwork4Inventor.NamingSchemeApi;
using NamingSchemeApi;

namespace DemoAddIn
{
    public class DemoAddIn : NamingSchemeAddIn
    {
        public void Init(NamingSchemeAddInContext context)
        {
            AddFileNamePrefix(context.NamingSchemes);
        }

        private static void AddFileNamePrefix(IEnumerable<ItemNamingScheme> namingSchemes)
        {
            foreach (var scheme in namingSchemes)
            {
                if (scheme is DocumentNamingScheme documentNamingScheme)
                {
                    var fileProperties = documentNamingScheme.FileProperties;
                    var fileNameProperty = fileProperties["FileName"];
                    fileNameProperty.NewValue = "Copy_" + fileNameProperty.Value;
                }

                AddFileNamePrefix(scheme.Children);
            }
        }

        public string DisplayName => "Copy_ prefix add";
        public string Description => "Add-In to add Copy_ prefix for file names";
    }
}
