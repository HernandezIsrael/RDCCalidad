using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model
{
   public class FTPHelper
    {
        public  bool FTPDownload(string VirtualName, out Stream Arch)
        {
            bool Val = false;
            string url = string.Empty;
            Ca_FTP Ftp = UriFtp();
            Arch = null;
            if (Ftp.Id_Ftp > 0)
                url = Ftp.URL;
            else return Val;

            string ftpBaseAddress = string.Format("ftp://{0}/{1}", url, VirtualName);
           
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpBaseAddress);

            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(Ftp.Usuario,Ftp.Pass);
            request.UsePassive = true;
            // request.UseBinary = true;
            // request.KeepAlive = false;
            try
            {


                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //recuperamos el estatus de nuestra peticion de subir un archivo al ftp, se puede usar el metofo StatusCode para saber que codigo 
                //maneja el ftp para cada peticion
                // MessageBox.Show(response.StatusDescription);

                Stream responseSteam = response.GetResponseStream();
                Arch = responseSteam;
                Val = true;
                //if (response.StatusCode == FtpStatusCode.ClosingData)
                //{
                //    Val = true;
                //    // VEnvio = "2.32";
                //}
            }
            catch (Exception ex)
            {

            }


            return Val;
        }

        public  bool FTPSubir(string VirtualName, HttpPostedFileBase File)
        {
            bool Val = false;
            string url = string.Empty;
            Ca_FTP Ftp = UriFtp();
            if (Ftp.Id_Ftp > 0)
                url = Ftp.URL;
            else return Val;
            string ftpBaseAddress = string.Format("ftp://{0}/{1}", url, VirtualName);
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(ftpBaseAddress);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(Ftp.Usuario, Ftp.Pass);
            request.RequestUri.Port.ToString();
            request.UsePassive = false;
            request.UseBinary = true;
            request.KeepAlive = false;
            try
            {
                using (Stream destination = request.GetRequestStream())
                {
                    File.InputStream.CopyTo(destination);
                    destination.Flush();
                }
            }
            catch (Exception ex)
            {
                Val = false;
            }
            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //recuperamos el estatus de nuestra peticion de subir un archivo al ftp, se puede usar el metofo StatusCode para saber que codigo 
                //maneja el ftp para cada peticion
                // MessageBox.Show(response.StatusDescription);
                if (response.StatusCode == FtpStatusCode.ClosingData)
                {
                    Val = true;
                    // VEnvio = "2.32";
                }
            }
            catch (Exception ex)
            {
                Val = false;
            }
            return Val;
        }
        public  Ca_FTP UriFtp() {
            Ca_FTP Uri = new  Ca_FTP();
            try
            {
                using (ClusmextContext context = new ClusmextContext()) {
                    Uri = context.Ca_FTP.Where(x => x.Id_Ftp == 1).SingleOrDefault();
                }
            }
            catch (Exception ex) {
            }
            return Uri;
        }
    }
}
