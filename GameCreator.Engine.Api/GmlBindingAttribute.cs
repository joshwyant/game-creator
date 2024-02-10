using System;

namespace GameCreator.Api.Engine
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