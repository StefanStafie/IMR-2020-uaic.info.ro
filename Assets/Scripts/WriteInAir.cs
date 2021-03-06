﻿namespace VRTK.Examples {
    using UnityEngine;

    public class WriteInAir : MonoBehaviour {
        public VRTK_InteractableObject linkedObject;
        protected Transform writer;
        protected bool writing;

        void DrawLittleSquare (Vector3 center, Color color, GameObject DrawOnThis) {
            GameObject myLine = new GameObject ("Line" + DrawOnThis.transform.childCount);
            myLine.transform.parent = DrawOnThis.transform;
            myLine.AddComponent<LineRenderer> ();
            LineRenderer lr = myLine.GetComponent<LineRenderer> ();
            lr.material = new Material (Shader.Find ("Specular"));
            lr.SetColors (color, color);
            lr.SetWidth (0.1f, 0.1f);
            lr.SetVertexCount (3);
            lr.SetPosition (0, center + new Vector3 (0.05f, 0.05f, 0.0f));
            lr.SetPosition (1, center - new Vector3 (0.05f, 0.05f, 0.0f));
            lr.SetPosition (2, center - new Vector3 (0.2f, 0.2f, 0.0f));

        }

        void AddPoint (Vector3 center, Color color, GameObject DrawOnThis) {
            GameObject lastChild = DrawOnThis.transform.GetChild (DrawOnThis.transform.childCount - 1).gameObject;
            lastChild.GetComponent<LineRenderer> ();
            LineRenderer lr = lastChild.GetComponent<LineRenderer> ();
            lr.material = new Material (Shader.Find ("Specular"));
            lr.SetColors (color, color);
            lr.SetWidth (0.1f, 0.1f);
            lr.positionCount = lr.positionCount + 1;
            lr.SetPosition (lr.positionCount - 1, center);
        }

        protected virtual void OnEnable () {
            writing = false;
            linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject> () : linkedObject);

            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed += InteractableObjectUsed;
                linkedObject.InteractableObjectUnused += InteractableObjectUnused;
            }

            writer = transform.Find ("Capsule");
        }

        protected virtual void OnDisable () {
            if (linkedObject != null) {
                linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
                linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
            }
        }

        protected virtual void Update () {
            if (writing) {
                AddPoint (writer.transform.position, Color.white, writer.transform.gameObject);
            }
        }

        protected virtual void InteractableObjectUsed (object sender, InteractableObjectEventArgs e) {
            writing = true;
            DrawLittleSquare (writer.transform.position, Color.white, writer.transform.gameObject);
        }

        protected virtual void InteractableObjectUnused (object sender, InteractableObjectEventArgs e) {
            writing = false;
        }
    }
}