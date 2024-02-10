using System.Collections.Generic;
using GameCreator.Api.Resources;

namespace GameCreator.Projects
{
    public class ProjectResourceManager<T> : IndexedResourceManager<T> where T : IIndexedResource, new()
    {
        private readonly SortedDictionary<int, ResourceLeafNode<T>> _nodesMap 
            = new SortedDictionary<int, ResourceLeafNode<T>>();
        
        public ResourceDirectoryNode<T> Root { get; }
        
        public string NamePrefix { get; }
        
        public ProjectResourceManager(string namePrefix, int startingIndex = 0) : base(startingIndex)
        {
            Root = new ResourceDirectoryNode<T>();
            NamePrefix = namePrefix;
        }

        public ProjectResourceManager(T[] initialItems, string namePrefix, int startingIndex = 0) : base(initialItems, startingIndex)
        {
            Root = new ResourceDirectoryNode<T>(initialItems);
            NamePrefix = namePrefix;
        }

        public string GenerateDefaultName()
        {
            return NamePrefix + NextIndex;
        }
        
        public override int Add(T obj)
        {
            return AddNode(obj).Value.Id;
        }

        public T Create()
        {
            return CreateNode().Value;
        }

        public ResourceLeafNode<T> GetNode(T value)
        {
            return GetNode(value.Id);
        }

        public ResourceLeafNode<T> GetNode(int id)
        {
            return _nodesMap[id];
        }

        public ResourceLeafNode<T> CreateNode()
        {
            return AddNode(new T());
        }

        public ResourceLeafNode<T> AddNode(T value)
        {
            base.Add(value);
            var node = new ResourceLeafNode<T>(value);
            _nodesMap.Add(value.Id, node);
            Root.Add(node);
            return node;
        }

        public override void Remove(int id)
        {
            var node = _nodesMap[id];
            node.Remove();
            _nodesMap.Remove(id);
            base.Remove(id);
        }

        public void Remove(ResourceLeafNode<T> node)
        {
            Remove(node.Value.Id);
        }

        public ResourceDirectoryNode<T> AddDirectoryNode(string name)
        {
            var node = new ResourceDirectoryNode<T>(name);
            Root.Add(node);
            return node;
        }
    }
}