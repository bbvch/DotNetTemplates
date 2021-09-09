using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace SolutionName.ProjectNameToReplace
{
    public class ProjectNameToReplaceVersionTests
    {
        private readonly Assembly assembly = typeof(Program).Assembly;

        [Fact]
        public void IsVersioned()
        {
            var version = this.assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            version!.InformationalVersion.Should().MatchRegex(
                new Regex(@"\d.\d.\d\+[a-z0-9]{7,}\*?"),
                "the version should be suffixed by the git hash with dirty flag");
        }

        [Fact]
        public void IsTimestamped()
        {
            var metadata = this.assembly.GetCustomAttributes<AssemblyMetadataAttribute>();
            metadata.Single(_ => _.Key == "BuildDate").Value.Should().Match(_ => Timestamp(_));
        }

        private static bool Timestamp(string value) => DateTime.TryParse(value, out _);
    }
}
