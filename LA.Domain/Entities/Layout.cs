using System;

namespace LA.Domain
{
    public class Layout: IEntity
    {
        public string Content { get; set; }
        public bool Default { get; set; }
    }
}
