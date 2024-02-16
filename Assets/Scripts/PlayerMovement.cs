using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int maxhealth = 90;
    [SerializeField] private int thirdhealth = 60;
    [SerializeField] private int secondhealth = 30;
    [SerializeField] private int firsthealth = 0;

    [SerializeField] private float x = 0f;
    [SerializeField] private float y = 2.09f;
    [SerializeField] private float z = 49.25f;

    [SerializeField] private int currenthealth = 0;

    [SerializeField] private GameObject health1;
    [SerializeField] private GameObject health2;
    [SerializeField] private GameObject health3;

    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private string Damage = "Damage";
    private Rigidbody rb;
    private bool canJump = true;

    void Start()
    {
        currenthealth = maxhealth;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(hMovement, 0f, 0f);


        float vMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, vMovement);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }


    }
    private async void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Damage) && currenthealth == maxhealth)
        {
            health3.SetActive(false);
            currenthealth = thirdhealth;
            transform.position = new Vector3(x, y, z);
            await Task.Delay(2000);

        }
        if (collision.gameObject.CompareTag(Damage) && currenthealth == thirdhealth)
        {
            health2.SetActive(false);
            currenthealth = secondhealth;
            transform.position = new Vector3(x, y, z);
            await Task.Delay(2000);
        }
        if (collision.gameObject.CompareTag(Damage) && currenthealth == secondhealth)
        {
            health1.SetActive(false);
            currenthealth = firsthealth;
            transform.position = new Vector3(x, y, z);
            await Task.Delay(2000);

        }
        if (collision.gameObject.CompareTag(Damage) && currenthealth == firsthealth)
        {

            SceneManager.LoadScene(3);
        }

    }
}
