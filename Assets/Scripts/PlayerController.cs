using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {

    public LifeManager lifeManagerScript;

    public int playerSpeed = 4;
    public int jumpHeight = 800;
    public bool isGrounded = false;

    //public Camera cam;

    public GameController gameController;

    //Audio
    public AudioClip dragonGlass;
    public AudioClip hurtSound;
    new AudioSource audio;


    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }

    
    private void Update()
    {
        //Move Player
        if (Input.GetKey("right"))
        {
            transform.position -= Vector3.left * playerSpeed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);    //Change the position of the sprite
        }
        if (Input.GetKey("left"))
        {
            transform.position -= Vector3.right * playerSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);   //Change the position of the sprite
        }

        //Jump
        if (Input.GetKeyDown("space") && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpHeight, 0), ForceMode2D.Force);
        }
    }

    //Check if the player collides with the floor
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    //Check if the player stops colliding with the floor
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DragonGlass"))
        {
            audio.PlayOneShot(dragonGlass, 0.7F);

            gameController.CountDragonGlass();   //adds 1 to the count of dragon glass
            Destroy(collision.gameObject);   //destroys the dragon glass

            gameController.SetCountText();  //prints in the UI
        }

        if (collision.gameObject.CompareTag("LifeHeart"))
        {
            lifeManagerScript.GiveLife();
            Destroy(collision.gameObject);   //destroys the heart
        }
    }
}
