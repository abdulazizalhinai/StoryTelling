using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Test : DefaultTrackableEventHandler, IDropHandler
{
    bool move=false;
   public Transform cube;
  public Rigidbody rb;
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        cube = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        if (move==true)
        {
           // rb.velocity = 100 * transform.up;
            //cube.transform.position = new Vector3(cube.transform.position.x + 1f, cube.transform.position.y + 1f, cube.transform.position.z + 1f);
            print("aaaa");
        }
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

    public void OnDrop(PointerEventData eventData)
    {
        cube.position = Input.mousePosition;
       
       
    }
    private void OnMouseDrag()
    {
        cube.transform. position = Input.mousePosition;
    }
}



