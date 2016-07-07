using UnityEngine;
using System.Collections;

public class EnemyLvlHp : MonoBehaviour
{
    public int HP;
    public bool isSoldier;
    public GameObject enemy;
    EnergyBar InfoHP;
    EnemySoldier ControllSoldier;
    

    void Awake()
    {
        InfoHP = GetComponentInChildren<EnergyBar>();
        if (isSoldier)
        {
            ControllSoldier = enemy.GetComponent<EnemySoldier>();
        }
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
                
                if (isSoldier)
                {
                    ControllSoldier.isDeath = true;
                }
                else
                {
                    Destroy(enemy);
                }
            }
        }
        if (coll.tag == "Player")
        {
            if (isSoldier)
            {
                ControllSoldier.isDeath = true;
            }
            else
            {
                Destroy(enemy);
            }
        }
    }
}
