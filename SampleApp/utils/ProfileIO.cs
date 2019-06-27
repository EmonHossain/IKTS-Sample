using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.utils
{
    class ProfileIO
    {
        private string filePathForRead = null;
        private string filePathForWrite = null;

        public ProfileIO SaveFile()
        {
            //Dialog open window criteria
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Filter = "JSON File|*.json|All Files|*.*";
            fileDialog.DefaultExt = ".json";
            
            //execute pre fixed crateria and open dialog box
            Nullable<bool> dialogOk = fileDialog.ShowDialog();

            //if dialog box is failed to open then nothing will happen. return null instead.
            if ((bool)dialogOk)
            {
                filePathForWrite = fileDialog.FileName;
            }
            return this;
        }

        //Open a dialog box to select a single file to read
        public ProfileIO SelectFile()
        {
            //Dialog open window criteria
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Multiselect = false;
            fileDialog.Filter = "JSON File|*.json|All Files|*.*";
            fileDialog.DefaultExt = ".json";

            //execute pre fixed crateria and open dialog box
            Nullable<bool> dialogOk = fileDialog.ShowDialog();

            //if dialog box is failed to open then nothing will happen. return null instead.
            if ((bool) dialogOk)
            {
                filePathForRead = fileDialog.FileName;
            }
            return this;
        }

        //read selected file
        public string Read()
        {
            return File.ReadAllText(filePathForRead);
        }

        //write json file into a selected directory
        public void Write(string content)
        {
            File.WriteAllText(filePathForWrite, content);
        }
    }
}
