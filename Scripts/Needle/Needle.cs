using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Needle : MonoBehaviour
{
    [SerializeField]
    private float throwForce = 40f;

    [SerializeField]
    private Transform needleNumberTransform;

    private bool canBeThrown = true;

    // Cached references.
    private Rigidbody2D myRigidbody;
    private PolygonCollider2D myBoxCollider;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        // TODO change input for smartphone.
        if (Input.GetMouseButtonDown(0) && canBeThrown)
        {
            var throwVector = new Vector2(0, throwForce);
            myRigidbody.AddForce(throwVector, ForceMode2D.Impulse);

            // TODO decrement number of knives.
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level01");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameManager.Instance.GetCookieColliderTag()))
        {
            if (canBeThrown)
            {
                canBeThrown = false;
            }
            else
            {
                return;
            }

            // If continued is because it hit the lof for the first time.
            // Make needle be stuck to the cookie's outline.
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.isKinematic = true;
            transform.SetParent(other.transform);

            // Adjust needle number to face camera.
            needleNumberTransform.localEulerAngles = new Vector3(
                needleNumberTransform.localEulerAngles.x,
                180, needleNumberTransform.localEulerAngles.z);
            
            // TODO tirar collider polygon e colocar box para checkar colisão com needle.
        }
    }
}
