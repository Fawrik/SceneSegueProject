using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SPWN_Segue : MonoBehaviour
{
	public int outValue;
	public int inValue;

	public GameObject outPoint;
	public GameObject inPoint;

	public string sceneID;

	public Mesh mesh;


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			SPWN_Manager.Instance.spawnValue = outValue;
			SPWN_Manager.Instance.LoadScene(sceneID);
		}
	}

	private void OnDrawGizmos()
	{
		//Draw enter point in the editor
		Gizmos.matrix = inPoint.transform.localToWorldMatrix;
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		Gizmos.DrawLine(Vector3.zero, Vector3.forward);

		//Draw exit point in editor
		Gizmos.matrix = outPoint.transform.localToWorldMatrix;
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
	}

	[ContextMenu("Update Point Names")]
	public void Rename()
	{
		inPoint.name = "In_" + inValue;
		outPoint.name = "Out_" + outValue;
	}

	/*
    public static void DrawWireCapsule(Vector3 _pos, Quaternion _rot, float _radius, float _height, Color _color = default(Color))
    {
        if (_color != default(Color))
            Handles.color = _color;
        Matrix4x4 angleMatrix = Matrix4x4.TRS(_pos, _rot, Handles.matrix.lossyScale);
        using (new Handles.DrawingScope(angleMatrix))
        {
            var pointOffset = (_height - (_radius * 2)) / 2;

            //draw sideways
            Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.left, Vector3.back, -180, _radius);
            Handles.DrawLine(new Vector3(0, pointOffset, -_radius), new Vector3(0, -pointOffset, -_radius));
            Handles.DrawLine(new Vector3(0, pointOffset, _radius), new Vector3(0, -pointOffset, _radius));
            Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.left, Vector3.back, 180, _radius);
            //draw frontways
            Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.back, Vector3.left, 180, _radius);
            Handles.DrawLine(new Vector3(-_radius, pointOffset, 0), new Vector3(-_radius, -pointOffset, 0));
            Handles.DrawLine(new Vector3(_radius, pointOffset, 0), new Vector3(_radius, -pointOffset, 0));
            Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.back, Vector3.left, -180, _radius);
            //draw center
            Handles.DrawWireDisc(Vector3.up * pointOffset, Vector3.up, _radius);
            Handles.DrawWireDisc(Vector3.down * pointOffset, Vector3.up, _radius);

        }
    }
	*/
}


