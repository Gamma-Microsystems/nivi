﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Sys = Cosmos.System;

namespace NiVi.Builtin
{
    internal class fvfs : Command
    {
        public fvfs(String name) : base(name) { }
        public override String execute(String[] args)
        {
            String response = "";
            switch (args[0])
            {
                case "touch":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rm":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "mkdir":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "rmd":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1], true);
                    }

                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;
                case "cat":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();
                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];

                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            response = "File not found";
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                default:
                    response = "Unexpected argument:" + args[0];
                    break;
            }
            return response;
        }
    }
}