# AssemblyQuickInfo
AssemblyQuickInfo is the library in **C#** for quick access to some members of .NET-assembly.  
Author: **Denis Baturin**  

    The library was created with the purpose of education and demonstration!  
Questions and comments can be written here: [vk.com/denisbaturincom](http://vk.com/denisbaturincom)  

---

## Standard usage:

```CSharp
var executingAssembly = Assembly.GetExecutingAssembly();

var name = executingAssembly.GetName().Name;
var version = executingAssembly.GetName().Version.ToString();
var copyright = executingAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;
var directoryName = System.IO.Path.GetDirectoryName(executingAssembly.Location);
```

## With AssemblyQuickInfo:

```CSharp
var executingAssembly = Assembly.GetExecutingAssembly();
var aqi = new AssemblyQuickInfo(executingAssembly);

var name = aqi.Name;
var version = aqi.Version();
var copyright = aqi.Copyright;
var directoryName = aqi.DirectoryName;
```

## The following properties are supported:
Property      | Description
--------------|----------
Name          | The simple name of the assembly.
FullName      | A string that is the full name of the assembly, also known as the display name.
CodeBase      | The location of the assembly as specified originally.
Version()     | The string representation of the current **`System.Version`** object.
Version(int fieldCount) | The string representation of the current **`System.Version`** object. <br> A specified count indicates the number of components to return.
Location      | The full path or UNC location of the loaded file that contains the manifest.
DirectoryName | The directory information for the assembly.
Copyright     | A string containing the copyright information. (`AssemblyCopyrightAttribute`)
Company       | A string containing the company name. (`AssemblyCompanyAttribute`)
Configuration | A string containing the assembly configuration information. (`AssemblyConfigurationAttribute`)
Description   | A string containing the assembly description. (`AssemblyDescriptionAttribute`)
Product       | A string containing the product name. (`AssemblyProductAttribute`)
Title         | The assembly title. (`AssemblyTitleAttribute`)
Trademark     | A string containing trademark information. (`AssemblyTrademarkAttribute`)
FileVersion   | A string containing the file version resource name. (`AssemblyFileVersionAttribute`)
Guid          | The **`System.Guid`** of the class. (`GuidAttribute`)
CultureName   | The name of the default culture for the main assembly. (`NeutralResourcesLanguageAttribute`)
ComVisible    | A value that indicates whether the COM type is visible. (`ComVisibleAttribute`)
