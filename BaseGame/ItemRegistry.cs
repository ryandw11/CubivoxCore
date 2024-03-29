﻿using System.Collections.Generic;

namespace CubivoxCore.BaseGame
{
    public interface ItemRegistry
    {
        void RegisterItem(Item item);
        void UnregisterItem(Item item);
        List<Item> GetItems();
        Item GetItem(ControllerKey key);
        VoxelDef GetVoxelDefinition(ControllerKey key);
    }
}
