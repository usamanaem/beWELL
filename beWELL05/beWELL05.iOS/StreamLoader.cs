﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace beWELL05.iOS
{
    class StreamLoader : IStreamLoader
    {
        public Stream GetStreamForFilename(string filename)
        {
            return File.OpenRead(filename);
        }
    }
}