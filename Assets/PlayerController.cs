using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text loseText;
    public GameObject bulletprefab;
    private int score;
    private int ammo;
    private int nextScene;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ammo = 10;
        SetCountText ();
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Movement

        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidBody = GetComponent<Rigidbody>();
        ourRigidBody.velocity = inputVector * speed;

        //Find new position
        // Vector3 newPosition = transform.position + inputVector;

        // transform.position = newPosition; //Move to new position

        //Face mouse
        // Generate a plane that intersects the transform's position with an upwards normal.
    	Plane playerPlane = new Plane(Vector3.up, transform.position);
 
    	// Generate a ray from the cursor position
    	Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
 
    	// Determine the point where the cursor ray intersects the plane.
    	// This will be the point that the object must look towards to be looking at the mouse.
    	// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
    	//   then find the point along that ray that meets that distance.  This will be the point
    	//   to look at.
    	float hitdist = 0.0f;
    	// If the ray is parallel to the plane, Raycast will return false.
    	if (playerPlane.Raycast (ray, out hitdist)) 
		{
        	// Get the point along the ray that hits the calculated distance.
        	Vector3 targetPoint = ray.GetPoint(hitdist);
 
        	// Determine the target rotation.  This is the rotation if the transform looks at the target point.
        	Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = targetRotation;
        	// Smoothly rotate towards the target point.
        	//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}

        //Fire Bullet
        if (Input.GetButtonDown("Fire1")){
            if (ammo >= 1){
                ammo -= 1;
                SetCountText ();
                Instantiate(bulletprefab, transform.position + transform.forward, transform.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Collect Item"))
        {
            other.gameObject.SetActive (false);
            score += 1;
            ammo += 2;
            SetCountText ();
        }

        if (score >= 20) {
            SceneManager.LoadScene(nextScene);
        }
    }

    private void OnCollisionEnter(Collision thiscollision) {
        GameObject theirGameObject = thiscollision.gameObject;
        if (theirGameObject.GetComponent<EnemyController>() != null) {
            gameObject.SetActive (false);
            SetLoseText();
        };
    }

    void SetCountText ()
    {
        countText.text = "Ammo: " + ammo.ToString();
    }

    void SetLoseText ()
    {
        loseText.text = "R to restart\nEscape to quit";
    }

}
