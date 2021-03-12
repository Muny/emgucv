﻿//----------------------------------------------------------------------------
//  Copyright (C) 2004-2021 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using System.Drawing;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Freetype;
using Emgu.Util;

namespace Emgu.CV.Models
{
    /// <summary>
    /// Freetype model using NotoSansCJK font
    /// </summary>
    public class FreetypeNotoSansCJK : Freetype2
    {
        private String _modelFolderName;

        /// <summary>
        /// Create a freetype model using NotoSansCJK font.
        /// </summary>
        /// <param name="modelFolderName">The subfolder name where the model will be saved to.</param>
        public FreetypeNotoSansCJK(String modelFolderName = "Freetype")
        : base()
        {
            _modelFolderName = modelFolderName;
        }

        /// <summary>
        /// Download and initialize the freetype object
        /// </summary>
        /// <param name="onDownloadProgressChanged">Callback when download progress has been changed</param>
        /// <returns>Async task</returns>
        public async Task Init(System.Net.DownloadProgressChangedEventHandler onDownloadProgressChanged = null)
        {
            
                FileDownloadManager manager = new FileDownloadManager();

                manager.AddFile(
                    "https://github.com/emgucv/emgucv/raw/4.4.0/Emgu.CV.Test/NotoSansCJK-Regular.ttc",
                    _modelFolderName,
                    "E3C629CB9F416E2E57CFDFEE7573D5CAC3A06A681C105EC081AB9707C1F147E8");

                manager.OnDownloadProgressChanged += onDownloadProgressChanged;
                await manager.Download();

                if (manager.AllFilesDownloaded)
                    LoadFontData(manager.Files[0].LocalFile, 0);
            
        }
    }
}