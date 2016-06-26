using GameCreator.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCreator.Contracts.Services
{
    public class GmSettings : IGameMakerSettings
    {
        public byte[] LoadingBarBackgroundImageData { get; set; }
        public ColorDepth ColorDepth { get; set; }
        public int ColorOutsiteRoom { get; set; }
        public Guid DirectPlayGuid { get; set; }
        public bool DrawWindowBorder { get; set; }
        public bool EnableShortcutEsc { get; set; }
        public bool EnableShortcutF1 { get; set; }
        public bool EnableShortcutF4 { get; set; }
        public bool EnableShortcutsF5AndF6 { get; set; }
        public bool ExclusiveGraphicsMode { get; set; }
        public bool FreezeGameWhenFormLosesFocus { get; set; }
        public int Frequency { get; set; }
        public bool FullscreenDisplayCaption { get; set; }
        public int FullscreenScalePercent { get; set; }
        public int GameID { get; set; }
        public bool InterpolateColors { get; set; }
        public byte[] LoadingBarImageData { get; set; }
        public LoadingProgressBarMode LoadingProgressBarMode { get; set; }
        public ProcessPriority ProcessPriority { get; set; }
        public ScreenResolution Resolution { get; set; }
        public int Scaling { get; set; }
        public ScalingMode ScalingMode { get; set; }
        public bool ScalingWithHardwareSupportOnly { get; set; }
        public bool SetScreenResolution { get; set; }
        public bool ShowCursor { get; set; }
        public bool StartInFullscreenMode { get; set; }
        public bool Synchronization { get; set; }
        public bool WaitForVerticalBlankBeforeDrawing { get; set; }
        public bool WindowAlwaysOnTop { get; set; }
        public bool WindowCaptionShowButtons { get; set; }
        public bool WindowResizable { get; set; }
        public int WindowScalePercent { get; set; }
        public bool ShowLoadingImage { get; set; }
        public byte[] LoadingImageData { get; set; }
        public int LoadingImageTransparent { get; set; }
        public string Author { get; set; }
        public bool TreatUninitializedVariablesAs0 { get; set; }
        public bool AbortOnError { get; set; }
        public bool UserErrorLog { get; set; }
        public bool DisplayErrorMessages { get; set; }
        public byte[] IconData { get; set; }
        public bool ScaleLoadingBarImage { get; set; }
        public int LoadingImageAlpha { get; set; }
        public int Version { get; set; }
        public DateTime LastChangedDate { get; set; }
        public string Information { get; set; }
        public Dictionary<string, string> Constants { get; set; }
        public List<string> IncludeFiles { get; set; }
        public bool SaveIncludeFilesToTempDirectory { get; set; }
        public bool OverwriteIncludeFiles { get; set; }
        public bool RemoveIncludeFiles { get; set; }
    }
}
