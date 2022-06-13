using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace BugTrackingSystem.Tests.Extensions
{
    internal static class TestCaseDataExtensions
    {
        internal static IEnumerable<T> ExtractData<T>(this IEnumerable<TestCaseData> testCaseData) where T : class
            => testCaseData.Select(data => data.Arguments[0] as T);
    }
}
