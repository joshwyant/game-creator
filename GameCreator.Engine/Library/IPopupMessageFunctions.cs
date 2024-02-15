using GameCreator.Api.Engine;
using static GameCreator.Api.Engine.GameMakerVersion;

namespace GameCreator.Engine.Library;

public interface IPopupMessageFunctions
{
    #region Deprecated Functions
    #endregion

    //
    // Introduced in v1.4
    //
    [Gml("show_message", v14)]
    void ShowMessage(string str);

    [Gml("show_question", v14)]
    void ShowQuestion(string str);

    [Gml("get_integer", v14)]
    double GetInteger(string str, double def);

    [Gml("get_string", v14)]
    string GetString(string str, string def);

}
