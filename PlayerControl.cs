using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    public float speed;
    public GameObject dashesParent;
    public GameObject prevDash;

    private Rigidbody rb;
    private bool isMoving = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft) {
            rb.velocity = Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight) {
            rb.velocity = Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp) {
            rb.velocity = Vector3.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown) {
            rb.velocity = -Vector3.forward * speed * Time.deltaTime;
        }
    }
    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition= pos;

        Vector3 characterPos = transform.localPosition;
        characterPos.y += 0.047f;
        transform.localPosition = characterPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }
}
