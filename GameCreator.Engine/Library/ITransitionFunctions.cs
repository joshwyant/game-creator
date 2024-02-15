using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ITransitionFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // 7.0
    //
    [Gml("transition_exists", v70)]
    void TransitionExists(int kind);

    [Gml("transition_define", v70)]
    void TransitionDefine(int kind, string name);
}
