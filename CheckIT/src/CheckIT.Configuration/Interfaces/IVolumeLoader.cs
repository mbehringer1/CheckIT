using CheckIT.Core;
using System.Collections.Generic;

namespace CheckIT.Configuration.Interfaces
{
    public interface IVolumeLoader
    {
        /// <summary>
        /// Gets the localized syntax.
        /// </summary>
        /// <value>
        /// The localized syntax.
        /// </value>
        Syntax LocalizedSyntax { get; }
        
        /// <summary>
        /// Loads the specified locale dictionary.
        /// </summary>
        /// <param name="locale">The locale.</param>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, string>> Load(string locale);
    }
}
