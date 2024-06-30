using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float jumpMultiplier = 100f;

    [SerializeField]
    private float minPower = 1;
    [SerializeField]
    private float maxPower = 10;
    [SerializeField]
    Vector2 jumpDirection = new Vector2(1, 2);

    //public Rigidbody2D head;
    Rigidbody2D rb;
    float power;
    bool ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int xDir = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        if (xDir != 0)
        {
            jumpDirection.x = xDir;
        }

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            if (power < maxPower)
            {
                power += Time.deltaTime * jumpMultiplier;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && ground)
        {
            rb.AddForce(jumpDirection.normalized * power);
            power = minPower;
        }

        //if (head != null)
        //{
        //    head.AddForce(Vector2.up * 0.1f);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) { ground = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) { ground = false; }
    }
}
