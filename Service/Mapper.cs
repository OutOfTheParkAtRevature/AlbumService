using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Mapper
    {
        public byte[] ConvertImage(string image)
        {
            //take everything after the ,
            string base64Image1 = image.Split(',')[1];
            byte[] bytes = Convert.FromBase64String(base64Image1);
            return bytes;
        }

        private string ConvertByteArrayToJpgString(byte[] byteArray)
        {
            if (byteArray != null)
            {
                string imageBase64Data = Convert.ToBase64String(byteArray, 0, byteArray.Length);
                string imageDataURL = string.Format($"data:image/jpg;base64,{imageBase64Data}");
                return imageDataURL;
            }
            else return null;
        }
    }
}
