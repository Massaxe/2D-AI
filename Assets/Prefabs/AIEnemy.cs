using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour {
    public Rigidbody2D bullet;
    public float bulletSpeed = 10;
    public bool Fired;
    public float fireRate = 1;
    public Transform player;
    public Vector2 startingPos;
    public bool moveLeft;
    public bool moveRight;
    Rigidbody2D selfR;
    public float walkDistance;
    // Use this for initialization
    void Start () {
        selfR = GetComponent<Rigidbody2D>();



    }
    void Awake()
    {
        startingPos = transform.position;
        moveLeft = true;
        moveRight = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveRight)
        {
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
            if (Vector2.Distance(transform.position, startingPos) > walkDistance)
            {
                moveRight = false;
                moveLeft = true;
            }
        }
        if (moveLeft)
        {
            transform.Translate(Vector2.left * 5 * Time.deltaTime);
            if (Vector2.Distance(transform.position, startingPos) > walkDistance)
            {
                moveRight = true;
                moveLeft = false;
            }
        }
        //transform.Translate(new Vector2(0.00003f, 0));
        print(Vector2.Distance(transform.position, startingPos));

	
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


//Vector2.Distance(transform.position, startingPos) > leftDistance