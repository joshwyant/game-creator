using System.Collections.Generic;
using System.Linq;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public class ResourceDirectoryNode<T> : ResourceNode<T> where T : IIndexedResource
    {
        public string Name { get; set; }
        public ResourceNode<T> FirstChild { get; internal set; }
        public ResourceNode<T> LastChild { get; internal set; }

        internal ResourceDirectoryNode(string name = "")
        {
            Name = name;
        }
        
        internal ResourceDirectoryNode(IEnumerable<T> initialItems, string name = "")
        {
            Name = name;
            AddRange(initialItems);
        }
        
        public override IEnumerator<T> GetEnumerator()
        {
            return Nodes.SelectMany(node => node).GetEnumerator();
        }

        public IEnumerable<ResourceNode<T>> Nodes
        {
            get
            {
                var current = FirstChild;
                while (current != null)
                {
                    yield return current;
                    current = current.Next;
                }
            }
        }

        internal void Insert(ResourceNode<T> item)
        {
            item.Parent = this;
            if (LastChild == null)
            {
                FirstChild = LastChild = item;
            }
            else
            {
                FirstChild.Previous = item;
                item.Next = FirstChild;
                FirstChild = item;
            }
        }

        internal void Add(ResourceNode<T> item)
        {
            item.Parent = this;
            if (FirstChild == null)
            {
                FirstChild = LastChild = item;
            }
            else
            {
                LastChild.Next = item;
                item.Previous = LastChild;
                LastChild = item;
            }
        }

        internal void Add(T item)
        {
            Add(new ResourceLeafNode<T>(item));
        }

        internal void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(new ResourceLeafNode<T>(item));
            }
        }

        internal void Insert(T item)
        {
            Insert(new ResourceLeafNode<T>(item));
        }

        internal void Clear()
        {
            FirstChild = LastChild = null;
        }

        public bool Contains(T item)
        {
            return this.Any(t => t.Id == item.Id);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var t in this)
            {
                if (arrayIndex >= array.Length) break;
                array[arrayIndex++] = t;
            }
        }

        internal bool Remove(T item)
        {
            foreach (var node in Nodes)
            {
                switch (node)
                {
                    case ResourceLeafNode<T> leaf:
                        if (leaf.Value.Id == item.Id)
                        {
                            leaf.Remove();
                            return true;
                        }
                        break;
                    case ResourceDirectoryNode<T> dir:
                        if (dir.Remove(item))
                        {
                            return true;
                        }
                        break;
                }
            }
            return false;
        }

        public int Count => this.Count();
        public bool IsReadOnly => false;
    }
}