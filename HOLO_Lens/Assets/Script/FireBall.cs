using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);

            if(other.gameObject.TryGetComponent(out TargetObject tar))
            {
                tar.HP -= 100;
            }
        }
    }
}
