using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    public UIManager _uiManager;
    //private UIManager _uiManager;
    void Start()
    {
        //StartCoroutine(UpdatePickingRayCast());
        //_uiManager = GameObject.Find("Text").GetComponent<UIManager>();
        //Debug.Log(_uiManager.uiText.text);
        _uiManager = gameObject.GetComponent<UIManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Working!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                BoxCollider boxC = hitInfo.collider as BoxCollider;
                if (boxC != null && boxC.tag.Equals("Brick"))
                {
                    Destroy(boxC.gameObject);
                    _uiManager.UpdateText("Brick",0);
                    
                }
                else if (boxC != null && boxC.tag.Equals("Question"))
                {
                    // Call points manager script and increment 
                    _uiManager.UpdateText("coin",0);
                }
            }
        }


    }
        
    

    // IEnumerator UpdatePickingRayCast()
    // {
    //     while (true)
    //     {
    //         // Debug.Log($"current frame number { Time.frameCount}");
    //         
    //             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //             if (Physics.Raycast(ray, out RaycastHit hitInfo))
    //             {
    //                 float l = 1f;
    //                 Debug.DrawLine(hitInfo.point + Vector3.left * l, hitInfo.point + Vector3.right * l, Color.red );
    //                 Debug.DrawLine(hitInfo.point + Vector3.up * l, hitInfo.point + Vector3.down * l, Color.red );
    //
    //
    //             }
    //         
    //         yield return null;
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
       // Destroy(this.gameObject);
    }


}

