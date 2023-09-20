using System.Diagnostics;
using System.IO;
using System.Net;

static async Task DownloadFile(string DownloadLink, string placefile)
{

    string url = DownloadLink;
    string destinationPath = placefile; // Replace with the path where you want to save the downloaded file
    var fi1 = new System.IO.FileInfo(destinationPath);

    try
    {
        using (WebClient client = new WebClient())
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await client.DownloadFileTaskAsync(new Uri(url), destinationPath);

            stopwatch.Stop();

            long fileSize = new System.IO.FileInfo(destinationPath).Length;
            double downloadSpeedMbps = (fileSize / (stopwatch.Elapsed.TotalSeconds * 1024 * 1024));
            
            Console.WriteLine("---------------------------------------");

            Console.WriteLine($"Download completed in {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
            Console.WriteLine($"File Size: {fileSize / (1024 * 1024):F2} MB");
            Console.WriteLine($"Download Speed: {downloadSpeedMbps:F2} Mbps");

            Console.WriteLine("---------------------------------------");

            Console.WriteLine("File Information");
            Console.WriteLine($"Name: {fi1.Name}");
            Console.WriteLine($"Full Path: {fi1.FullName}");
            Console.WriteLine($"Size: {fi1.Length} bytes");
            Console.WriteLine($"Creation Date: {fi1.CreationTime}");
            Console.WriteLine($"Last Modification Date: {fi1.LastWriteTime}");
            Console.WriteLine($"Attributes: {fi1.Attributes}");

            Console.WriteLine("---------------------------------------");

            Console.ReadKey();
        }
    }
    catch { }
}

DownloadFile("Google.com", "FileName.Ext");

Console.ReadLine();