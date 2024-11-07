using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace 通用订票.Application.System.QRHelper
{
    public class QRHelper
    {
        private readonly static object lockkey1 = new object();
        /// <summary>
        /// 生成二维码 返回路径
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static string CreateQRcode(string link, string filename = null)
        {

            //var url = ConfigurationManager.AppSettings["Url"];
            string path = "bitmap/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = null;
            if (filename == null)
            {
                var time = DateTime.Now.ToFileTime();
                filePath = path + time + ".png";
                filename = time.ToString();
            }
            else
            {
                filePath = path + filename + ".png";
            }

            if (File.Exists(filePath))
            {
                return path + filename + ".png";
            }

            using (Bitmap bmp = GetDimensionalCode(link))
            {
                lock (lockkey1)
                {
                    bmp.Save(filePath);
                }
                return "/" + path + filename + ".png";
            }
        }

        private static Bitmap GetDimensionalCode(string link)
        {
            Bitmap bmp = null;
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 8;
                //int version = Convert.ToInt16(cboVersion.Text);
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                bmp = qrCodeEncoder.Encode(link);
            }
            catch (Exception ex)
            {

            }
            return bmp;
        }
    }
}
