using System;
using System.Threading.Tasks;

namespace SolutionName.ProjectNameToReplace
{
    public static class Program
    {
        public static Task Main(string[] args)
        {
            return Console.Error.WriteLineAsync($"Got {args.Length - 1} arguments");
        }
    }
}
