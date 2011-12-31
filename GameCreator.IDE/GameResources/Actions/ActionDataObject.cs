using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCreator.IDE
{
    class ActionDataObject : System.Windows.Forms.IDataObject
    {
        ActionDeclaration a;
        public ActionDataObject(ActionDeclaration data)
        {
            a = data;
        }

        #region IDataObject Members

        public object GetData(Type format)
        {
            return format == typeof(ActionDeclaration) ? a : null;
        }

        public object GetData(string format)
        {
            return format == "GameCreatorAction" || format == typeof(ActionDeclaration).FullName ? a : null;
        }

        public object GetData(string format, bool autoConvert)
        {
            return format == "GameCreatorAction" || format == typeof(ActionDeclaration).FullName ? a : null;
        }

        public bool GetDataPresent(Type format)
        {
            return format == typeof(ActionDeclaration);
        }

        public bool GetDataPresent(string format)
        {
            return format == "GameCreatorAction" || format == typeof(ActionDeclaration).FullName;
        }

        public bool GetDataPresent(string format, bool autoConvert)
        {
            return format == "GameCreatorAction" || format == typeof(ActionDeclaration).FullName;
        }

        public string[] GetFormats()
        {
            return new string[] { "GameCreatorAction", typeof(ActionDeclaration).FullName };
        }

        public string[] GetFormats(bool autoConvert)
        {
            return new string[] { "GameCreatorAction", typeof(ActionDeclaration).FullName };
        }

        public void SetData(object data)
        {
            a = (ActionDeclaration)data;
        }

        public void SetData(Type format, object data)
        {
            a = (ActionDeclaration)data;
        }

        public void SetData(string format, object data)
        {
            a = (ActionDeclaration)data;
        }

        public void SetData(string format, bool autoConvert, object data)
        {
            a = (ActionDeclaration)data;
        }

        #endregion
    }
}
