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
    [Range(1,9999)]
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

        //if the player didn't use all the items he need, he won't be able to craft
        if (BowlHandler.itemsUsed.Count != materials.Count)
        {
            Debug.Log(materials.ToString());
            return false;
        }else if (materials.Count == 0) //if there is no materials needed to craft return true;
        {
            
            return true;
        }

        //if the player used the wrong amounts of an item, the recipe won't be correct
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

}
