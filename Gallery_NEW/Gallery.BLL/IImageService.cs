﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Gallery.BLL
{
    public interface IimageService
    {
       bool CompareBitmapsAsync(Bitmap bmp1, Bitmap bmp2);

       Task UploadImage(HttpPostedFileBase File);
    }
}