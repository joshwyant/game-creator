using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using GameCreator.Runtime.Api;

namespace GameCreator.Runtime.Binder
{
    public class GmlBinder : IGmlBinder
    {
        public GmlBinder(SymbolTable symbolTable)
        {
            SymbolTable = symbolTable;
        }
        
        public SymbolTable SymbolTable { get; }
        
        public void BindGml<T>()
        {
            BindGml(typeof(T));
        }
        
        HashSet<Type> _boundTypes = new HashSet<Type>();

        public InstanceTypeBinder<T> ForInstanceType<T>()
            where T : IInstance
        {
            return new InstanceTypeBinder<T>(this);
        }
        
        public ContextTypeBinder<T> ForContextType<T>()
            where T : IGameContext
        {
            return new ContextTypeBinder<T>(this);
        }

        public virtual void BindGml(Type t)
        {
            if (_boundTypes.Contains(t))
                return;
            _boundTypes.Add(t);

            for (var b = t.BaseType; b != null; b = b.BaseType)
            {
                BindGml(b);
            }
            
            foreach (var i in t.GetInterfaces())
            {
                BindGml(i);
            }
            
            var instanceType = typeof(IInstance).IsAssignableFrom(t);
            var contextType = typeof(IGameContext).IsAssignableFrom(t);
            var libraryType = typeof(IGameLibrary).IsAssignableFrom(t);
            
            // A symbol, function, etc. may have more than one name mapped, so return them all.
            void ForGmlNames(MemberInfo member, Action<string> action)
            {
                foreach (GmlAttribute attr in member.GetCustomAttributes(typeof(GmlAttribute), false))
                {
                    var name = string.IsNullOrEmpty(attr.Name) ? member.Name : attr.Name;
                    action(name);
                }
            }
            
            if (t.IsEnum)
            {
                var values = t.GetEnumValues().Cast<Variant>().ToArray();
                var names = t.GetEnumNames();
                for (var i = 0; i < names.Length; i++)
                {
                    ForGmlNames(t.GetMember(names[i])[0], name =>
                        SymbolTable.RegisterBuiltInConstant(name, values[i]));
                }
            }
            else
            {
                foreach (var field in t.GetFields())
                {
                    if (field.IsLiteral)
                    {
                        ForGmlNames(field, name =>
                            SymbolTable.RegisterBuiltInConstant(name, new Variant(field.GetRawConstantValue())));
                    }
                    else if (field.IsStatic)
                    {
                        // global variable
                    }
                    else if (contextType)
                    {
                        // global variable on context
                    }
                    else if (libraryType)
                    {
                        // global variable on library
                    }
                    else if (instanceType)
                    {
                        
                    }
                }
            }
        }
    }
}