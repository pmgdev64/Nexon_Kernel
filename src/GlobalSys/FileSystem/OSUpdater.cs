using Cosmos.System;
using Cosmos.System.FileSystem;
using System.IO;


namespace NexonKernel.FileSystem {
    public class OSUpdater
    {
        public static void RunUpdater()
        {
            try
            {
                var fs = new CosmosVFS();
                VFSManager.RegisterVFS(fs);
                
                string updatePath = @"0:\\GlobalUser\\{username}\\Home\\Downloads\\";
                string systemPath = @"0:\\GlobalRoot\\System86\\";
                string username = File.ReadAllText("0:\\GlobalRoot\\System86\\GlobalConfig\\users.db")
                
                if (Directory.Exists(updatePath))
                {
                    var files = Directory.GetFiles(updatePath);
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileName(file);
                        var destFile = Path.Combine(systemPath, fileName);
                        
                        if (File.Exists(destFile))
                        File.Delete(destFile);
                        
                        File.Copy(file, destFile);
                        Console.WriteLine($"Updated: {fileName}");
                    }
                    
                    Console.WriteLine("Update complete. Please reboot.");
                }
                else
                {
                    Console.WriteLine("No update folder found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update failed: " + ex.Message);
            }
        }
    }
}
