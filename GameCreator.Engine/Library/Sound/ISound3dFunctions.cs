using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ISound3dFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.0
    //
    [Gml("sound_3d_set_sound_cone", v60)]
    void Sound3dSetSoundCone(int snd, double x, double y, double z, double anglein, double angleout, double voloutside);

    [Gml("sound_3d_set_sound_distance", v60)]
    void Sound3dSetSoundDistance(int snd, double mindist, double maxdist);

    [Gml("sound_3d_set_sound_velocity", v60)]
    void Sound3dSetSoundVelocity(int snd, double x, double y, double z);

    [Gml("sound_3d_set_sound_position", v60)]
    void Sound3dSetSoundPosition(int snd, double x, double y, double z);
}
