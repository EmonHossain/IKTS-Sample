using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Profile
    {
        public Profile()
        {

        }

        private string _description;
        private string _material;
        private List<string> _workCentres = new List<string>();
        private string _length;
        private string _finish;
        private Dictionary<string, string> _supplier = new Dictionary<string, string>();
        private string _note;
        private string createdOn;
        private string domain;

        public string Description { get => _description; set => _description = value; }
        public string Material { get => _material; set => _material = value; }
        public string Length { get => _length; set => _length = value; }
        public List<string> WorkCentres { get => _workCentres; set => _workCentres = value; }
        public string Finish { get => _finish; set => _finish = value; }
        public Dictionary<string, string> Supplier { get => _supplier; set => _supplier = value; }
        public string Note { get => _note; set => _note = value; }
        public string CreatedOn { get => createdOn; set => createdOn = value; }
        public string Domain { get => domain; set => domain = value; }
    }
}
