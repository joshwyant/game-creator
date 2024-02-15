using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IInstanceFunctions
{
    #region Deprecated Functions
    [Gml("create", v11, v33)]
    void Create(double x, double y, int obj);

    [Gml("change", v11, v33)]
    void Change(int obj1, int obj2);

    [Gml("change_at", v11, v33)]
    void ChangeAt(double x, double y, int obj);

    [Gml("destroy", v11, v33)]
    void Destroy(int obj);

    [Gml("destroy_at", v11, v33)]
    void DestroyAt(double x, double y);
    
    [Gml("number", v11, v33)]
    int Number(int obj);
    #endregion

}
