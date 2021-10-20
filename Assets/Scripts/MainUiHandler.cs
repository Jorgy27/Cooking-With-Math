using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUiHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject recipePanel;
    
    public void showRecipe(CraftingRecipe recipe)
    {
        recipePanel.SetActive(true);
        List<Items> materials = recipe.materials;
        string materialsText = "";
        foreach (Items item in materials)
        {
            materialsText += item.itemAmountLabel + " " + item.itemName + "\n";
        }
        recipePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(materialsText);
    }

    public void hideRecipe()
    {
        recipePanel.SetActive(false);
    }
}
