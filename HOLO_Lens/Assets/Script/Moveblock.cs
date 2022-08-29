using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveblock : MonoBehaviour
{
    [SerializeField] GameObject PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, 0, 4.5f);
    }
}
