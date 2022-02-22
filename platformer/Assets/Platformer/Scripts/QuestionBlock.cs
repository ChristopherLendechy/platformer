using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private float accumulatedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        float offset = 0.5f * Time.deltaTime;
        accumulatedTime += Time.deltaTime;
      
            mat.mainTextureOffset += new Vector2(0f, offset);

            mat.mainTextureScale = new Vector2(-1f, -0.2f);
         
    }
}
