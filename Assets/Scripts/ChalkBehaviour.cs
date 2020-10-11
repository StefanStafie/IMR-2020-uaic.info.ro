using System.Collections;
using UnityEngine;

public class ChalkBehaviour : MonoBehaviour {

    public int first;

    void DrawLittleSquare (Vector3 center, Color color, GameObject DrawOnThis) {
        GameObject myLine = new GameObject ("Line" + DrawOnThis.transform.childCount);
        myLine.transform.parent = DrawOnThis.transform;
        myLine.AddComponent<LineRenderer> ();
        LineRenderer lr = myLine.GetComponent<LineRenderer> ();
        lr.material = new Material (Shader.Find ("Specular"));
        lr.SetColors (color, color);
        lr.SetWidth (0.1f, 0.1f);
        lr.SetVertexCount(3);
        lr.SetPosition (0, center + new Vector3 (0.05f, 0.05f, 0.0f));
        lr.SetPosition (1, center - new Vector3 (0.05f, 0.05f, 0.0f));
        lr.SetPosition (2, center - new Vector3 (0.2f, 0.2f, 0.0f));

    }

    void AddPoint (Vector3 center, Color color, GameObject DrawOnThis) {
        
        GameObject lastChild = DrawOnThis.transform.GetChild(DrawOnThis.transform.childCount - 1).gameObject;
        lastChild.GetComponent<LineRenderer> ();
        LineRenderer lr = lastChild.GetComponent<LineRenderer> ();
        lr.material = new Material (Shader.Find ("Specular"));
        lr.SetColors (color, color);
        lr.SetWidth (0.1f, 0.1f);
        lr.positionCount = lr.positionCount + 1;
        lr.SetPosition (lr.positionCount-1, center);
    }
    void Start () { }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name == "WriteSurface")
            foreach (ContactPoint contact in collision.contacts) {
                DrawLittleSquare (contact.point, Color.white, collision.gameObject);
            }
    }

    void OnCollisionStay (Collision collision) {
        if (collision.gameObject.name == "WriteSurface")
            foreach (ContactPoint contact in collision.contacts) {
                AddPoint (contact.point, Color.white, collision.gameObject);
            }
    }
}