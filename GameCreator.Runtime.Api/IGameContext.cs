using System;
using GameCreator.Resources.Api;

namespace GameCreator.Runtime.Api
{
    public interface IGameContext
    {
        IIndexedResourceManager<IInstance> Instances { get; }
        IInstance CurrentInstance { get; set; }
        IInstance OtherInstance { get; set; }
        void ReportError(string msg);
        void With(IInstance self);
        void With(int objectOrInstanceId);
        IVariableList Globals { get; }
        bool ArgumentRelative { get; set; }
        IIndexedResource GetResourceByName(string name);
        Variant ExecuteFunction(string name, params Variant[] args);
        Func<Variant, Variant[]> GetFunctionByName(string name);
    }
}