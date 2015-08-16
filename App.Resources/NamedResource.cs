using App.Contracts;

namespace App.Resources
{
    public abstract class NamedResource : INamedIndexedResource
    {
        /// <summary>
        /// The default prefix for the name.
        /// </summary>
        public abstract string DefaultPrefix { get; }

        #region INamedIndexedResource members
        public int Index { get; set; }

        private string _name;
        /// <summary>
        /// Returns the name of the resource, or a default name if it's not set.
        /// </summary>
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                    _name = DefaultPrefix + Index.ToString();

                return _name;
            }

            set
            {
                _name = value;
            }
        }
        #endregion
    }
}
