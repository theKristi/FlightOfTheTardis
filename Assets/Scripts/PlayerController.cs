using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class PlayerController : MonoBehaviour {
    AudioSource audio;
    public float spinSpeed;
    public float speed;
    private Rigidbody rb;
    public Image healthBar;
    GameController gameController;
    public float damage;
     float healthPercent;
    public Boundary boundary;
    public GameObject playerExplosion;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        healthPercent = 100.0f;
        UpdateHealth();
        gameController=GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rb.velocity = movement * speed;
        rb.position=new Vector3(
                       Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                       Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
                       0.0f);
        //rb.rotation = Quaternion.Euler(0.0f,spinSpeed *Time.deltaTime, rb.velocity.x * -tilt);

    }
	


	void Update () 
    {
        transform.Rotate(new Vector3(0,spinSpeed , 0)*Time.deltaTime);
	
	}

    void UpdateHealth()
    {
        healthBar.fillAmount = healthPercent/100.0f;
    }
    void CalculateHealth(float toChange)
    {     
/*Debug.Log("Before Change Health: " + healthPercent + "%");
  Debug.Log("amount to Change: "+toChange);*/
        healthPercent += toChange;
//Debug.Log(" After Change Health: "+healthPercent+"%");
        UpdateHealth();
        if (healthPercent <= 0)
        {
            Destroy(gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
       
    }
    void OnCollisionEnter( Collision collision)
    {
        if ((collision.gameObject.name).Contains("asteroid"))
        {
            CalculateHealth(-damage);
            audio.Play();

        }
        if ((collision.gameObject.name).Contains("Warp"))
            Debug.Log("WarpCollision!");

    }
    void onTriggerEnter(Collider c)
    { 
        Debug.Log("triggerCollision");
    }
}
