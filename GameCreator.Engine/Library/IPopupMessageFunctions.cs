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

    //
    // Introduced in v4.0
    //

    [Gml("get_open_filename", v40)]
    string GetOpenFilename(string filter, string fname);

    [Gml("get_save_filename", v40)]
    string GetSaveFilename(string filter, string fname);

    [Gml("get_directory", v40)]
    string GetDirectory(string dname);

    [Gml("get_color", v40)]
    double GetColor(double defcolor);
    
    [Gml("show_menu", v40)]
    void ShowMenu(string str, double def);

}
