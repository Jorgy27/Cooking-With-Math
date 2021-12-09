using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void openScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        BowlHandler.itemsUsed = new List<Items>(); //reset the list so it doesn't hold any used items
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
