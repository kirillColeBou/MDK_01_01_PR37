﻿using Shop_Тепляков.Data.Models;
using System.Collections.Generic;


namespace Shop_Тепляков.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items item);
        public void Delete(int id);
        public void Update(Items Item, int categId);
    }
}
