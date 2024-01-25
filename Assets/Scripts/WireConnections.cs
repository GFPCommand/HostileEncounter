using UnityEngine;

public class WireConnections : MonoBehaviour
{
	private bool isDown = false;

	private Color color;

	private void OnMouseDown()
	{
		isDown = true;

		color = Color.red;
	}

	private void OnMouseUp()
	{
		isDown = false;
	}

	private void OnMouseDrag()
	{
		if (isDown)
		{

		}
	}
}
