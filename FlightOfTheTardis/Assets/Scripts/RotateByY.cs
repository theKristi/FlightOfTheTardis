using UnityEngine;
using System.Collections;

public class RotateByY : MonoBehaviour {

    float spinSpeed = 120;
	// Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0) * Time.deltaTime);

    }
}
