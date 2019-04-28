using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : DefaultTrackableEventHandler
{
    bool move = false;
    //public Transform cube;
    //public Rigidbody rb;
    //Transform mytransform;
    private Vector3 mOffset;
    private float mZCoord;
    Vector3 OrginalPostion;
    int red = 0, green = 0;

    bool done = false;

    public string Box;

    ParticleSystem effects;
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        PlayerPrefs.SetInt("red", 0);
        PlayerPrefs.SetInt("green", 0);
        OrginalPostion = transform.localPosition;
        //  cube = GetComponent<Transform>();
        print(OrginalPostion);
        //rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        //mOffset.y = gameObject.transform.position.y + 1.5f;

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        RaycastHit hit;

        Physics.Raycast(Camera.main.transform.position, (GetMouseAsWorldPoint() - Camera.main.transform.position).normalized, out hit, 100, 1 << 9);

        Vector3 point = hit.point;
        //point.y = 0.5f;

        transform.position = point + hit.normal * 5f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Box == other.tag && done == false)
        {

            done = true;
            print("ok");
            if (Box == "RedBox")
            {
                //Destroy(gameObject);
                PlayerPrefs.SetInt("red", PlayerPrefs.GetInt("red") + 1);

            }
            else if (Box == "GreenBox")
            {
                // Destroy(gameObject);
                PlayerPrefs.SetInt("green", PlayerPrefs.GetInt("green") + 1);

            }
            if (PlayerPrefs.GetInt("red") == 3 && PlayerPrefs.GetInt("green") == 3)
            {

                print("Welldone!");

                GameManager.Instance.GameWon();

            }
            //correct answer



            else
            {
                print("no");
                transform.localPosition = OrginalPostion;

                //wrong answer
            }
        }
    }

}



