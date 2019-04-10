using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : DefaultTrackableEventHandler
{
  

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnTrackingFound()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
        base.OnTrackingFound();
    }
}
