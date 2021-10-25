using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUiHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject recipePanel;

    [SerializeField]
    private GameObject questionnairePanel;

    [SerializeField]
    private GameObject failedTaskPanel;

    [SerializeField]
    private CraftingRecipe recipe;

    

    private void Start()
    {
        showRecipe();
    }

    //enable and load the recipe panel
    public void showRecipe()
    {
        recipePanel.SetActive(true);
        List<Items> materials = recipe.materials;
        string materialsText = "";
        foreach (Items item in materials)
        {
            materialsText += item.itemAmountLabel + " " + item.itemName + "\n";
        }
        recipePanel.GetComponentInChildren<TextMeshProUGUI>().SetText(materialsText);
        GameObject.Find("RecipeTitle").GetComponent<Text>().text = recipe.name;
    }

    public void hideRecipe()
    {
        recipePanel.SetActive(false);
    }

    public void onCraftClick(CraftingRecipe recipe)
    {
        //enable the questionnaire panel
        bool canBeCrafted = recipe.CanCraft();

        if (canBeCrafted)
        {
            questionnairePanel.SetActive(true);
        }
        else
        {
            failedTaskPanel.SetActive(true);
        }
    }

    public void restartScene()
    {
        //reloads the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void goToNextScene()
    {
        Debug.Log("Next Level");
    }

    public void goToMenu()
    {
        Debug.Log("Go to Menu");
    }
}
