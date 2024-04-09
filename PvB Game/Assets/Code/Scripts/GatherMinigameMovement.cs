using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GatherMinigameMovement : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckRadius = 0.1f;

    private bool isGrounded = false;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;

    private ItemCollectionManager itemCollectionManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        itemCollectionManager = FindObjectOfType<ItemCollectionManager>();
    }

    void Update()
    {
        string playerNumber = gameObject.name.Replace("Player", "");

        int playerIndex = 0;

        Vector3 movement = Vector3.zero;

        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer).Length > 0;

        if (Input.GetKey(GetKeyCodeWithPrefix(upKey, playerIndex)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKey(GetKeyCodeWithPrefix(leftKey, playerIndex)))
        {
            movement += Vector3.back;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(GetKeyCodeWithPrefix(rightKey, playerIndex)))
        {
            movement += Vector3.forward;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (movement != Vector3.zero)
        {
            movement.Normalize();
        }

        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed);
    }

    KeyCode GetKeyCodeWithPrefix(KeyCode key, int playerIndex)
    {
        return (KeyCode)((int)key + playerIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            string playerNumber = gameObject.name.Replace("Player", "");
            string playerName = "Player" + playerNumber;
            itemCollectionManager.CollectItem(playerName);
        }
    }
}
