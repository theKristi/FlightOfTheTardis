using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour 
{
    public float spinSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0,0, spinSpeed) * Time.deltaTime);
    }
}
