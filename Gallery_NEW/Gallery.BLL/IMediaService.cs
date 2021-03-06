﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.BLL.Contracts;

namespace Gallery.BLL
{
    public interface IMediaService
    {
       bool CompareBitmapsAsync(Bitmap bmp1, Bitmap bmp2);

       Task<bool> UploadImageAsync(byte[] data, string path, int userId);

       Task<bool> UploadTempImageAsync(byte[] data, string path, TempMediaDTO tempMediaDto);

       Task<bool> DeleteMediaAsync(string path);

       ExifDTO GetExifData(string tempPath);

       Task MoveTempImageToUserDirectoryAsync(MessageDTO messageDto);
    }
}
