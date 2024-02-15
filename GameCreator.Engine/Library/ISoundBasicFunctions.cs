using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface ISoundBasicFunctions
{
    #region Deprecated Functions
    [Gml("sound", v11, v14)]
    void Sound(int numb);
    #endregion

}
