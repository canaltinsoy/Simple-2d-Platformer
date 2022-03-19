using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D theRB;

    public float speed;
    public float jumpForce;

    public bool isGrounded;

    public int heartCount = 3;
    public int starCount = 0;

    public bool gameOver = false;

    public TMP_Text heartCountText;
    public TMP_Text starCountText;

    public TMP_Text timeText;

    public GameObject Retry;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (gameOver == false)
        {
            float xPos = Input.GetAxis("Horizontal") * speed;

            Vector3 movement = new Vector3(xPos, 0, 0);

            theRB.AddForce(movement);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                theRB.AddForce(Vector3.up * jumpForce);
                isGrounded = false;
            }
        }

        UpdateTheTimer();


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        if (other.gameObject.tag == "Obstacle")
        {
            heartCount--;
            heartCountText.text = "Heart: " + heartCount;
            Debug.Log("Obstacle");
            if (heartCount == 0)
            {
                gameOver = true;
                Retry.gameObject.SetActive(true);
                Player.gameObject.SetActive(false);
            }
        }
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Heart")
        {
            heartCount++;
            heartCountText.text = "Heart: " + heartCount;
            Debug.Log("Heart");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Star")
        {
            starCount++;
            starCountText.text = "Star: " + starCount;
            Debug.Log("Star");
            Destroy(other.gameObject);
        }

    }
    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(1);
    }
}
