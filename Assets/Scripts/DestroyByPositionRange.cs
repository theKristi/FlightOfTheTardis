using UnityEngine;
using System.Collections;

public class DestroyByPositionRange : MonoBehaviour 
{
    public  float xMin,xMax,yMin,yMax,zMin, zMax;

    void Update()
    {
        if (transform.position.z < zMin || transform.position.z > zMax || transform.position.y < yMin || transform.position.y > yMax || transform.position.x < xMin || transform.position.x > xMax)
        {
            Destroy(gameObject);
        }
    }
}
