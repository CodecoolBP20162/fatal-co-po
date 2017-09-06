namespace GettingStartedLib
{
    public class WcfPingTest : IWcfPingTest
    {
        public const string magicString = "Someshit"; // this is random, just to see if you get the right result

        public string Ping() { return magicString; }
    }
}
