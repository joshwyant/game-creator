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

    //
    // Introduced in v4.3c
    // 
    [Gml("get_directory_alt", v43c)]
    string GetDirectoryAlt(string capt, string root);
    
    [Gml("show_message_ext", v43c)]
    void ShowMessageExt(string str, string but1, string but2, string but3);

    [Gml("message_background", v43c)]
    void MessageBackground(string back);

    [Gml("message_button", v43c)]
    void MessageButton(string spr);

    [Gml("message_text_font", v43c)]
    void MessageTextFont(string name, int size, int color, int style);

    [Gml("message_button_font", v43c)]
    void MessageButtonFont(string name, int size, int color, int style);

    [Gml("message_input_font", v43c)]
    void MessageInputFont(string name, int size, int color, int style);

    [Gml("message_mouse_color", v43c)]
    void MessageMouseColor(int col);

    [Gml("message_input_color", v43c)]
    void MessageInputColor(int col);

    [Gml("message_caption", v43c)]
    void MessageCaption(bool show, string str);

    [Gml("message_position", v43c)]
    void MessagePosition(int x, int y);

    [Gml("show_error", v43c)]
    void ShowError(string str, bool abort);

}
