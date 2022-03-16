using System;

namespace BugTrackingSystem.Services.Extensions
{
    internal static class InputValidation
    {
        internal static T ValidateNotNull<T>(this T model, string message = null)
            => model ?? throw new ArgumentNullException(message ?? nameof(model));

        internal static string ValidateNotNull(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(nameof(str), "String is null, empty or a whitespace.");
            }

            return str;
        }
    }
}
