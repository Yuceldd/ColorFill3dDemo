using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeEssentials : MonoBehaviour
{
    Rigidbody physics;
    public Transform movePoint;

    private int health = 1;
    private bool isStop;

    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 vec1 = new Vector3(0, 0, 0);


        if (other.gameObject.tag == "newbox" || other.gameObject.tag == "newbox1" ||
            other.gameObject.tag == ("redcube") || other.gameObject.tag == "enemybox")
        {
            if (other.gameObject.tag == "newbox")
            {
                other.transform.tag = "touchedbox";
                Color color = Color.cyan;

                GameObject[] objects = GameObject.FindGameObjectsWithTag("touchedbox");

                foreach (GameObject go in objects)
                {
                    MeshRenderer[] renderers = go.GetComponentsInChildren<MeshRenderer>();
                    foreach (MeshRenderer r in renderers)
                    {
                        foreach (Material m in r.materials)
                        {
                            if (m.HasProperty("_Color"))
                                m.color = color;
                        }
                    }
                }
            }

            else if (other.gameObject.tag == "newbox1")
            {
                var touchobjecslist = GameObject.FindGameObjectsWithTag("touchedbox");
                ;
                foreach (var to in touchobjecslist)
                {
                    vec1 = to.transform.position;
                    vec1.y += 0.7f;
                    to.transform.position = vec1;

                    to.transform.tag = "newbox1";
                }
            }
            else if (other.gameObject.tag == "redcube")

            {
                Destroy(GameObject.FindGameObjectWithTag("redcube"));

                health++;
            }
            else if (other.gameObject.tag == "enemybox")

            {
                health--;
            }
        }


        var aimBoxList = GameObject.FindGameObjectsWithTag("newbox");

        if (aimBoxList.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        ;
        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}