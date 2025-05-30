using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.System;
using Cosmos.Core;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.FileSystem.VFS;

namespace NexonKernel.FileSystem {
    public class Installer {
        public void installSystem() {
            Cosmos.System.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            
            Console.Clear();
            //Console.WriteLine("YourOS will be install in your pc");
            //Console.WriteLine("Create a username and password:");
            //Console.Write("Username: ");
            //string username = Console.ReadLine();
            //Console.Write("Password: ");
            //string cPassword = Console.ReadLine();
            //Console.Write(username +"> "); //when your put username variable it should look like this "The user name: "
            //Console.WriteLine("Creating System Directory..."); //Creating Directory or folder
            fs.CreateDirectory("0:\\GlobalRoot\\System86\\");
            fs.CreateDirectory("0:\\GlobalUser\\{username}\\Home\\Downloads\\")
            //Console.WriteLine("Creating File for user");
            fs.CreateFile("0:\\GlobalRoot\\System86\\GlobalConfig\\System.txt"); //Creating File System
            fs.CreateFile("0:\\GlobalRoot\\System86\\GlobalConfig\\users.db");
            fs.CreateFile("0:\\GlobalRoot\\System86\\GlobalConfig\\password.db");//creating a password files
            fs.CreateFile("0:\\GlobalUser\\{username}\\Home\\Downloads\\File.txt");//Create A Home Dirrctory. this will be a currect User Data Directory
            //Console.WriteLine("Setting User Preferences...");
            //File.WriteAllText("0:\\GlobalRoot\\System86\\GlobalConfig\\System.txt", write);
            //File.WriteAllText("0:\\GlobalRoot\\System86\\GlobalConfig\\users.db", username); `    //This will save username
            //File.WriteAllText("0:\\GlobalRoot\\System86\\GlobalConfig\\password.db", cPassword); //this one will save the user password
            //Console.WriteLine("Reboot in 3 seconds");
            Cosmos.HAL.Global.PIT.Wait(3000);
            Sys.Power.Reboot(); //when
        }
    }
}
