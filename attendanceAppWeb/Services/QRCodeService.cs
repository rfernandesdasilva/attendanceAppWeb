using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing.QrCode;
using ZXing;

// professor will create QR codes for students to read. this functionality will generate the random guid that will be used as
// base for the QR code. When the professor clicks to display the QR code, the image of it will be generated;

// this method will only do the work and return values.

// i can store the QRCode in the DB by saving in as binary data.

// method that creates random Guid
// method that generates QRcode
// method that turns QRCode as binary data
// Method that reads binary data into QR code

namespace attendanceAppWeb.Services
{
	public class QRCodeService
	{
		public string GenerateRandomId()
		{
			return Guid.NewGuid().ToString();
		}

        // we generate a QRCode but we are converting as a bit array. 
        

        // we transform the byteArray back to image to be able to display to the classRoom.
        public Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}

