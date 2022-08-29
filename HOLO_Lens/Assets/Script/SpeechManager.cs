using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManager : MonoBehaviour
{
    public GameObject FireBall;
    public GameObject ThunderBolt;

    public GameObject PlayerCamera;
    public float BallSpeed;

    public void SpawnFireBall()
    {
        GameObject Magic = Instantiate(FireBall, PlayerCamera.transform.position, PlayerCamera.transform.rotation);
        Magic.GetComponent<Rigidbody>().velocity = Magic.transform.forward * BallSpeed;
    }

    public void SpawnThunderBolt()
    {
        GameObject Magic = Instantiate(ThunderBolt, PlayerCamera.transform.position, PlayerCamera.transform.rotation);
        Magic.GetComponent<Rigidbody>().velocity = Magic.transform.forward * BallSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnThunderBolt();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnFireBall();
        }
    }
}
