﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using RemoveMarkOfWeb.Classes;
using static RemoveMarkOfWeb.Classes.Utilities;

namespace RemoveMarkOfWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*
             * If folder was passed as a command-line
             *
             * 
             */
            if (Arguments.HasPath)
            {
                FolderTextBox.Text = Arguments.Path;
            }
            string solutiondir = Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.FullName;
            Console.WriteLine(solutiondir);
        }

        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FolderTextBox.Text))
            {
                try
                {
                    await UnblockFiles(FolderTextBox.Text);
                    MessageBox.Show(@"Done");
                }
                catch (Exception exception)
                {
                    MessageBox.Show($@"Failed to unblock folder\n{exception.Message}");
                }
                
            }
            else
            {
                MessageBox.Show(@"Folder provided does not exists or no folder specified\nYou can drag from Windows Explorer");
            }
        }

        private void FolderTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void FolderTextBox_DragDrop(object sender, DragEventArgs e)
        {
            var droppedData = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (Directory.Exists(droppedData[0]))
            {
                FolderTextBox.Text = droppedData[0];
            }
        }
    }
}
