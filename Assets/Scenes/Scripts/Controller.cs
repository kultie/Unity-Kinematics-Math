using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForwardKinematics;

public class Controller : MonoBehaviour {
    List<Segment> roots = new List<Segment>();
    Segment segment1;
    Segment segment2;
    Segment segment3;

    int count = 1;
    float angle = 0;

    private void Start()
    {
        segment1 = new Segment(0, 0, 0.5f, 0);
        segment2 = new Segment(segment1, 0.5f, 0);
        segment3 = new Segment(segment2, 0.5f, 0);
    }

    //private void Start()
    //{
    //    for (int i = 0; i < count; i++) {
    //        roots.Add(new Segment(0, 0, 0.1f, 360 * i * Mathf.Deg2Rad / count));
    //    }

    //    for (int i = 0; i < count; i++)
    //    {
    //        Segment root = roots[i];
    //        Segment current = root;
    //        for (int j = 0; j < 50; j++)
    //        {
    //            Segment next = new Segment(current, 0.1f, 0);
    //            current = next;
    //        }           
    //    }
    //}   

    private void OnDrawGizmos()
    {
        angle += 0.05f;
        //for (int i = 0; i < count; i++)
        //{
        //    Segment next = roots[i];
        //    int var = 0;
        //    while (next != null)
        //    { 
        //        next.Wiggle(angle,var * 1f/5);
        //        next.Update();
        //        next.Draw();
        //        next = next.child;
        //        var++;
        //    }
        //}
        segment1.Wiggle(Mathf.Sin(angle) * 1.2f);
        segment1.Update();
        segment1.Draw();

        segment2.Wiggle(Mathf.Cos(angle * 0.875f) * 0.5f);
        segment2.Update();
        segment2.Draw();

        segment3.Wiggle(Mathf.Sin(angle * 1.358f) * 1.203f);
        segment3.Update();
        segment3.Draw();
    }
}
