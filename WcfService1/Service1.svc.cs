using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using tessnet2;
using System.Drawing;
using System.IO;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string convert(byte[] arr)
        {

            string solving = "";
            List<string> res = new List<string>();
            string[] array;

            Bitmap bmp;
            using (var ms = new MemoryStream(arr)) { bmp = new Bitmap(ms); }
            var ocr = new Tesseract();
            ocr.Init(@"E:\ocrwebservice\WindowsFormsApplication1\WcfService1\Content\tessdata", "eng", false);
            var result = ocr.DoOCR(bmp, Rectangle.Empty);
            foreach (tessnet2.Word word in result)
            {
                res.Add(word.Text);
            }
            array = res.ToArray();
            solving = string.Join(".", array);


            return solving;

        }

    }
}
