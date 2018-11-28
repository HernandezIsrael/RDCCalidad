using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using Ionic.Zlib;
using System.IO;

namespace Model
{
    public class CompressHelper
    {
        FTPHelper ftp = new FTPHelper();
        public bool DowloadZip(List<ListDocuments> list,out MemoryStream Zip) {
            bool val = false;
            Stream file = null;
            Zip = new MemoryStream();
            try {
                    using (ZipFile FileCompress = new ZipFile()) {
                        FileCompress.CompressionLevel = CompressionLevel.BestCompression;
                    foreach (ListDocuments item in list)
                    {
                        if (ftp.FTPDownload(item.VNAME, out file))
                        {
                            FileCompress.AddEntry(item.NAME, ToByteArray(file));
                        }
                        file.Flush();
                    }
                    FileCompress.Save(Zip);
                    if (Zip.Length > 0) 
                        val = true;
                }
            }
            catch (Exception ex) {
            }
            return val;
        }
        private static byte[] ToByteArray(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
    public class ListDocuments {
        private string vname;
        public string VNAME {
            get { return vname; }
            set { vname = value; }
        }
        private string name;
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }
    }

}
