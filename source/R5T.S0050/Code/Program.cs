using System;

using System.Threading.Tasks;


namespace R5T.S0050
{
    class Program
    {
        static async Task Main()
        {
            await RepositoryScripts.Instance.Create_ConsoleRepository();
        }
    }
}