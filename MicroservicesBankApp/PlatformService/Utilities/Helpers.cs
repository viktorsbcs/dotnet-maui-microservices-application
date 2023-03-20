namespace PlatformService.Utilities
{
    internal static class Helpers
    {
        internal static string GeneretaRandomUserId()
        {
            return new Random().NextInt64(1000, 9999).ToString();
        }
    }
}
