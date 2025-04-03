using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuManager menuManager;
    public GameObject menu;

    private void Start()
    {        
        menuManager = FindObjectOfType<MenuManager>(true); //checks scene
        
        if (menuManager == null)
        {
            Instantiate(menu);
            menuManager = menu.GetComponent<MenuManager>(); // unneccessary assignment
        }
    }
}