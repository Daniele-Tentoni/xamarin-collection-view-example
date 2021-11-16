using System;
using System.Collections.Generic;

namespace HeadedCollectionView.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class ItemGroup : List<Item>
    {
        public string Name { get; private set; }
        public ItemGroup(string name, IEnumerable<Item> items) : base(items)
        {
            this.Name = name;
        }
    }

    public enum OrderByType
    {
        Id, Text, Description
    }
}
