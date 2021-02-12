using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveManager : MonoBehaviour
{
    public static MoveManager singltone;
    public Text text;
    public GameObject Heart_top;
    private Camera cam;
    private GameObject currentCandy;
    private Vector3 startPosition;
    void Start()
    {
        if (!singltone) singltone = this;
        else Destroy(this);
        
        cam = Camera.main;
        text.text = "Put candies \n in the box";
    }

    private float h;
    private float v;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition),out hit,1000))
            {
                if (hit.transform.CompareTag("Candy"))
                {
                    currentCandy = hit.transform.gameObject;
                    startPosition = currentCandy.transform.position;
                    h = startPosition.x;
                    v = startPosition.z;
                }
            }
        }
        else if (Input.GetMouseButton(0)&& currentCandy)
        {
            h -= Input.GetAxis("Mouse X") / 11;
            v -= Input.GetAxis("Mouse Y") / 11;
            var pos = new Vector3(h, 0.25f, v);
            currentCandy.transform.position = pos;
        }
        else if (Input.GetMouseButtonUp(0) && currentCandy)
        {
            currentCandy.transform.position = startPosition;
            currentCandy = null;
        }
    }

    private float allCandy = 8;
    public void AddCandy()
    {
        allCandy--;
        if (allCandy == 0)
        {
            Heart_top.GetComponent<Animation>().Play();
            text.text = "Done!";
        }
    }
}
