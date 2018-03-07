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
    /// This way we can just call the methods directly off of the class
    /// instead of instantiating an object and calling methods of the instance.
    /// Only use instance methods when they actually modify properties or data
    /// of the instance. If you're creating straight up utility methods that
    /// don't modify the class in any way, you can make the class static and
    /// all of its methods static. This is how the System.Console class works.
    /// We don't have to write something like Console console = new Console();
    /// in order to use its WriteLine() or ReadKey() methods
    /// </summary>
    static class FileUtil
    {
        /// <summary>
        /// Returns a list of drive letters on the current machine
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDrives()
        {
            /*Use the DriveInfo class's GetDrives() method to return
             * a list of DriveInfo objects (not just plain strings corresponding
             * to drive letters on the machine) for all the drive letters
             */ 
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
            /*The generic list of FileInfo objects declared below is just a dummy object
             * Each case branch in the switch{} block returns an object to the calling code
             * But if you omit the default block, C# is going to complain about the method
             * not always having a return path. In this particular applicaition, this method,
             * GetFilesInFolder() will **never** execute the default branch in the switch{} 
             * block
             */ 
            List<FileInfo> files = new List<FileInfo>();

            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            /* Using Linq query syntax here to get a list of files in the specified folder
             * since the sorting field will differ depending on how this method is called
             * we can't put code to determine the sorting field inside the Linq query
             * itself (I tried; it doesn't work!). So we defer sorting until after the list
             * has been built.
             */ 
            var fileList = from file in directoryInfo.EnumerateFiles()
                           where file.Name[0] != '$' && file.Name[0] != '.'
                           select file;

            /* Now use method syntax in Linq to sort the file list by the selected column
             * and in either ascending or descending order, depending on the parameters passed
             * to the method when it is called
             * Note the the method's return type is List<FileInfo>. The result of a Linq query, after
             * the OrderBy() method has been called on it, is IOrderedEnumerable. So we use
             * ToList() to cast it into type List<FileInfo> before returning to the calling code
             */ 
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
            /* Here we use Linq again to return a list of items, this time
             * a list of folders in the specified drive. We use the DirectoryInfo class
             * and call its EnumerateDirectories() method to get the list of folders,
             * represented by a collection DirectoryInfo objects, each of which 
             * has several pieces of information about a folder
             */ 
            DirectoryInfo directoryInfo = new DirectoryInfo(drive);

            var folders = from folder in directoryInfo.EnumerateDirectories()
                          where folder.Name[0] != '$' && folder.Name[0] != '.'
                          orderby folder.Name
                          select folder.Name;
            return folders.ToList<string>();
            


        }//GetFoldersInDrive()

    }//FileUtil
}
