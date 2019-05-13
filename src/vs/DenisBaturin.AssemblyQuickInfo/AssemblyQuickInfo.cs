using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace DenisBaturin.AssemblyQuickInfo
{
    /// <summary>
    /// The object for quick access to some members of assembly
    /// </summary>
    public class AssemblyQuickInfo
    {
        private readonly Assembly _assembly;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="assembly">Assebmly</param>
        public AssemblyQuickInfo(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>Gets or sets the simple name of the assembly. This is usually, but not necessarily, the file name of the manifest file of the assembly, minus its extension.</summary>
        /// <returns>The simple name of the assembly.</returns>
        public string Name => _assembly.GetName().Name;

        /// <summary>Gets the full name of the assembly, also known as the display name.</summary>
        /// <returns>A string that is the full name of the assembly, also known as the display name.</returns>
        public string FullName => _assembly.GetName().FullName;

        /// <summary>Gets the location of the assembly as specified originally, for example, in an <see cref="T:System.Reflection.AssemblyName"></see> object.</summary>
        /// <returns>The location of the assembly as specified originally.</returns>
        public string CodeBase => _assembly.CodeBase;

        /// <summary>
        /// Converts the value of the current <see cref="T:System.Version"></see> object to its equivalent <see cref="T:System.String"></see> representation.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.String"></see> representation of the values of the major, minor, build, and revision components of the current <see cref="T:System.Version"></see> object, as depicted in the following format.
        /// Each component is separated by a period character ('.').
        /// Square brackets ('[' and ']') indicate a component that will not appear in the return value if the component is not defined:   major.minor[.build[.revision]]
        /// For example, if you create a <see cref="T:System.Version"></see> object using the constructor Version(1,1), the returned string is "1.1".
        /// If you create a <see cref="T:System.Version"></see> object using the constructor Version(1,3,4,2), the returned string is "1.3.4.2".
        /// </returns>
        public string Version() => _assembly.GetName().Version.ToString();

        /// <summary>
        /// Returns string representation of the current <see cref="T:System.Version"></see> object. A specified count indicates the number of components to return.
        /// </summary>
        /// <param name="fieldCount">The number of components to return. The fieldCount ranges from 0 to 4.</param>
        /// <returns>The <see cref="T:System.String"></see> representation of the values of the major, minor, build, and revision components of the current <see cref="T:System.Version"></see> object, each separated by a period character ('.').
        /// The <paramref name="fieldCount">fieldCount</paramref> parameter determines how many components are returned.
        ///
        /// fieldCount / Return Value
        /// 
        /// 0 / An empty string ("").
        /// 1 / major
        /// 2 / major.minor
        /// 3 / major.minor.build
        /// 4 / major.minor.build.revision
        /// 
        /// For example, if you create <see cref="T:System.Version"></see> object using the constructor Version(1,3,5), ToString(2) returns "1.3" and ToString(4) throws an exception.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="fieldCount">fieldCount</paramref> is less than 0, or more than 4.   -or-  <paramref name="fieldCount">fieldCount</paramref> is more than the number of components defined in the current <see cref="T:System.Version"></see> object.</exception>
        public string Version(int fieldCount) => _assembly.GetName().Version.ToString(fieldCount);

        /// <summary>Gets the full path or UNC location of the loaded file that contains the manifest.</summary>
        /// <returns>
        /// The location of the loaded file that contains the manifest. If the loaded file was shadow-copied, the location is that of the file after being shadow-copied. If the assembly is loaded from a byte array, such as when using the <see cref="M:System.Reflection.Assembly.Load(System.Byte[])"></see> method overload, the value returned is an empty string ("").
        /// </returns>
        public string Location => _assembly.Location;

        /// <summary>Returns the directory information for the assembly.</summary>
        /// <returns>The directory information for the assembly.</returns>
        public string DirectoryName => System.IO.Path.GetDirectoryName(_assembly.Location);

        /// <summary>Gets copyright information.</summary>
        /// <returns>A string containing the copyright information.</returns>
        public string Copyright => _assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;

        /// <summary>Gets company name information.</summary>
        /// <returns>A string containing the company name.</returns>
        public string Company => _assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company;

        /// <summary>Gets assembly configuration information.</summary>
        /// <returns>A string containing the assembly configuration information.</returns>
        public string Configuration => _assembly.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;

        /// <summary>Gets assembly description information.</summary>
        /// <returns>A string containing the assembly description.</returns>
        public string Description => _assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

        /// <summary>Gets product name information.</summary>
        /// <returns>A string containing the product name.</returns>
        public string Product => _assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        /// <summary>Gets assembly title information.</summary>
        /// <returns>The assembly title.</returns>
        public string Title => _assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

        /// <summary>Gets trademark information.</summary>
        /// <returns>A string containing trademark information.</returns>
        public string Trademark => _assembly.GetCustomAttribute<AssemblyTrademarkAttribute>()?.Trademark;

        /// <summary>Gets the Win32 file version resource name.</summary>
        /// <returns>A string containing the file version resource name.</returns>
        public string FileVersion => _assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;

        /// <summary>Gets the <see cref="T:System.Guid"></see> of the class.</summary>
        /// <returns>The <see cref="T:System.Guid"></see> of the class.</returns>
        public string Guid => _assembly.GetCustomAttribute<GuidAttribute>()?.Value;

        /// <summary>Gets the culture name.</summary>
        /// <returns>The name of the default culture for the main assembly.</returns>
        public string CultureName => _assembly.GetCustomAttribute<NeutralResourcesLanguageAttribute>()?.CultureName;

        /// <summary>Gets a value that indicates whether the COM type is visible.</summary>
        /// <returns>true if the type is visible; otherwise, false. The default value is true.</returns>
        public string ComVisible => _assembly.GetCustomAttribute<ComVisibleAttribute>()?.Value.ToString();
        
    }
}