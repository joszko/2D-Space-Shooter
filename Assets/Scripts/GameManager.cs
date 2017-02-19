using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Cancel"))
            Application.Quit();
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
