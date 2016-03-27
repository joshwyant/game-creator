using GameCreator.Engine.Api;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine.Library
{
    public interface IStringFunctions
    {
        [Gml("chr")]
        string Chr(int val);
        
        [Gml("ansi_char")]
        string AnsiChar(int val);
        
        [Gml("ord")]
        int Ord(string str);
        
        [Gml("real")]
        double Real(Variant val);
        
        [Gml("string")]
        string String(Variant val);
        
        [Gml("string_format")]
        string StringFormat(Variant val, int total, int dec);
        
        [Gml("string_length")]
        int StringLength(string val);
        
        [Gml("string_byte_length")]
        int StringByteLength(string val);
        
        [Gml("string_pos")]
        int StringPos(string substring, string str);
        
        [Gml("string_copy")]
        string StringCopy(string str, int index, int count);
        
        [Gml("string_char_at")]
        string StringCharAt(string str, int index);
        
        [Gml("string_byte_at")]
        string StringByteAt(string str, int index);
        
        [Gml("string_delete")]
        string StringDelete(string str, int index, int count);
        
        [Gml("string_insert")]
        string StringInsert(string substr, string str, int index);
        
        [Gml("string_replace")]
        string StringReplace(string str, string substr, string newstr);
        
        [Gml("string_replace_all")]
        string StringReplaceAll(string str, string substr, string newstr);
        
        [Gml("string_count")]
        int StringCount(string substr, string str);
        
        [Gml("string_lower")]
        string StringLower(string str);
        
        [Gml("string_upper")]
        string StringUpper(string str);
        
        [Gml("string_repeat")]
        string StringRepeat(string str, int count);
        
        [Gml("string_letters")]
        string StringLetters(string str);
        
        [Gml("string_digits")]
        string StringDigits(string str);
        
        [Gml("string_lettersdigits")]
        string StringLettersDigits(string str);
        
        [Gml("clipboard_has_text")]
        bool ClipboardHasText();
        
        [Gml("clipboard_get_text")]
        string ClipboardGetText();
        
        [Gml("clipboard_set_text")]
        void ClipboardSetText();
    }
}