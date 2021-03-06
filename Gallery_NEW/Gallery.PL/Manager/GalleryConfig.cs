﻿using System;
using System.Configuration;

namespace Gallery.PL.Manager
{
    public static class GalleryConfig
    {
        public static string key_pathForSave { get; } = "PathForSave";
        public static string key_tempPath { get; } = "TempPath";
        public static string key_imageTypes { get; } = "SupportedPhotoFormat";
        public static string key_messageQueuePath { get; } = "MessageQueuePath";

        private const string default_pathForSave = "/Images/Upload/";
        private const string default_tempPath = "/Temp";
        private const string default_imageTypes = "image/jpeg; image/png";

        public static string GetPathForSave()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var path = default_pathForSave;
            if (!string.IsNullOrEmpty(appSettings[key_pathForSave]))
            {
                 path = appSettings[key_pathForSave];
            }
            return path;
        }

        public static string GetTempPath()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var path = default_tempPath;
            if (!string.IsNullOrEmpty(appSettings[key_tempPath]))
            {
                path = appSettings[key_tempPath];
            }
            return path;
        }

        public static string GetImageTypes()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var imageTypes = default_imageTypes;
            if (!string.IsNullOrEmpty(appSettings[key_imageTypes]))
            {
                imageTypes = appSettings[key_pathForSave];
            }
            return imageTypes;
        }

        public static string GetDbConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sql"] ?? throw new ArgumentException("SQL");
            return connectionString.ConnectionString;
        }

        public static string GetMessageQueuePath()
        {
            var appSettings = ConfigurationManager.AppSettings;
            return appSettings[key_messageQueuePath] ?? throw new ArgumentNullException(nameof(appSettings));
        }
    }
}