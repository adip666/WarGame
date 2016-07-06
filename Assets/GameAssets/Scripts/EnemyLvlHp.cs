using UnityEngine;
using System.Collections;

public class EnemyLvlHp : MonoBehaviour
{
    public int HP;
    public GameObject enemy;
    EnergyBar InfoHP;

    void Awake()
    {
        InfoHP = GetComponentInChildren<EnergyBar>();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Ammo")
        {
            Destroy(coll.gameObject);
            HP--;
            InfoHP.SetValueCurrent(HP);
            if (HP <= 0)
            {
                
                Destroy(enemy);
            }
        }
    }
}
