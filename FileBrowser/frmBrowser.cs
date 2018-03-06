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
            //get list of drives on this machine
            DriveList.DataSource = FileUtil.GetDrives();

        }//frmBrowser_Load()

        private void DriveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo drive = new DriveInfo(DriveList.SelectedItem.ToString());

            if (drive.IsReady)
            {
                FolderList.DataSource = FileUtil.GetFoldersInDrive(drive.Name);
            } else

            {
                FolderList.DataSource = null;
            }

        }


        private void FillFileList(int SortColumn = 0, string OrderDirection = "ASC")
        {
            //might get permissions error
            try
            {
                List<FileInfo> files = FileUtil.GetFilesInFolder(DriveList.SelectedItem.ToString()
                                                + FolderList.SelectedItem.ToString(), SortColumn, OrderDirection);

                FileList.Items.Clear();

                //need filename, created, modified, size and type
                foreach (FileInfo file in files)
                {
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
                FileList.Items.Clear();
                MessageBox.Show("Can't view this folder's contents.","File Browser", 
                                MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

        }//FillFileList()

        private void FolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sort by filename and ascending order by default
            FillFileList();
            
            }// FolderList_SelectedIndexChanged()

        private void FileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            

            List<ColumnHeader> columns = new List<ColumnHeader>(new []{

                columnHeader1,
                columnHeader2,
                columnHeader3,
                columnHeader4,
                columnHeader5
            });

            //MessageBox.Show(e.Column.ToString() + ", " + columns[e.Column].Tag.ToString());

            FillFileList(e.Column, columns[e.Column].Tag.ToString());
            //flip sorting order tag for column
            columns[e.Column].Tag  =   ((string)columns[e.Column].Tag == "ASC") ? "DESC" : "ASC";

        }
    }//frmBrowser : Form()
}//FileBrowser
