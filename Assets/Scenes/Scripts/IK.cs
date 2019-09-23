using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InverseKinematics {

    public class IKSystem {
        public float x, y;
        public List<Segment> segments;
        public Segment lastSegment;

        public IKSystem(float x, float y) {
            this.x = x;
            this.y = y;
            segments = new List<Segment>();
        }

        public void AddSegment(float length) {
            Segment seg;
            if(this.lastSegment != null){
                seg = new Segment(lastSegment, length, 0);
            }
            else {
                 seg = new Segment(x, y, length, 0);
            }
            segments.Add(seg);
            lastSegment = seg;
        }

        public void Draw() {
            for (int i = 0; i < segments.Count; i++) {
                segments[i].Draw();
            }
        }

        public void Drag(float x, float y) {
            lastSegment.Drag(x, y);
        }

        public void Reach(float x, float y)
        {
            this.Drag(x, y);
            Update();
        }

        void Update() {
            for (int i = 0; i < segments.Count; i++) {
                var seg = segments[i];
                if (seg.parent != null)
                {
                    seg.x = seg.parent.GetEndX();
                    seg.y = seg.parent.GetEndY();
                }
                else {
                    seg.x = this.x;
                    seg.y = this.y;
                }
            }
        }

    }

    public class Segment {

        public Segment parent = null;

        public float x, y;      
        public float angle;

        float len;

        public Segment(float x, float y, float length, float angle) {

            this.x = x;
            this.y = y;
            this.len = length;
            this.angle = angle;
            parent = null;
        }

        public Segment(Segment parent, float length, float angle)
        {  
            this.len = length;
            this.angle = angle;
            this.parent = parent;
            this.x = parent.x;
            this.y = parent.y;
        }
    
        public float GetEndX() {
            float dx = len * Mathf.Cos(angle);
            return this.x + dx;
        }

        public float GetEndY() {
            float dy = len * Mathf.Sin(angle);
            return this.y + dy;
        } 
        public void Draw()
        {
            Vector3 root = new Vector3(this.x, this.y);
            Vector3 end = new Vector3(GetEndX(), GetEndY());
            Gizmos.DrawLine(root, end);
        }

        public void PointAt(float x, float y) {
            var dx = x - this.x;
            var dy = y - this.y;
            this.angle = Mathf.Atan2(dy, dx);
        }

        public void Drag(float x, float y) {
            PointAt(x, y);
            this.x = x - Mathf.Cos(this.angle) * this.len;
            this.y = y - Mathf.Sin(this.angle) * this.len;
            if (this.parent != null) {
                this.parent.Drag(this.x, this.y);
            }
        } 
    }
}

