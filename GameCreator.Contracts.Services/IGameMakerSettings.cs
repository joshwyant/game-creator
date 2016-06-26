using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.Contracts.Services
{
    public interface IGameMakerSettings
    {
        byte[] LoadingBarBackgroundImageData { get; set; }
        ColorDepth ColorDepth { get; set; }
        int ColorOutsiteRoom { get; set; }
        Guid DirectPlayGuid { get; set; }
        bool DrawWindowBorder { get; set; }
        bool EnableShortcutEsc { get; set; }
        bool EnableShortcutF1 { get; set; }
        bool EnableShortcutF4 { get; set; }
        bool EnableShortcutsF5AndF6 { get; set; }
        bool ExclusiveGraphicsMode { get; set; }
        bool FreezeGameWhenFormLosesFocus { get; set; }
        int Frequency { get; set; }
        bool FullscreenDisplayCaption { get; set; }
        int FullscreenScalePercent { get; set; }
        int GameID { get; set; }
        bool InterpolateColors { get; set; }
        byte[] LoadingBarImageData { get; set; }
        LoadingProgressBarMode LoadingProgressBarMode { get; set; }
        ProcessPriority ProcessPriority { get; set; }
        ScreenResolution Resolution { get; set; }
        int Scaling { get; set; }
        ScalingMode ScalingMode { get; set; }
        bool ScalingWithHardwareSupportOnly { get; set; }
        bool SetScreenResolution { get; set; }
        bool ShowCursor { get; set; }
        bool StartInFullscreenMode { get; set; }
        bool Synchronization { get; set; }
        bool WaitForVerticalBlankBeforeDrawing { get; set; }
        bool WindowAlwaysOnTop { get; set; }
        bool WindowCaptionShowButtons { get; set; }
        bool WindowResizable { get; set; }
        int WindowScalePercent { get; set; }
        bool ShowLoadingImage { get; set; }
        byte[] LoadingImageData { get; set; }
        int LoadingImageTransparent { get; set; }
        string Author { get; set; }
        bool TreatUninitializedVariablesAs0 { get; set; }
        bool AbortOnError { get; set; }
        bool UserErrorLog { get; set; }
        bool DisplayErrorMessages { get; set; }
        byte[] IconData { get; set; }
        bool ScaleLoadingBarImage { get; set; }
        int LoadingImageAlpha { get; set; }
        int Version { get; set; }
        DateTime LastChangedDate { get; set; }
        string Information { get; set; }
        Dictionary<string, string> Constants { get; set; }
        List<string> IncludeFiles { get; set; }
        bool SaveIncludeFilesToTempDirectory { get; set; }
        bool OverwriteIncludeFiles { get; set; }
        bool RemoveIncludeFiles { get; set; }
    }
}
