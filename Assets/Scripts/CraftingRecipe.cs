using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    [Range(1,999)]
    private float itemAmount;
    [SerializeField]
    private string itemAmountLabel;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    [SerializeField]
    private List<ItemAmount> Materials;

    public bool CanCraft(/*get Items given*/) {
        foreach(ItemAmount itemAmount in Materials)
        {
            //check if amount of items given equals to the amount required
        }
        return true;
    }

    public void Craft()
    {
        if( CanCraft(/* items given*/))
        {
            //show congratulations
        }
    }
}
