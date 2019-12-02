using System;
using System.Runtime.InteropServices;

namespace CommonLibrary.Cls
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    [ComVisible(false)]
    public class AddCustomizeAttrs : Attribute
    {
        public override string ToString()
        {
            return "AddCustomizeAttrs";
        }
    }
}