using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xunit;

namespace SolutionName.ProjectNameToReplace
{
    public partial class ProjectNameToReplaceVersionTests
    {
        private readonly Assembly assembly = typeof(Program).Assembly;

        [Fact]
        public void IsVersioned()
        {
            var version = this.assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Assert.Matches(Version(), version?.InformationalVersion);
        }

        [Fact]
        public void IsTimestamped()
        {
            var metadata = this.assembly.GetCustomAttributes<AssemblyMetadataAttribute>();
            var buildDate = metadata.Single(m => m.Key == "BuildDate").Value;
            Assert.True(Timestamp(buildDate));
        }

        private static bool Timestamp(string? value) => DateTime.TryParse(value, CultureInfo.InvariantCulture, out _);

        [GeneratedRegex(@"\d.\d.\d\+[a-z0-9]{7,}\*?")]
        private static partial Regex Version();
    }
}
