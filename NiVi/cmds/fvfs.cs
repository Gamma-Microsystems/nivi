using System;
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
            string dir = @"0:\";
            var input = Console.ReadLine();
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

                case "cd":
                    try
                    {
                        if (input.Length < 1)
                        {
                            response = "Input is too short. Please provide a valid directory path.";
                            break;
                        }

                        string path = input.Remove(0, 3).Trim(); // Remove "cd " and trim any whitespace
                        Directory.SetCurrentDirectory(@"0:\" + path);
                        dir = @"0:\" + path;
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }
                    break;

                case "mv":
                    string oldPath = args[0];
                    string newPath = args[1];

                    try
                    {
                        if (File.Exists(oldPath))
                        {
                            if (File.Exists(newPath))
                            {
                                Console.WriteLine($"Error: File {newPath} already exists.");
                                break;
                            }

                            if (Directory.Exists(newPath))
                            {
                                newPath = Path.Combine(newPath, Path.GetFileName(oldPath));
                            }

                            byte[] fileContent = File.ReadAllBytes(oldPath);

                            File.WriteAllBytes(newPath, fileContent);

                            File.Delete(oldPath);

                            Console.WriteLine($"Moved file from {oldPath} to {newPath}");
                        }
                        else
                        {
                            Console.WriteLine($"Error: File {oldPath} does not exist.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
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