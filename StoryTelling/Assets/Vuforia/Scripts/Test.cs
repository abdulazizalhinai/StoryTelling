using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : DefaultTrackableEventHandler
{
    bool move=false;
   //public Transform cube;
  //public Rigidbody rb;
    Transform mytransform;
    private Vector3 mOffset;
    private float mZCoord;
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
      //  cube = GetComponent<Transform>();
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
       
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

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }

}



