﻿using Business.Constants.Base;

namespace Business.Constants
{
    public class ImageConstants : BaseConstants
    {
        public static readonly string[] ImageExtension = { ".jpeg", ".jpg", ".png", ".gif", ".pdf", ".bmp", ".docx", ".doc", ".tiff" };
        public const string DataStatusUnchanged = "Data status unchanged.";
        public const string DataStatusChanged = "Data status Changed.";
        public const string FileDeleted = "File Deleted.";
        public const string IsDeleted = "File Not Found.";
        public const string InvalidFileSize = "Invalid file size.";
    }
}