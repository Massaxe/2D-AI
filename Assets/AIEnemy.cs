using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed = 10;

    public Transform player;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
           // Debug.DrawRay(transform.position, player.position - transform.position);
            RaycastHit2D rhit2d = Physics2D.Raycast(transform.position, player.position - transform.position, Mathf.Infinity);
            if (rhit2d.collider.tag == "Player")
            {
                var clone = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
                clone.AddForce(player.position - transform.position * bulletSpeed * Time.deltaTime);
            }
        }
    }
}
