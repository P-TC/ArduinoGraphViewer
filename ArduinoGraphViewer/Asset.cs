using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoGraphViewer
{
    public class Asset
    {
        public int AssetID { get; set; }
        public Image? Picture { get; set; }
        public byte[]? File { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

    }
}
