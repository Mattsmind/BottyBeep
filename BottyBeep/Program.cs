namespace BottyBeep
{
    class Program
    {
        static void Main(string[] args) => 
            new Core.Bot().StartAsync().GetAwaiter().GetResult();
    }
}
