using System;

namespace GameCreator.Engine.Api
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