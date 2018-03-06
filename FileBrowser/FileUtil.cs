using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileBrowser
{
    /// <summary>
    /// A static class containing methods for handling folders and files
    /// </summary>
    static class FileUtil
    {
        /// <summary>
        /// Returns a list of drive letters on the current machine
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDrives()
        {
            List<string> drives = new List<string>();
            DriveInfo[] driveInfo = DriveInfo.GetDrives();

            foreach(DriveInfo di in driveInfo)
            {
                drives.Add(di.Name);
            }//foreach(DriveInfo di in driveInfo)

            return drives;
           

        }//GetDirectories()

        /// <summary>
        /// Returns a list of FileInfo objects, which provide details on a given file
        /// that can be used to populate a ListView object
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static List<FileInfo> GetFilesInFolder(string folder, int SortColumn, string OrderDirection)
        {

            List<FileInfo> files = new List<FileInfo>();

            DirectoryInfo directoryInfo = new DirectoryInfo(folder);

            var fileList = from file in directoryInfo.EnumerateFiles()
                           where file.Name[0] != '$' && file.Name[0] != '.'
                           //orderby file.Name
                           select file;

            switch(SortColumn)
            {
                case 0:
                    return (OrderDirection == "ASC") ? fileList.OrderBy(file => file.Name).ToList() 
                           : fileList.OrderByDescending(file => file.Name).ToList();

                case 1:
                    return (OrderDirection == "ASC") 
                        ? fileList.OrderBy(file => File.GetCreationTime(file.FullName)).ToList() : 
                        fileList.OrderByDescending(file => File.GetCreationTime(file.FullName)).ToList();

                case 2:
                    return (OrderDirection == "ASC") ? 
                        fileList.OrderBy(file => File.GetLastWriteTime(file.FullName)).ToList() : 
                        fileList.OrderByDescending(file => File.GetLastWriteTime(file.FullName)).ToList();

                case 3:
                    return (OrderDirection == "ASC") ? fileList.OrderBy(file => file.Length).ToList() : 
                           fileList.OrderByDescending(file => file.Length).ToList();

                case 4:
                    return (OrderDirection == "ASC") ? fileList.OrderBy(file => Path.GetExtension(file.Name).ToUpper()).ToList() : 
                           fileList.OrderByDescending(file => Path.GetExtension(file.Name).ToUpper()).ToList();

                default:
                    //return empty list; only put this here b/c compiler complains that the method
                    //doesn't always have a return path
                    return files;
            }
            
            //return fileList.ToList();
        }//GetFileInfo()

        public static List<string> GetFoldersInDrive(string drive)
        {
            
            DirectoryInfo directoryInfo = new DirectoryInfo(drive);

            var folders = from folder in directoryInfo.EnumerateDirectories()
                          where folder.Name[0] != '$' && folder.Name[0] != '.'
                          orderby folder.Name
                          select folder.Name;
            return folders.ToList<string>();
            


        }//GetFoldersInDrive()

    }//FileUtil
}
