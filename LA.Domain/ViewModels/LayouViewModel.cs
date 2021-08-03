using System;
using System.Collections.Generic;

namespace LA.Domain
{
    public class LayoutItem
    {
        public int w { get; set; }
        public int h { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string i { get; set; }
        public bool moved { get; set; }
    }

    public class LayoutViewModel
    {
        //public List<LayoutItem> Items { get; set; }
        public long ID { get; set; }
        public string Content { get; set; }
    }
}
