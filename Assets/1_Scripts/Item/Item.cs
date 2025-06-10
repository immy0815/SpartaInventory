using System;

[Serializable]
public class Item
{
    public ItemData itemData;
    public bool isEquipped;

    public Item(ItemData data)
    {
        itemData = data;
        isEquipped = false;
    }
}