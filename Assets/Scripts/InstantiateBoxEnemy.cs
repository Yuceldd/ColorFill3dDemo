using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class InstantiateBoxEnemy : MonoBehaviour
{
    public int enemyZ = 0;
    public int enemyNum = 2;
    public int enemyRange;
    public EnemyBoxMove EnemyBox;

    void Start()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            EnemyBox = Instantiate(EnemyBox, new Vector3(i, 0.5f, enemyZ), Quaternion.identity);
            EnemyBox.pointA = EnemyBox.transform.position;
            EnemyBox.pointB = EnemyBox.transform.position + new Vector3(0, 0, enemyRange);
        }
    }
}