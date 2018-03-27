using System;
using GameCreator.Runtime.Api;

namespace GameCreator.Engine.Library
{
    public class StringFunctions : IStringFunctions
    {
        public GameContext Context { get; }

        public StringFunctions(GameContext context)
        {
            Context = context;
        }
        
        public string Chr(int val) => throw new NotImplementedException();
        
        public string AnsiChar(int val) => throw new NotImplementedException();
        
        public int Ord(string str) => throw new NotImplementedException();
        
        public double Real(Variant val) => throw new NotImplementedException();
        
        public string String(Variant val) => throw new NotImplementedException();
        
        public string StringFormat(Variant val, int total, int dec) => throw new NotImplementedException();
        
        public int StringLength(string val) => throw new NotImplementedException();
        
        public int StringByteLength(string val) => throw new NotImplementedException();
        
        public int StringPos(string substring, string str) => throw new NotImplementedException();
        
        public string StringCopy(string str, int index, int count) => throw new NotImplementedException();
        
        public string StringCharAt(string str, int index) => throw new NotImplementedException();
        
        public string StringByteAt(string str, int index) => throw new NotImplementedException();
        
        public string StringDelete(string str, int index, int count) => throw new NotImplementedException();
        
        public string StringInsert(string substr, string str, int index) => throw new NotImplementedException();
        
        public string StringReplace(string str, string substr, string newstr) => throw new NotImplementedException();
        
        public string StringReplaceAll(string str, string substr, string newstr) => throw new NotImplementedException();
        
        public int StringCount(string substr, string str) => throw new NotImplementedException();

        public string StringLower(string str) => throw new NotImplementedException();
        
        public string StringUpper(string str) => throw new NotImplementedException();
        
        public string StringRepeat(string str, int count) => throw new NotImplementedException();
        
        public string StringLetters(string str) => throw new NotImplementedException();
        
        public string StringDigits(string str) => throw new NotImplementedException();
        
        public string StringLettersDigits(string str) => throw new NotImplementedException();
        
        public bool ClipboardHasText() => throw new NotImplementedException();
        
        public string ClipboardGetText() => throw new NotImplementedException();
        
        public void ClipboardSetText() => throw new NotImplementedException();
    }
}