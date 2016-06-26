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
            int version = getInt();

            var settings = project.Settings;

            settings.StartInFullscreenMode = getBool();

            if (version >= 600)
                settings.InterpolateColors = getBool();

            settings.DrawWindowBorder = !getBool();
            settings.ShowCursor = getBool();

            if (version == 530)
            {
                var windowScaling = getInt();

                settings.WindowScalePercent = getInt();
                settings.FullscreenScalePercent = getInt();
                settings.ScalingWithHardwareSupportOnly = getBool();
            }
            else if (version >= 542)
            {
                var scaling = getInt();

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

                settings.WindowResizable = getBool();
                settings.WindowAlwaysOnTop = getBool();
                settings.ColorOutsiteRoom = getInt();
            }

            settings.SetScreenResolution = getBool();

            if (version == 530)
            {
                settings.ColorDepth = getInt() == 1 ? ColorDepth.ColorDepth32Bit : ColorDepth.ColorDepth16Bit;
                settings.ExclusiveGraphicsMode = getBool();
                settings.Resolution = (ScreenResolution)getInt();
                settings.Frequency = getInt();
                settings.WaitForVerticalBlankBeforeDrawing = getBool();
                settings.FullscreenDisplayCaption = getBool();
            }
            else if (version >= 542)
            {
                settings.ColorDepth = (ColorDepth)getInt();
                settings.Resolution = (ScreenResolution)getInt();
                settings.Frequency = getInt();
            }
            settings.WindowCaptionShowButtons = !getBool();
            if (version >= 542)
            {
                settings.Synchronization = getBool();
            }
            settings.EnableShortcutF4 = getBool();
            settings.EnableShortcutF1 = getBool();
            settings.EnableShortcutEsc = getBool();
            settings.EnableShortcutsF5AndF6 = getBool();
            settings.ProcessPriority = (ProcessPriority)getInt();

            if (version == 530)
            {
                reader.ReadInt64(); // reserved
            }

            settings.FreezeGameWhenFormLosesFocus = getBool();
            settings.LoadingProgressBarMode = (LoadingProgressBarMode)getInt();

            if (settings.LoadingProgressBarMode == LoadingProgressBarMode.OwnLoadingProgressBar)
            {
                if (version >= 530 && version <= 702)
                {
                    if (getInt() != -1)
                    {
                        settings.LoadingBarBackgroundImageData = getZipped();
                    }

                    if (getInt() != -1)
                    {
                        settings.LoadingBarImageData = getZipped();
                    }
                }
            }

            settings.ShowLoadingImage = getBool();

            if (settings.ShowLoadingImage)
            {
                if (version >= 530 && version <= 702)
                {
                    if (getInt() != -1)
                    {
                        settings.LoadingImageData = getZipped();
                    }
                }
            }

            settings.LoadingImageTransparent = getInt();
            settings.LoadingImageAlpha = getInt();
            settings.ScaleLoadingBarImage = getBool();

            settings.IconData = getBlob();

            settings.DisplayErrorMessages = getBool();
            settings.UserErrorLog = getBool();
            settings.AbortOnError = getBool();
            settings.TreatUninitializedVariablesAs0 = getBool();
            settings.Author = getString();

            if (version >= 530 && version <= 600)
            {
                settings.Version = getInt();
            }

            settings.LastChangedDate = getDate();
            settings.Information = getString();

            settings.Constants = new Dictionary<string, string>();

            for (int count = getInt(), i = 0; i < count; i++)
                settings.Constants.Add(getString(), getString());

            if (version == 542 || version == 600)
            {
                settings.IncludeFiles = new List<string>();
                
                for (int count = getInt(), i = 0; i < count; i++)
                    settings.IncludeFiles.Add(getString());

                settings.SaveIncludeFilesToTempDirectory = getBool();
                settings.OverwriteIncludeFiles = getBool();
                settings.RemoveIncludeFiles = getBool();
            }
        }
    }
}
