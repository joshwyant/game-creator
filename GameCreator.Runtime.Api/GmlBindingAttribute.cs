using System;

namespace GameCreator.Runtime.Api
{
    public class GmlBindingAttribute : Attribute
    {
        public GmlBindingOption Option { get; }
        
        public GmlBindingAttribute(GmlBindingOption option)
        {
            Option = option;
        }
    }
}