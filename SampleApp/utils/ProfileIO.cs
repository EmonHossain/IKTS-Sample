using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.utils
{
    class ProfileIO
    {
        private string filePathForRead = null;
        private string filePathForWrite = null;
        private string filePath = null;

        public ProfileIO()
        {
            this.filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"profiles\\profile.json");
        }

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
        public List<dynamic> Read()
        {
            JsonSerializer serializer = new JsonSerializer();
            List<dynamic> objList = new List<dynamic>();

            using (FileStream s = File.Open(filePath, FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //if target file containes multiple JSON objects without list format
                reader.SupportMultipleContent = true;
                
                while (reader.Read())
                {
                    // deserialize only when there's "{" character in the stream
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        objList.Add(serializer.Deserialize<dynamic>(reader));
                    }
                }
            }
            return objList;
        }

        //write json file into a selected directory
        public void Write(string content)
        {
            File.AppendAllText(filePath, content);
        }

        public bool IsProfileExist()
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"profiles\\profile.json");
            //string filePathForRead = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"profiles\\profile.json");
            //Debug.WriteLine($"json :{filePath}");
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }


    }
}
