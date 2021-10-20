using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Items
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    [Range(1,999)]
    public float itemAmount;
    [SerializeField]
    public string itemAmountLabel;

    public Items(string itemName, float itemAmount, string itemAmountLabel)
    {
        this.itemName = itemName;
        this.itemAmount = itemAmount;
        this.itemAmountLabel = itemAmountLabel;
    }
}

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class CraftingRecipe : ScriptableObject
{
    [SerializeField]
    public List<Items> materials;

    public bool CanCraft() {
        bool flag = true;
        foreach(Items items in materials)
        {
            for(int i=0;i < BowlHandler.itemsUsed.Count; i++){
                if (items.itemName == BowlHandler.itemsUsed[i].itemName && items.itemAmount != BowlHandler.itemsUsed[i].itemAmount)
                {
                    flag = false;
                }
            }
        }
        return flag;
    }

    public void Craft()
    {
        if( CanCraft())
        {
            //show congratulations
        }
    }
}
