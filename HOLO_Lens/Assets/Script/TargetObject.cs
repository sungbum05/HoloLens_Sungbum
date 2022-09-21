using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    const float MoveSpeed = 1.0f;

    public GameObject Player;
    public MonsterSpawn MonsterSpawn;
    public Transform Transform;

    public GameObject Shield;
    public bool OnShield = false;

    private int hp;
    public int HP 
    { 
        get 
        { 
            return hp; 
        }

        set
        {
            if (OnShield == true)
                return;

            hp = value;

            if(hp <= 0)
            {
                MonsterSpawn.SpawnList.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        hp = 100;

        Shield = this.gameObject.transform.GetChild(3).gameObject;
        OnShield = Shield.gameObject.active;

        MonsterSpawn = GameObject.FindObjectOfType<MonsterSpawn>();
        Player = GameObject.FindGameObjectWithTag("MainCamera");
        this.Transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.Transform.LookAt(Player.transform.position);

        this.Transform.position = Vector3.MoveTowards(this.Transform.position, Player.transform.position,
            MoveSpeed * Time.deltaTime);
    }
}
