using System;

namespace GameCreator.Runtime.Api
{
    public interface IGmlBinder
    {
        SymbolTable SymbolTable { get; }
        void BindGml<T>();
        void BindGml(Type t);
    }
}