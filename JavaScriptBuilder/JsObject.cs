using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaScriptBuilder.Expressions;

namespace JavaScriptBuilder
{
    /// <summary>
    /// Dummy class for lambda expressions.
    /// </summary>
    public abstract class JsObject
    {
        public abstract JsObject prototype { get; set; }

        public abstract JsObject this[JsObject index] { get; set; }

        public static implicit operator JsObject(string str) { return null; }

        public static implicit operator JsObject(int i) { return null; }

        public static implicit operator JsObject(double d) { return null; }

        public static implicit operator JsObject(Js js) { return null; }

        public static implicit operator string(JsObject obj) { return null; }

        public static implicit operator int(JsObject obj) { return default(int); }

        public static implicit operator double(JsObject obj) { return default(double); }

        public static implicit operator Js(JsObject obj) { return null; }

        public static JsObject operator +(JsObject a, JsObject b) { return null; }

        public static JsObject operator -(JsObject a, JsObject b) { return null; }

        public static JsObject operator *(JsObject a, JsObject b) { return null; }

        public static JsObject operator /(JsObject a, JsObject b) { return null; }


    }
}
