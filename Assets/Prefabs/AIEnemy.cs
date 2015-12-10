using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {
    public Rigidbody2D bullet;
    public float bulletSpeed = 10;
    public bool Fired;
    public float fireRate = 1;
    public Transform player;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector2(0.00003f, 0));

	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (!Fired)
            {
                StartCoroutine(FireRate());
            }

        }
    }
    void Fire()
    {
        Debug.DrawRay(transform.position, player.position - transform.position);
        RaycastHit2D rhit2d = Physics2D.Raycast(transform.position, player.position - transform.position, Mathf.Infinity);
        if (rhit2d.collider.tag == "Player")
        {
            var clone = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
            var vel = player.position - transform.position;
            vel.Normalize();
            vel *= bulletSpeed;
            clone.velocity = vel;
        }
    }
    IEnumerator FireRate()
    {
        Fire();
        Fired = true;
        yield return new WaitForSeconds(fireRate);
        Fired = false;
    }
}
