using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Lr_LineController : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private RectTransform[] points;

	private void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	public void SetUpLine(RectTransform[] points)
	{
		lr.positionCount = points.Length;
		this.points = points;
	}

	private void Update()
	{
		for (int i = 0; i < points.Length; i++) 
		{
			lr.SetPosition(i, points[i].position);

		}
	}

	private void OnMouseDrag()
	{
		Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
