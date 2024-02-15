using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;
public interface IMoveFunctions
{
    #region Deprecated Functions
    [Gml("move_random", v11, v33)]
    void MoveRandom(int obj);
    #endregion
}