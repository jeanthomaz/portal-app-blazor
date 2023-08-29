using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace APIPortal.Entidades
{
    public class Apresentação
    {
        public readonly Guid Id;
        public readonly string Title;
        public readonly string Description;
        public readonly string Body;
        public readonly List<Url> References; 

       
    }
}
