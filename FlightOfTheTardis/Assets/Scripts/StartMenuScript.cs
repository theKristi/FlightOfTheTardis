using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour 
{

    public void PlayClick()
    {
        Application.LoadLevel("TardisAsteroidsMain");
    }

    public void InstructionsClick()
    {
        Application.LoadLevel("Instructions");
    }
}
