using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    class ResourceViewDataObject : System.Windows.Forms.IDataObject
    {
        IResourceView res;
        string format;
        public ResourceViewDataObject(string fmt, IResourceView data)
        {
            format = fmt;
            res = data;
        }

        #region IDataObject Members

        public object GetData(Type format)
        {
            return format == typeof(IResourceView) ? res : null;
        }

        public object GetData(string format)
        {
            return format == this.format || format == typeof(IResourceView).FullName ? res : null;
        }

        public object GetData(string format, bool autoConvert)
        {
            return format == this.format || format == typeof(IResourceView).FullName ? res : null;
        }

        public bool GetDataPresent(Type format)
        {
            return format == typeof(IResourceView);
        }

        public bool GetDataPresent(string format)
        {
            return format == this.format || format == typeof(IResourceView).FullName;
        }

        public bool GetDataPresent(string format, bool autoConvert)
        {
            return format == this.format || format == typeof(IResourceView).FullName;
        }

        public string[] GetFormats()
        {
            return new string[] { format, typeof(IResourceView).FullName };
        }

        public string[] GetFormats(bool autoConvert)
        {
            return new string[] { format, typeof(IResourceView).FullName };
        }

        public void SetData(object data)
        {
            res = (IResourceView)data;
        }

        public void SetData(Type format, object data)
        {
            res = (IResourceView)data;
        }

        public void SetData(string format, object data)
        {
            res = (IResourceView)data;
        }

        public void SetData(string format, bool autoConvert, object data)
        {
            res = (IResourceView)data;
        }

        #endregion
    }
}
