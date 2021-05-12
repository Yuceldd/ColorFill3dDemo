using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

class GridMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float gridSize = 0.05f;
    public LayerMask ObstacleLayerMask;

    private enum Orientation
    {
        Horizontal,
        Vertical
    };

    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    private Vector2 input;
    private bool isMoving = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t;
    private float factor;

    private bool hitCheck;
    private float h = 0;
    private float v = 0;

    public void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
    }

    public void FixedUpdate()
    {
        if (!isMoving)
        {
            input = new Vector2(h, v);
            if (!allowDiagonals)
            {
                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                {
                    input.y = 0;
                }
                else
                {
                    input.x = 0;
                }
            }

            if (input != Vector2.zero)
            {
                StartCoroutine(move(transform));
            }
        }
    }

    public IEnumerator move(Transform transform)
    {
        isMoving = true;
        startPosition = transform.position;
        t = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);
        }

        if (allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0)
        {
            factor = 0.7071f;
        }
        else
        {
            factor = 1f;
        }

        Vector3 vec1 = new Vector3(0, 0, 0);
        RaycastHit hitInfo;
        var hitDir = (endPosition - startPosition).normalized;
        bool hitCheck = Physics.Raycast(startPosition, hitDir, out hitInfo, gridSize, ObstacleLayerMask);
        if (hitCheck)
        {
            if (hitInfo.transform.tag == "newbox1")
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

            else
            {
                while (t < 1f)
                {
                    t += Time.deltaTime * (moveSpeed / gridSize) * factor;

                    transform.position = Vector3.Lerp(startPosition, endPosition, t);


                    yield return null;
                }
            }
        }
        else
        {
            while (t < 1f)
            {
                t += Time.deltaTime * (moveSpeed / gridSize) * factor;

                transform.position = Vector3.Lerp(startPosition, endPosition, t);

                yield return null;
            }
        }


        isMoving = false;
        yield return 0;
    }
}