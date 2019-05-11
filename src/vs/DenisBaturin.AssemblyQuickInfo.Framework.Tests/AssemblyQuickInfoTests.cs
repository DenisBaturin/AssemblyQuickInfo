using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace DenisBaturin.AssemblyQuickInfo.Framework.Tests
{
    public class AssemblyQuickInfoTests
    {
        private readonly ITestOutputHelper _output;
        public AssemblyQuickInfo AsmInfo;

        public AssemblyQuickInfoTests(ITestOutputHelper output)
        {
            _output = output;

            var executingAssembly = Assembly.GetExecutingAssembly();
            AsmInfo = new AssemblyQuickInfo(executingAssembly);
        }

        public class TestCaseItem
        {
            public TestCaseItem(string testDescription)
            {
                TestDescription = testDescription;
            }

            public string TestDescription { get; }
            public string ActualPropertyValue;
            public string ExpectedPropertyValue;

            public override string ToString() => TestDescription;
        }

        public static TheoryData<TestCaseItem> TestCases =
            new TheoryData<TestCaseItem>
            {
                new TestCaseItem($"{nameof(AssemblyQuickInfo.Name)}")
                {
                    ActualPropertyValue =  new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Name,
                    ExpectedPropertyValue = "DenisBaturin.AssemblyQuickInfo.Framework.Tests"
                },
                new TestCaseItem("FullName")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).FullName,
                    ExpectedPropertyValue = "DenisBaturin.AssemblyQuickInfo.Framework.Tests, Version=1.0.1.2, Culture=neutral, PublicKeyToken=null"
                },
                new TestCaseItem("CodeBase")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).CodeBase,
                    ExpectedPropertyValue = Assembly.GetExecutingAssembly().CodeBase
                },
                new TestCaseItem("Version")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Version(),
                    ExpectedPropertyValue = "1.0.1.2"
                },
                new TestCaseItem("Version (3 fields)")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Version(3),
                    ExpectedPropertyValue = "1.0.1"
                },
                new TestCaseItem("Copyright")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Copyright,
                    ExpectedPropertyValue = "Copyright © Denis Baturin, 2019"
                },
                new TestCaseItem("Company")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Company,
                    ExpectedPropertyValue = "Denis Baturin"
                },
                new TestCaseItem("Configuration")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Configuration,
                    ExpectedPropertyValue = "Debug"
                },
                new TestCaseItem("Description")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Description,
                    ExpectedPropertyValue = "Tests (.NET Framework) for DenisBaturin.AssemblyQuickInfo"
                },
                new TestCaseItem("Product")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Product,
                    ExpectedPropertyValue = "DenisBaturin.AssemblyQuickInfo"
                },
                new TestCaseItem("Title")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Title,
                    ExpectedPropertyValue = "DenisBaturin.AssemblyQuickInfo.Framework.Tests"
                },
                new TestCaseItem("Trademark")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Trademark,
                    ExpectedPropertyValue = "DenisBaturin"
                },
                new TestCaseItem("FileVersion")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).FileVersion,
                    ExpectedPropertyValue = "1.0.1.3"
                },
                new TestCaseItem("Guid")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Guid,
                    ExpectedPropertyValue = "0380bb0a-fe71-4322-bb33-bc0d50e5b348"
                },
                new TestCaseItem("NeutralResourcesLanguageCultureName")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).NeutralResourcesLanguageCultureName,
                    ExpectedPropertyValue = "en"
                },
                new TestCaseItem("ComVisible")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).ComVisible,
                    ExpectedPropertyValue = "False"
                },
                new TestCaseItem("Location")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).Location,
                    ExpectedPropertyValue = Assembly.GetExecutingAssembly().Location
                },
                new TestCaseItem("DirectoryName")
                {
                    ActualPropertyValue = new AssemblyQuickInfo(Assembly.GetExecutingAssembly()).DirectoryName,
                    ExpectedPropertyValue = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                },
            };


        [Theory]
        [MemberData(nameof(TestCases))]
        public void AssemblyQuickInfoTest(TestCaseItem testCase)
        {
            // Given
            _output.WriteLine(testCase.TestDescription);
            
            // When

            // Then
            Assert.Equal(testCase.ExpectedPropertyValue, testCase.ActualPropertyValue);
        }
    }
}