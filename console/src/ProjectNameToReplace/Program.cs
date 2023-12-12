using System;
using System.Threading.Tasks;

namespace SolutionName.ProjectNameToReplace
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            await Console.Error.WriteLineAsync($"Got {args.Length - 1} arguments");
            return 0;
        }
    }
}
