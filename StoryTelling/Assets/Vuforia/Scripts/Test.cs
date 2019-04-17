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

    public string Box;
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();

        OrginalPostion = transform.position;
        //  cube = GetComponent<Transform>();
        print(OrginalPostion);
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //if (transform.position.y < 0.1f)
        //{
        //    transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);

        //}

    }
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        // print("aaaa");
        move = true;
    }
    protected override void OnTrackingLost()
    {
        // print("bbbb");
        base.OnTrackingLost();
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

        Physics.Raycast(Camera.main.transform.position, (GetMouseAsWorldPoint() - Camera.main.transform.position).normalized, out hit);

        Vector3 point = hit.point;
        point.y = 1.5f;

        transform.position = point;

    }
    //private void OnMouseUp()
    //{
    //    if( transform.position.z >=0)
    //    {
    //        transform.position = new Vector3(-0.3106f, 0.0255f, -0.458f);
    //        print("yes");
    //    }
    //    else
    //    {
    //        transform.position = OrginalPostion;
    //        print("no");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (Box == other.tag)
        {
            print("ok");
        }
        else
        {
            print("no");
            transform.position = OrginalPostion;
        }
    }

}



