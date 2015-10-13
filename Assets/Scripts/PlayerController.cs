using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float fullSpeed = 15.0f, focusSpeed = 5.0f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;

	public AudioClip fireSound;

	float xmin, xmax, ymin, ymax;

	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftdown = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightup = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

		xmin = leftdown.x;
		xmax = rightup.x;
        ymin = leftdown.y;
        ymax = rightup.y;

	}

	void Fire(){
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        beam.transform.parent = GameObject.Find("Projectiles").transform;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void Update () {
        float speed;

		if (Input.GetKeyDown (KeyCode.Z)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Z)){
			CancelInvoke("Fire");
		}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = focusSpeed;
        } else
        {
            speed = fullSpeed;
        }

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
		}else if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
		}	

	    // restrict the player to the gamespace
	    float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        float newY = Mathf.Clamp(transform.position.y, ymin, ymax);
	    transform.position = new Vector3(newX, newY, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die ();
			}
		}
	}

	void Die(){
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel ("Win Screen");
		Destroy (gameObject);
	}
}
