using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ISoundCDFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduce in v4.3c
    //
    [Gml("cd_init", v43c)]
    void CdInit();

    [Gml("cd_present", v43c)]
    bool CdPresent();

    [Gml("cd_number", v43c)]
    int CdNumber();

    [Gml("cd_playing", v43c)]
    bool CdPlaying();

    [Gml("cd_paused", v43c)]
    bool CdPaused();

    [Gml("cd_track", v43c)]
    int CdTrack();

    [Gml("cd_track_length", v43c)]
    int CdTrackLength(int n);

    [Gml("cd_position", v43c)]
    int CdPosition();

    [Gml("cd_set_position", v43c)]
    void CdSetPosition(int pos);

    [Gml("cd_play", v43c)]
    void CdPlay(int first, int last);

    [Gml("cd_stop", v43c)]
    void CdStop();

    [Gml("cd_pause", v43c)]
    void CdPause();

    [Gml("cd_resume", v43c)]
    void CdResume();

    [Gml("cd_set_track_position", v43c)]
    void CdSetTrackPosition(int pos);

    [Gml("cd_open_door", v43c)]
    void CdOpenDoor();

    [Gml("cd_close_door", v43c)]
    void CdCloseDoor();

    //
    // Introduced in v5.0
    //
    [Gml("MCI_command", v50)]
    void MCICommand(string str);
}
