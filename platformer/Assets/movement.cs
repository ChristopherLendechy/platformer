using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float runForce = 50f;
    
   
    public float jumpSustainForce = 7f;
    public float maxHorizontalSpeed = 6f;
    
    //public float maxRunSpeed = 6f;
    public float jumpForce = 20f;
    public bool feetInContactWithGround = false;
    private Rigidbody body;
    private Collider collider;

    private Animator animComp;
    public float speedCap;

    public float proximityThreshold = 10f;
    public UIManager _uiManager;
    
    void Start()
    {
        
        speedCap = maxHorizontalSpeed;
        collider = GetComponent<Collider>();
        animComp = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        
        
    }

    IEnumerator UpdatePickingRaycast()
    {
        while (true)
        {
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        Bounds bounds = GetComponent<Collider>().bounds;
        feetInContactWithGround = Physics.Raycast(transform.position, Vector3.down,  collider.bounds.extents.y + 0.1f);
        
        var axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            maxHorizontalSpeed += 3;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            maxHorizontalSpeed = speedCap;
        }

        if (Input.GetKeyDown(KeyCode.Space) && feetInContactWithGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animComp.SetBool("Jumping", true);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
        }
        else if (feetInContactWithGround == true)
        {
            animComp.SetBool("Jumping", false);
        }

        float xVelocity = Mathf.Clamp(body.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

        if (Mathf.Abs(axis) < 0.1f)
        {
            xVelocity *= 0.9f;
        }

        body.velocity = new Vector3(xVelocity, body.velocity.y, body.velocity.z);
        
        animComp.SetFloat("Speed", body.velocity.magnitude);


    }

    private void OnCollisionExit(Collision other)
    {
        Ray ray = new Ray(transform.position, Vector3.up);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, proximityThreshold))
        {
            Debug.DrawRay(transform.position,Vector3.up * proximityThreshold, Color.red);
            BoxCollider boxC = hitInfo.collider as BoxCollider;
            if (boxC != null && boxC.tag.Equals("Brick"))
            {
                Destroy(boxC.gameObject);
                _uiManager.UpdateText("score",0);
                    
            }
            else if (boxC != null && boxC.tag.Equals("Question"))
            {
                // Call points manager script and increment 
                _uiManager.UpdateText("coin",0);
            }
        }
    }
}
