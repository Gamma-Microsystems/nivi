using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using NiVi.Builtin;

namespace NiVi
{
    public class Kernel : Sys.Kernel
    {
        private Sys.FileSystem.CosmosVFS fvfs; // Fat/Virtual File System

        protected override void BeforeRun()
        {
            Console.SetWindowSize(90, 30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            this.fvfs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.fvfs);
            Console.WriteLine("\nWelcome to NiviOS!\n");
        }

        protected override void Run()
        {
            Shell shell = new NiVi.Builtin.Shell();
            Console.Write("$ ");
            var builtin = Console.ReadLine();
            var response = shell.proccesInput(builtin);
            Console.WriteLine(response);
        }
    }
}