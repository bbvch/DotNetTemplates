using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
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
            version!.InformationalVersion.Should().MatchRegex(
                Version(),
                "the version should be suffixed by the git hash with dirty flag");
        }

        [Fact]
        public void IsTimestamped()
        {
            var metadata = this.assembly.GetCustomAttributes<AssemblyMetadataAttribute>();
            metadata.Single(m => m.Key == "BuildDate").Value.Should().Match(buildDate => Timestamp(buildDate));
        }

        private static bool Timestamp(string value) => DateTime.TryParse(value, CultureInfo.InvariantCulture, out _);

        [GeneratedRegex(@"\d.\d.\d\+[a-z0-9]{7,}\*?")]
        private static partial Regex Version();
    }
}
