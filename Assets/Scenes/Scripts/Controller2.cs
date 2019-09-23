using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InverseKinematics;

public class Controller2 : MonoBehaviour {
    IKSystem sys;
    IKSystem sys2;
    IKSystem sys3;

    IKSystem _sys;
    IKSystem _sys2;
    IKSystem _sys3;
    // Use this for initialization
    void Start () {

        _sys = new IKSystem(5, 3);
        _sys2 = new IKSystem(-5, 3);
        _sys3 = new IKSystem(0, 3);

        sys = new IKSystem(5, -3);
        sys2 = new IKSystem(-5, -3);
        sys3 = new IKSystem(0, -3);
        for (int i = 0; i < 240; i++) {
            sys.AddSegment(0.01f);
            sys2.AddSegment(0.01f);
            sys3.AddSegment(0.01f);

            _sys.AddSegment(0.01f);
            _sys2.AddSegment(0.01f);
            _sys3.AddSegment(0.01f);
        }

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        sys.Reach(mousePos.x, mousePos.y);
        sys2.Reach(mousePos.x, mousePos.y);
        sys3.Reach(mousePos.x, mousePos.y);
        _sys.Reach(mousePos.x, mousePos.y);
        _sys2.Reach(mousePos.x, mousePos.y);
        _sys3.Reach(mousePos.x, mousePos.y);
    }

    private void OnDrawGizmos()
    {
        sys.Draw();
        sys2.Draw();
        sys3.Draw();
        _sys.Draw();
        _sys2.Draw();
        _sys3.Draw();
    }
}
