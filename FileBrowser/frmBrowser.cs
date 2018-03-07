using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileBrowser
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            /*get list of drives on this machine and populate the 
            DriveList listbox control; could have iterated through the
            list of drives returned by the GetDrives() method and used
            the ListBox.Add() method to put each drive letter (as a string)
            into the DriveList listbox control, but I wanted to experiment
            with setting the ListBox.DataSource property to an in memory collection
            DriveList.DataSource = FileUtil.GetDrives();
            */

        }//frmBrowser_Load()

        private void DriveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*When the user selects a drive letter, populate the FolderList listbox
             * control from an in memory collection of strings corresponding to
             * the folder names under the selected drive letter. Again, here
             * we experiment with setting the DataSource property of a listbox
             * control to a collection of items, in this case an array of strings
             * returned by the call to the custom method GetFoldersInDrive(), which
             * is part of the FileUtil class
             */
            DriveInfo drive = new DriveInfo(DriveList.SelectedItem.ToString());

            /*the selected drive letter may not be ready, such as if it's an empty optical drive
             * so it is important to see if the drive is "ready" before trying to read its list of
             * folders
             */
            if (drive.IsReady)
            {
                FolderList.DataSource = FileUtil.GetFoldersInDrive(drive.Name);
            } else

            {
                /*if the selected drive is not ready then clear out the FolderList listbox
                 * control. Note that we can't use the ListBox.Items.Clear() method here because
                 * once the DataSource property has been set, the Items collection of a listbox
                 * is no longer editable
                 */
                FolderList.DataSource = null;
            }

        }


        private void FillFileList(int SortColumn = 0, string OrderDirection = "ASC")
        {
            /*might get permissions error so enclose the code to populate the listview
             * control in a try...catch block
             */ 
            try
            {
                /*GetFilesInFolder() returns a list of FileInfo objects, one for each file in the
                 * selected folder. We could have designed the function to return an array (or List)
                 * of strings and then extract the required information such as last modified date
                 * using the File class. But I wanted to work with FileInfo objects to practice
                 * using their properties. As it turns out, a FileInfo object does not expose
                 * properties such as file creation date so we end up using the File class methods like
                 * File.GetCreationTime() anyway!
                 */
                List<FileInfo> files = FileUtil.GetFilesInFolder(DriveList.SelectedItem.ToString()
                                                + FolderList.SelectedItem.ToString(), SortColumn, OrderDirection);

                /*don't want to accumulate filenames between actions that cause the
                 * FileList listview control to be populated so we must empty it out each 
                 * time we want to insert a colleciton of ListViewItem objects
                */
                FileList.Items.Clear();

                //need filename, created, modified, size and type
                foreach (FileInfo file in files)
                {
                    /*A row in a listview control is a ListViewItem. We must create
                     * a ListViewItem, which is an array of strings, and then pass
                     * that to the listview control's Add() method, for each file we
                     * get back from calling GetFilesInFolder()
                     */
                    var listViewItem = new ListViewItem(new string[]
                        {file.Name,
                    File.GetCreationTime(file.FullName).ToString("d"),
                    File.GetLastWriteTime(file.FullName).ToString("d"),
                    file.Length.ToString("N0"),
                    Path.GetExtension(file.Name).TrimStart('.').ToUpper()}
                        );
                    FileList.Items.Add(listViewItem);

                }//foreach(FileInfo file in files)

            }
            catch (Exception ex)
            {
                //in case something goes wrong, let's display a message to the user
                FileList.Items.Clear();
                MessageBox.Show("Can't view this folder's contents.","File Browser", 
                                MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

        }//FillFileList()

        private void FolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*sort by filename and ascending order by default when the user selects
             * a different folder; we only apply custom sorting if the user has clicked a
             * column header on the listview control. So here, the call to FillFileList()
             * takes no arguments and instead the default values for sorting column and 
             * sorting order will be applieed
             */ 
            FillFileList();
            
            }// FolderList_SelectedIndexChanged()

        private void FileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            /* To sort the listview control, which contains a list of filenames and associated
             * details like size and last date modified, we need to know which column was clicked,
             * which the e parameter in FileList_ColumnClick() allows us to access. We also
             * need to know whether to sort a given column in ascending or descending order.
             * 
             * To do that, when designing the listview's columns collection, I specified a default
             * value of "ASC" in each column header's Tag property.
             * 
             * The columns List below contains objects corresponding to the column headers
             * in the listview control. We would not be able to see these objects unless
             * we have made them public, which you can set in the column header properties
             * dialog when editing the listview control
             */

            List<ColumnHeader> columns = new List<ColumnHeader>(new []{

                columnHeader1,
                columnHeader2,
                columnHeader3,
                columnHeader4,
                columnHeader5
            });

           /*the Tag property of the column looks like a string but C# requires it to be
            * cast (converted) to a string, so it can be passed as the 2nd argument in the call
            * to FillFileList()
            * Note the use of the ternary operator for more compact code
           */

            FillFileList(e.Column, columns[e.Column].Tag.ToString());
            /*flip sorting order tag for column, i.e. from ascending to descending
             * and vice versa
             * Note, as mentioned elsewhere, we must cast (convert) the column header Tag
             * property value to a string, even though it already looks like a string
            */
            columns[e.Column].Tag  =   ((string)columns[e.Column].Tag == "ASC") ? "DESC" : "ASC";

        }
    }//frmBrowser : Form()
}//FileBrowser
