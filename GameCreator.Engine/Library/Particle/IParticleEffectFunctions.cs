using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IParticleEffectFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 6.1
    //
    [Gml("effect_create_above", v61)]
    void EffectCreateAbove(int kind, double x, double y, double size, int color);

    [Gml("effect_create_below", v61)]
    void EffectCreateBelow(int kind, double x, double y, double size, int color);
}
