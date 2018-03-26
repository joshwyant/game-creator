using System.Collections;
using System.Collections.Generic;
using GameCreator.Resources.Api;

namespace GameCreator.Projects
{
    public abstract class ResourceNode<T> : IEnumerable<T> where T : IIndexedResource
    {
        public ResourceDirectoryNode<T> Parent { get; internal set; }
        public ResourceNode<T> Previous { get; internal set; }
        public ResourceNode<T> Next { get; internal set; }

        internal ResourceNode()
        {
            
        }
        
        public abstract IEnumerator<T> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal void Remove()
        {
            if (Parent == null)
            {
                return;
            }

            if (Previous == null)
            {
                Parent.FirstChild = Next;
            }
            else
            {
                Previous.Next = Next;
            }

            if (Next == null)
            {
                Parent.LastChild = Previous;
            }
            if (Next != null)
            {
                Next.Previous = Previous;
            }
        }

        public void AddTo(ResourceDirectoryNode<T> n)
        {
            Remove();
            n.Add(this);
        }

        public void InsertAfter(ResourceNode<T> n)
        {
            Remove();
            if (n.Next == null)
            {
                n.Parent.Add(this);
            }
            else
            {
                Parent = n.Parent;
                Previous = n;
                Next = n.Next;
                n.Next.Previous = this;
                n.Next = this;
            }
        }

        public void InsertBefore(ResourceNode<T> n)
        {
            Remove();
            if (n.Previous == null)
            {
                n.Parent.Insert(this);
            }
            else
            {
                Parent = n.Parent;
                Next = n;
                Previous = n.Previous;
                n.Previous.Next = this;
                n.Previous = this;
            }
        }
    }
}