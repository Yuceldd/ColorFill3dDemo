using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoxMove : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    [SerializeField] private float speed = 1;
    private float t;

    private void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(pointA, pointB, t);
        if (t >= 1)
        {
            var b = pointB;
            var a = pointA;
            pointA = b;
            pointB = a;
            t = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("newbox1"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("touchedbox"))
        {
            //Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}