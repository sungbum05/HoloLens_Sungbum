using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 1.0f, Camera.main.transform.position.z);
    }
}
