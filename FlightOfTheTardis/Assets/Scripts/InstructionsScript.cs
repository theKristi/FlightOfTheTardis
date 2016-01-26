using UnityEngine;
using System.Collections;

public class InstructionsScript : MonoBehaviour 
{
    public void PlayClick()
    {
        Application.LoadLevel("TardisAsteroidsMain");
    }

    public void BackClick()
    {
        Application.LoadLevel("StartMenu");
    }
	

}
