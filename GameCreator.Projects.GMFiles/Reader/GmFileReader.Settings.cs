using System.Collections.Generic;
using GameCreator.Api.Resources;

namespace GameCreator.Projects.GMFiles
{
    internal partial class GmFileReader
    {
        private void ReadSettings()
        {
            var version = ReadInt();

            var settings = Project.Settings;

            settings.StartInFullscreenMode = ReadBool();

            if (version >= 600)
                settings.InterpolateColors = ReadBool();

            settings.DrawWindowBorder = !ReadBool();
            settings.ShowCursor = ReadBool();

            if (version == 530)
            {
                var windowScaling = ReadInt();

                settings.WindowScalePercent = ReadInt();
                settings.FullscreenScalePercent = ReadInt();
                settings.ScalingWithHardwareSupportOnly = ReadBool();
            }
            else if (version >= 542)
            {
                var scaling = ReadInt();

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

                settings.WindowResizable = ReadBool();
                settings.WindowAlwaysOnTop = ReadBool();
                settings.ColorOutsiteRoom = ReadInt();
            }

            settings.SetScreenResolution = ReadBool();

            if (version == 530)
            {
                settings.ColorDepth = ReadInt() == 1 ? ColorDepth.ColorDepth32Bit : ColorDepth.ColorDepth16Bit;
                settings.ExclusiveGraphicsMode = ReadBool();
                settings.Resolution = (ScreenResolution)ReadInt();
                settings.Frequency = ReadInt();
                settings.WaitForVerticalBlankBeforeDrawing = ReadBool();
                settings.FullscreenDisplayCaption = ReadBool();
            }
            else if (version >= 542)
            {
                settings.ColorDepth = (ColorDepth)ReadInt();
                settings.Resolution = (ScreenResolution)ReadInt();
                settings.Frequency = ReadInt();
            }
            settings.WindowCaptionShowButtons = !ReadBool();
            if (version >= 542)
            {
                settings.Synchronization = ReadBool();
            }
            settings.EnableShortcutF4 = ReadBool();
            settings.EnableShortcutF1 = ReadBool();
            settings.EnableShortcutEsc = ReadBool();
            settings.EnableShortcutsF5AndF6 = ReadBool();
            settings.ProcessPriority = (ProcessPriority)ReadInt();

            if (version == 530)
            {
                Reader.ReadInt64(); // reserved
            }

            settings.FreezeGameWhenFormLosesFocus = ReadBool();
            settings.LoadingProgressBarMode = (LoadingProgressBarMode)ReadInt();

            if (settings.LoadingProgressBarMode == LoadingProgressBarMode.OwnLoadingProgressBar)
            {
                if (version >= 530 && version <= 702)
                {
                    if (ReadInt() != -1)
                    {
                        settings.LoadingBarBackgroundImageData = ReadZipped();
                    }

                    if (ReadInt() != -1)
                    {
                        settings.LoadingBarImageData = ReadZipped();
                    }
                }
            }

            settings.ShowLoadingImage = ReadBool();

            if (settings.ShowLoadingImage)
            {
                if (version >= 530 && version <= 702)
                {
                    if (ReadInt() != -1)
                    {
                        settings.LoadingImageData = ReadZipped();
                    }
                }
            }

            settings.LoadingImageTransparent = ReadInt();
            settings.LoadingImageAlpha = ReadInt();
            settings.ScaleLoadingBarImage = ReadBool();

            settings.IconData = ReadBlob();

            settings.DisplayErrorMessages = ReadBool();
            settings.UserErrorLog = ReadBool();
            settings.AbortOnError = ReadBool();
            settings.TreatUninitializedVariablesAs0 = ReadBool();
            settings.Author = ReadString();

            if (version >= 530 && version <= 600)
            {
                settings.Version = ReadInt();
            }

            settings.LastChangedDate = ReadDate();
            settings.Information = ReadString();

            settings.Constants = new Dictionary<string, string>();

            for (int count = ReadInt(), i = 0; i < count; i++)
                settings.Constants.Add(ReadString(), ReadString());

            if (version == 542 || version == 600)
            {
                settings.IncludeFiles = new List<string>();
                
                for (int count = ReadInt(), i = 0; i < count; i++)
                    settings.IncludeFiles.Add(ReadString());

                settings.SaveIncludeFilesToTempDirectory = ReadBool();
                settings.OverwriteIncludeFiles = ReadBool();
                settings.RemoveIncludeFiles = ReadBool();
            }
        }
    }
}
