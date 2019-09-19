using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    Segment segment;
    Segment segment2;

    private void Start()
    {
        segment = new Segment(0, 0, 0.1f, 45 * Mathf.Deg2Rad);
        Segment current = segment;
        for (int i = 0; i < 20; i++) {
            Segment next = new Segment(current, 0.1f, 0);
            current.child = next;
            current = next;
        }
    }

    private void Update()
    {
        Segment next = segment;
        while (next != null)
        {
            next.Wiggle();
            next.Update();
            next = next.child;
        }
    }

    private void OnDrawGizmos()
    {
        Segment next = segment;
        while (next != null) {
            next.Draw();
            next = next.child;
        }        
    }
}
