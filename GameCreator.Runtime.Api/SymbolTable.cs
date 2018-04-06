using System;
using System.Collections.Generic;
using System.Linq;
using GameCreator.Resources.Api;

namespace GameCreator.Runtime.Api
{
    public class SymbolTable : IResourceTable
    {
        private Dictionary<string, List<INamedResource>> resources;
        private Dictionary<string, Variant> builtinConstants;
        private Dictionary<string, Variant> constants;
        
        public SymbolTable()
        {
            resources = new Dictionary<string, List<INamedResource>>();
            builtinConstants = new Dictionary<string, Variant>();
            constants = new Dictionary<string, Variant>();
        }

        public INamedResource OfType<T>(string name) where T : INamedResource
        {
            if (!resources.TryGetValue(name, out var list))
            {
                return null;
            }
            return list.OfType<T>().FirstOrDefault();
        }

        public void RegisterResource(INamedResource resource)
        {
            if (!resources.TryGetValue(resource.Name, out var list))
            {
                resources.Add(resource.Name, new List<INamedResource>());
            }
            
            list.Add(resource);
        }

        public void RemoveResource<T>(T resource) where T : INamedResource
        {
            if (resources.TryGetValue(resource.Name, out var list))
            {
                var indexOf = list.FindIndex(r => r.Id == resource.Id && r is T);
                list.RemoveAt(indexOf);
            }
        }

        public void RegisterBuiltInConstant(string name, Variant value)
        {
            builtinConstants[name] = value;
        }

        public void RegisterUserConstant(string name, Variant value)
        {
            constants[name] = value;
        }

        public Variant GetNamedValue(string name)
        {
            if (resources.ContainsKey(name))
            {
                return resources[name].First().Id;
            }
            else if (builtinConstants.ContainsKey(name))
            {
                return builtinConstants[name];
            }
            else if (constants.ContainsKey(name))
            {
                return constants[name];
            }

            return default(Variant);
        }
    }
}