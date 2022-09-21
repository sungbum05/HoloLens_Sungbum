using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent(out TargetObject tar))
            {
                if(tar.OnShield == true)
                {
                    Debug.Log("Th");
                    tar.OnShield = false;
                    tar.Shield.SetActive(false);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
