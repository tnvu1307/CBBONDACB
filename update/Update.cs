using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;

namespace update
{
    class Update
    {
        // Fields
        private Clslog l = new Clslog(true);
        private string tfn;
        private string tpath;
        //parameter
        private string pv_Update = ConfigurationSettings.AppSettings["Update"];
        private string pv_basepath = ConfigurationSettings.AppSettings["BasePath"];
        private string pv_reportPath = ConfigurationSettings.AppSettings["ReportPath"];
        private string pv_WaitParentToExit = ConfigurationSettings.AppSettings["WaitParentToExit"];
        private string pv_KillParentAfterWait = ConfigurationSettings.AppSettings["KillParentAfterWait"];
        private string pv_UpdateURL = ConfigurationSettings.AppSettings["UpdateURL"];
        private string pv_ProcessName = ConfigurationSettings.AppSettings["ProcessName"];
        private string pv_StartExe = ConfigurationSettings.AppSettings["StartExe"];
        private string pv_Version = ConfigurationSettings.AppSettings["Version"];
        private string pv_OldVersion = ConfigurationSettings.AppSettings["OldVersion"];
        private string pv_updatetype = ConfigurationSettings.AppSettings["UpdateType"];

        public WebClient wClient;

        // Methods
        private void DeleteTempFiles()
        {
            try
            {
                ProjectData.ClearProjectError();
                File.Delete(tfn);
                Directory.Delete(tpath, true);
                l.WriteLine("temp-files deleted");
                ProjectData.ClearProjectError();
            }
            catch (Exception obj1)
            {
                Exception exception1 = (Exception)obj1;
                ProjectData.SetProjectError(exception1);
                l.Write(exception1.ToString());
            }
        }

        public void DownloadUpdate()
        {
            try
            {
                ProjectData.ClearProjectError();
                int tickCount = Environment.TickCount;
                wClient = new WebClient();
                l.WriteLine("Downloading... ");
                tickCount = Environment.TickCount;
                string address = pv_UpdateURL;
                l.WriteLine("Update Path: " + address);
                string environmentVariable = Environment.GetEnvironmentVariable("TEMP");
                tfn = environmentVariable + @"\" + StringType.FromInteger(Environment.TickCount);
                wClient.DownloadFile(address, tfn);
                l.WriteLine("done in " + StringType.FromDouble(Math.Round((double)(((double)(Environment.TickCount - tickCount)) / 1000.0), 3)) + " seconds\r\n");
                unpack();

                ProjectData.ClearProjectError();
            }
            catch (Exception obj1)
            {
                Exception exception1 = (Exception)obj1;
                ProjectData.SetProjectError(exception1);
                l.Write(exception1.ToString());
            }
        }

        public void init()
        {
            l.ClearLog();
            l.WriteLine("UPDATE TIME:" + StringType.FromDate(DateTime.Now));
            l.WriteLine("Starting Online-Update  version " + Application.ProductVersion);
            l.WriteLine("OS:      " + Environment.OSVersion.ToString());
            l.WriteLine("Machine: " + Environment.MachineName + "." + Environment.UserDomainName);
            l.WriteLine("User:    " + Environment.UserName);
            if (pv_Update == null)//
            {
                l.WriteLine("No Update awaiting. Exiting Update-Process.");
                ProjectData.EndApp();
            }
        }

        public void killparent()
        {
            Process[] processesByName = Process.GetProcessesByName(pv_ProcessName);
            if (processesByName.Length >= 1)
            {
                for (int i = 0; i < processesByName.Length; i++)
                {
                    Process process = processesByName[i];
                    int num = IntegerType.FromString(pv_WaitParentToExit);
                    if (num > 0)
                    {
                        l.WriteLine("Waiting for Parent-Application to exit ( " + StringType.FromInteger(num) + "sec )...");
                        Thread.Sleep((int)(num * 0x3e8));
                        if (!process.HasExited)
                        {
                            if (StringType.StrCmp(pv_KillParentAfterWait, "1", false) == 0)
                            {
                                process.Kill();
                                l.WriteLine("Killing Process after waiting");
                            }
                            else
                            {
                                l.WriteLine("Aborting Update after waiting process to exit");
                                ProjectData.EndApp();
                            }
                        }
                        else
                        {
                            l.WriteLine("successfully waited for process");
                        }
                    }
                    else
                    {
                        switch (num)
                        {
                            case 0:
                                l.WriteLine("killing Process instantly");
                                process.Kill();
                                break;

                            case -1:
                                l.WriteLine("Aborting Update because of running process");
                                ProjectData.EndApp();
                                break;
                        }
                    }
                }
            }
            else
            {
                l.WriteLine("Parent-Application not running");
            }
        }

        public void DoUpdate()
        {
            init();
            killparent();
            clearAttributes();
            DownloadUpdate();
            ProcessUpdate();
            DeleteTempFiles();
            RestartProg();
            ProjectData.EndApp();
        }

        public void ProcessUpdate()
        {
            string[] strArray3 = { "0" };
            int flg = 0; ;
            string[] files;
            int index = 0;
            try
            {
                ProjectData.ClearProjectError();
                l.WriteLine("copying files ...");
                //SONLT: XU UPDATE FILE THONG TIN
                if (int.Parse(pv_updatetype) == 1)
                {
                    //sonlt: lay tat cac cac file ben ngoai
                    files = Directory.GetFiles(tpath);
                    flg = files.Length;
                    l.WriteLine("Update version:");
                    while (index < flg)
                    {
                        File.Copy(files[index], pv_basepath + @"\" + Path.GetFileName(files[index]), true);
                        l.WriteLine("List File Update: " + Path.GetFileName(files[index]));
                        index++;
                    }
                    l.WriteLine("Update Version Directory");
                    CopyFile(pv_basepath);
                }
                //SONLT: XU LY UPDATE REPORT
                else if (int.Parse(pv_updatetype) == 2)
                {
                    l.WriteLine("Update report:");
                    /*
                    if (!Directory.Exists(pv_reportPath))
                    {
                        Directory.CreateDirectory(pv_reportPath);                        
                    }
                    */
                    l.WriteLine("Update Report Directory");
                    CopyFile(pv_basepath);                    
                    File.Create(pv_basepath + @"\" + pv_Version + ".dat");                    
                    if (File.Exists(pv_basepath + @"\" + pv_OldVersion + ".dat"))
                    {
                        File.Delete(pv_basepath + @"\" + pv_OldVersion + ".dat");
                    }
                }
                l.WriteLine("copied!");
                ProjectData.ClearProjectError();
            }
            catch (Exception obj1)
            {
                Exception exception1 = (Exception)obj1;
                ProjectData.SetProjectError(exception1);
                l.WriteLine(exception1.ToString());
            }
        }

        public void RestartProg()
        {
            l.Write("Starting programme...");
            Process.Start(pv_StartExe);
            l.Write(" started\r\n");
            l.WriteLine("Update successful and finished. Exiting Update-Process now.");
            l = null;
            try
            {
                File.Delete(Application.ExecutablePath + ".config");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
                l.WriteLine(exception1.ToString());
            }
        }

        public void CopyFile(string v_UpdatePath)
        {
            int index = 0;
            string[] directories = Directory.GetDirectories(tpath);
            int dirlg = directories.Length;
            while (index < dirlg)
            {
                string v_basepath = v_UpdatePath;
                string[] dr = directories[index].Split('\\');
                v_basepath += @"\" + dr[dr.Length - 1];
                if (!Directory.Exists(v_basepath))
                {
                    Directory.CreateDirectory(v_basepath);
                }
                //Get list files
                string[] files = Directory.GetFiles(directories[index]);
                int flg = files.Length;
                int i = 0;
                while (i < flg)
                {
                    File.Copy(files[i], v_basepath + @"\" + Path.GetFileName(files[i]), true);
                    l.WriteLine("List File in folder " + v_basepath + " Update: " + Path.GetFileName(files[i]));
                    i++;
                }
                index++;
            }
        }

        public void CopyTo(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        private void unpack()
        {
            Exception exception;
            try
            {
                ProjectData.ClearProjectError();
                l.WriteLine("unpacking ...");
                byte[] buffer = new byte[0x1024];
                tpath = Path.GetDirectoryName(tfn) + @"\dir" + Path.GetFileNameWithoutExtension(tfn);
                Directory.CreateDirectory(tpath);
                var file = new ZipFile(tfn);
                foreach (ZipEntry x in file)
                {
                    string bpath = tpath;
                    Stream inputStream = file.GetInputStream(x);
                    l.WriteLine("unpacking ... x.Name:" + x.Name);
                    string[] sp = x.Name.Split('/');
                    int i;
                    for (i = 0; i <= sp.Length - 1; i++)//SONLT: i = 0: file zip ko chua folder; i=1: file zip chua folder
                    {
                        if (i < sp.Length - 1)
                        {
                            bpath += @"\" + sp[i];
                            if (!Directory.Exists(bpath))
                            {
                                Directory.CreateDirectory(bpath);
                                l.WriteLine("Create temp directory: " + bpath);
                            }
                        }
                        else
                        {
                            l.WriteLine("unpacking ... Copy file:" + i);
                            l.WriteLine("unpacking ... Copy file:" + sp[i]);
                            if (sp[i] != "")
                            {
                                FileStream stream = File.OpenWrite(bpath + @"\" + sp[i]);
                                //(new update()).CopyTo(inputStream, stream);
                                CopyTo(inputStream, stream);
                                //inputStream.CopyTo(stream);
                                l.WriteLine("Stream: " + sp[i]);
                                stream.Close();
                            }
                        }
                    }
                }
                file.Close();
                file = null;
                l.Write("Unpacked.");
                l.WriteLine("unpacked to " + tpath);
                ProjectData.ClearProjectError();
            }
            catch (Exception obj1)
            {
                Exception exception1 = (Exception)obj1;
                ProjectData.SetProjectError(exception1);
                exception = exception1;
                l.WriteLine(exception.ToString());
            }
        }

        private void clearAttributes()
        {
            try
            {
                l.WriteLine("Begin clearAttributes");
                string path = Directory.GetCurrentDirectory();
                l.WriteLine("Begin clearAttributes with path: " + path);

                l.WriteLine("Begin remove FileAttributes.ReadOnly");
                l.WriteLine("...");
                // Create the file if it exists. 
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                DirectoryInfo directory = new DirectoryInfo(path);
                foreach (var file in directory.GetFiles("*", SearchOption.AllDirectories))
                {
                    file.Attributes &= ~FileAttributes.ReadOnly;
                    //l.WriteLine("The " + file.Name  + " is no longer ReadOnly.");
                }
                
                l.WriteLine("End remove FileAttributes.ReadOnly");

                l.WriteLine("Begin Add Full Permission");
                DirectoryInfo dInfo = new DirectoryInfo(path);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();
                dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
                dInfo.SetAccessControl(dSecurity);
                l.WriteLine("End Add Full Permission");

            }
            catch (Exception ex)
            {
                l.WriteLine("Error when clearAttributes!!!!!!.");
                l.WriteLine("Error Message:" + ex.Message );
            }

        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }
    }
}
