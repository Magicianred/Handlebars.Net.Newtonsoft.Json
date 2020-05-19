using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Handlebars.Net.Newtonsoft.Json
{
    public static class Helpers
    {
        /// <summary>
        /// Provides data grouping.
        /// </summary>
        /// <example>
        /// <root>
        ///     {{#group . \"key\"}}
        ///     <group>
        ///         {{#each .}}
        ///             <item>{{key}}:{{id}}</item>
        ///         {{/each}}
        ///     </group>
        ///     {{/group}}
        /// </root>
        /// </example>
        public static void RegisterGroup()
        {
            HandlebarsDotNet.Handlebars.RegisterHelper("group", (writer, options, context, parameters) =>
            {
                if (parameters == null || parameters.Length != 2 || parameters[1] == null)
                {
                    throw new InvalidOperationException("Template helper 'group' requires 2 valid parameters, data and key to group by.");
                }

                JArray array = context as JArray;

                if (array == null)
                {
                    throw new InvalidOperationException("Template helper 'group' requires a valid JArray.");
                }

                string groupByKey = parameters[1].ToString();

                foreach (var group in array.Children().GroupBy(token => token[groupByKey]))
                {
                    options.Template(writer, group);
                }
            });
        }
    }
}
