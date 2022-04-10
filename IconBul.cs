using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace offcloud
{
    public static class IconBul
    {
        private const string OpenFolderKey = "OpenFolderKey";
        private const string CloseFolderKey = "OpenFolderKey";
        private static ImageList instance;

        public static ImageList GetSharedInstance()
        {
            if (instance == null)
            {
                instance = new ImageList
                {
                    TransparentColor = Color.Transparent,
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(16, 16)
                };
            }
            return instance;
        }

        public static int GetImageIndexByExtention(string ext)
        {
            GetSharedInstance();
            ext = ext.ToLower();
            if (!instance.Images.ContainsKey(ext))
            {
                Icon iconForFile = IconReader.GetFileIconByExt(ext, IconReader.EnumIconSize.Small, false);
                ext = ext == "" ? "boş" : ext;
                instance.Images.Add(ext, iconForFile);
            }
            return instance.Images.IndexOfKey(ext);
        }

        public static int GetImageIndexFromFolder(bool open)
        {
            string key;
            GetSharedInstance();
            if (open)
                key = OpenFolderKey;
            else
                key = CloseFolderKey;
            if (!instance.Images.ContainsKey(key))
            {
                Icon iconForFile = IconReader.GetFolderIcon(IconReader.EnumIconSize.Small, (open ? IconReader.EnumFolderType.Open : IconReader.EnumFolderType.Closed));
                instance.Images.Add(key, iconForFile);
            }
            return instance.Images.IndexOfKey(key);
        }
    }

    internal class IconReader
    {
        [Flags]
        private enum EnumFileInfoFlags : uint
        {
            LARGEICON = 0x0,
            SMALLICON = 0x1,
            OPENICON = 0x2,
            SHELLICONSIZE = 0x4,
            PIDL = 0x8,
            USEFILEATTRIBUTES = 0x10,
            ADDOVERLAYS = 0x20,
            OVERLAYINDEX = 0x40,
            ICON = 0x100,
            DISPLAYNAME = 0x200,
            TYPENAME = 0x400,
            ATTRIBUTES = 0x800,
            ICONLOCATION = 0x1000,
            EXETYPE = 0x2000,
            SYSICONINDEX = 0x4000,
            LINKOVERLAY = 0x8000,
            SELECTED = 0x10000,
            ATTR_SPECIFIED = 0x20000
        }

        private const int conMAX_PATH = 260;
        private const uint conFILE_ATTRIBUTE_DIRECTORY = 0x10;
        private const uint conFILE_ATTRIBUTE_NORMAL = 0x80;

        public enum EnumIconSize
        {
            Large = 0,
            Small = 1
        }

        public enum EnumFolderType
        {
            Open = 0,
            Closed = 1
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct ShellFileInfo
        {
            public const int conNameSize = 80;
            public IntPtr hIcon;
            public int iIndex;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = conMAX_PATH)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = conNameSize)]
            public string szTypeName;
        }

        [DllImport("User32.dll")]
        private extern static int DestroyIcon(IntPtr hIcon);

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        private extern static IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref ShellFileInfo psfi, uint cbFileInfo, uint uFlags);

        public static Icon GetFileIcon(string filePath, EnumIconSize size, bool addLinkOverlay)
        {
            EnumFileInfoFlags flags = EnumFileInfoFlags.ICON;
            if (addLinkOverlay)
                flags = flags | EnumFileInfoFlags.LINKOVERLAY;
            if (size == EnumIconSize.Small)
                flags = flags | EnumFileInfoFlags.SMALLICON;
            else
                flags = flags | EnumFileInfoFlags.LARGEICON;
            ShellFileInfo shellFileInfo = new ShellFileInfo();
            SHGetFileInfo(filePath, conFILE_ATTRIBUTE_NORMAL, ref shellFileInfo, Convert.ToUInt32(Marshal.SizeOf(shellFileInfo)), Convert.ToUInt32(flags));
            Icon icon = (Icon)Icon.FromHandle(shellFileInfo.hIcon).Clone();
            DestroyIcon(shellFileInfo.hIcon);
            return icon;
        }

        public static Icon GetFileIconByExt(string fileExt, EnumIconSize size, bool addLinkOverlay)
        {
            string tempFile = Path.GetTempPath() + Guid.NewGuid().ToString("N") + fileExt;
            try
            {
                File.WriteAllBytes(tempFile, new byte[1] { 0 });

                return GetFileIcon(tempFile, size, addLinkOverlay);
            }
            finally
            {
                try
                {
                    File.Delete(tempFile);
                }
                catch (Exception)
                {
                }
            }
        }

        public static Icon GetFolderIcon(EnumIconSize size, EnumFolderType folderType)
        {
            return GetFolderIcon(null, size, folderType);
        }

        public static Icon GetFolderIcon(string folderPath, EnumIconSize size, EnumFolderType folderType)
        {
            EnumFileInfoFlags flags = EnumFileInfoFlags.ICON | EnumFileInfoFlags.USEFILEATTRIBUTES;
            if (folderType == EnumFolderType.Open)
                flags = flags | EnumFileInfoFlags.OPENICON;
            if (EnumIconSize.Small == size)
                flags = flags | EnumFileInfoFlags.SMALLICON;
            else
                flags = flags | EnumFileInfoFlags.LARGEICON;
            ShellFileInfo shellFileInfo = new ShellFileInfo();
            SHGetFileInfo(folderPath, conFILE_ATTRIBUTE_DIRECTORY, ref shellFileInfo, Convert.ToUInt32(Marshal.SizeOf(shellFileInfo)), Convert.ToUInt32(flags));
            Icon icon = (Icon)Icon.FromHandle(shellFileInfo.hIcon).Clone();
            DestroyIcon(shellFileInfo.hIcon);
            return icon;
        }
    }
}
