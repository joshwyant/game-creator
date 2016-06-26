using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace GameCreator.Projects
{
    partial class GmFileProjectReader
    {
        void readSettings()
        {
            int version = reader.ReadInt32();

            var settings = project.Settings;

            settings.StartInFullscreenMode = Convert.ToBoolean(reader.ReadInt32());

            if (version >= 600)
                settings.InterpolateColors = Convert.ToBoolean(reader.ReadInt32());

            settings.DrawWindowBorder = !Convert.ToBoolean(reader.ReadInt32());
            settings.ShowCursor = Convert.ToBoolean(reader.ReadInt32());

            if (version == 530)
            {
                var windowScaling = reader.ReadInt32();

                settings.WindowScalePercent = reader.ReadInt32();
                settings.FullscreenScalePercent = reader.ReadInt32();
                settings.ScalingWithHardwareSupportOnly = Convert.ToBoolean(reader.ReadInt32());
            }
            else if (version >= 542)
            {
                var scaling = reader.ReadInt32();

                switch (scaling)
                {
                    case -1:
                        settings.ScalingMode = ScalingMode.AspectRatio;
                        break;
                    case 0:
                        settings.ScalingMode = ScalingMode.FullScale;
                        break;
                    default:
                        settings.ScalingMode = ScalingMode.FixedScale;
                        settings.Scaling = scaling;
                        break;
                }

                settings.WindowResizable = Convert.ToBoolean(reader.ReadInt32());
                settings.WindowAlwaysOnTop = Convert.ToBoolean(reader.ReadInt32());
                settings.ColorOutsiteRoom = reader.ReadInt32();
            }

            settings.SetScreenResolution = Convert.ToBoolean(reader.ReadInt32());

            if (version == 530)
            {
                settings.ColorDepth = reader.ReadInt32() == 1 ? ColorDepth.ColorDepth32Bit : ColorDepth.ColorDepth16Bit;
                settings.ExclusiveGraphicsMode = Convert.ToBoolean(reader.ReadInt32());
                settings.Resolution = (ScreenResolution)reader.ReadInt32();
                settings.Frequency = reader.ReadInt32();
                settings.WaitForVerticalBlankBeforeDrawing = Convert.ToBoolean(reader.ReadInt32());
                settings.FullscreenDisplayCaption = Convert.ToBoolean(reader.ReadInt32());
            }
            else if (version >= 542)
            {
                settings.ColorDepth = (ColorDepth)reader.ReadInt32();
                settings.Resolution = (ScreenResolution)reader.ReadInt32();
                settings.Frequency = reader.ReadInt32();
            }
            settings.WindowCaptionShowButtons = !Convert.ToBoolean(reader.ReadInt32());
            if (version >= 542)
            {
                settings.Synchronization = Convert.ToBoolean(reader.ReadInt32());
            }
            settings.EnableShortcutF4 = Convert.ToBoolean(reader.ReadInt32());
            settings.EnableShortcutF1 = Convert.ToBoolean(reader.ReadInt32());
            settings.EnableShortcutEsc = Convert.ToBoolean(reader.ReadInt32());
            settings.EnableShortcutsF5AndF6 = Convert.ToBoolean(reader.ReadInt32());
            settings.ProcessPriority = (ProcessPriority)reader.ReadInt32();

            if (version == 530)
            {
                reader.ReadInt64(); // reserved
            }

            settings.FreezeGameWhenFormLosesFocus = Convert.ToBoolean(reader.ReadInt32());
            settings.LoadingProgressBarMode = (LoadingProgressBarMode)reader.ReadInt32();

            if (settings.LoadingProgressBarMode == LoadingProgressBarMode.OwnLoadingProgressBar)
            {
                if (version >= 530 && version <= 702)
                {
                    if (reader.ReadInt32() != -1)
                    {
                        var inData = new byte[reader.ReadInt32()];
                        reader.Read(inData, 0, inData.Length);
                        settings.LoadingBarBackgroundImageData = deflate(inData);
                    }

                    if (reader.ReadInt32() != -1)
                    {
                        var inData = new byte[reader.ReadInt32()];
                        reader.Read(inData, 0, inData.Length);
                        settings.LoadingBarImageData = deflate(inData);
                    }
                }
            }

            settings.ShowLoadingImage = Convert.ToBoolean(reader.ReadInt32());

            if (settings.ShowLoadingImage)
            {
                if (version >= 530 && version <= 702)
                {
                    if (reader.ReadInt32() != -1)
                    {
                        var inData = new byte[reader.ReadInt32()];
                        reader.Read(inData, 0, inData.Length);
                        settings.LoadingImageData = deflate(inData);
                    }
                }
            }

            settings.LoadingImageTransparent = reader.ReadInt32();
            settings.LoadingImageAlpha = reader.ReadInt32();
            settings.ScaleLoadingBarImage = Convert.ToBoolean(reader.ReadInt32());

            settings.IconData = new byte[reader.ReadInt32()];
            reader.Read(settings.IconData, 0, settings.IconData.Length);

            settings.DisplayErrorMessages = Convert.ToBoolean(reader.ReadInt32());
            settings.UserErrorLog = Convert.ToBoolean(reader.ReadInt32());
            settings.AbortOnError = Convert.ToBoolean(reader.ReadInt32());
            settings.TreatUninitializedVariablesAs0 = Convert.ToBoolean(reader.ReadInt32());
            settings.Author = readString();

            if (version >= 530 && version <= 600)
            {
                settings.Version = reader.ReadInt32();
            }

            settings.LastChangedDate = reader.ReadDouble().ToDateTime();
            settings.Information = readString();

            settings.Constants = new Dictionary<string, string>();

            for (int count = reader.ReadInt32(), i = 0; i < count; i++)
                settings.Constants.Add(readString(), readString());

            if (version == 542 || version == 600)
            {
                settings.IncludeFiles = new List<string>();
                
                for (int count = reader.ReadInt32(), i = 0; i < count; i++)
                    settings.IncludeFiles.Add(readString());

                settings.SaveIncludeFilesToTempDirectory = Convert.ToBoolean(reader.ReadInt32());
                settings.OverwriteIncludeFiles = Convert.ToBoolean(reader.ReadInt32());
                settings.RemoveIncludeFiles = Convert.ToBoolean(reader.ReadInt32());
            }
        }
    }
}
