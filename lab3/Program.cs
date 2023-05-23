using lab3;
using System.Net;

namespace lab3
{
    class Program
    {
        private static string dnsServer;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Command: ");
                string[] command = Console.ReadLine().Split(' '); //input

                if (command[0].ToLower() == "resolve")
                {
                    if (IPAddress.TryParse(command[1], out IPAddress ip))
                    {
                        // Rezolvă domeniul pentru o adresă IP
                        string hostName = Dns.GetHostEntry(ip).HostName;
                        Console.WriteLine($"Host name for {ip}: {hostName}");
                    }
                    else
                    {
                        // Rezolvă adresele IP pentru un domain
                        IPAddress[] addresses = Dns.GetHostAddresses(command[1]);
                        Console.WriteLine($"IP addresses for {command[1]}:");

                        foreach (IPAddress address in addresses)
                        {
                            Console.WriteLine(address);
                        }
                    }
                }
                else if (command[0].ToLower() == "use" && command[1].ToLower() == "dns")
                {
                    // Schimbă DNS serverul implicit
                    dnsServer = command[2];
                    Console.WriteLine($"Using DNS server: {dnsServer}");
                }
                else
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }
    }
}
