using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningLasers : MonoBehaviour
{
    [SerializeField]
    private RectTransform[] mirror;

    public void TurnRight(int index)
    {
		if (mirror[index].eulerAngles.z >= 310||mirror[index].eulerAngles.z <= 50) // [0;50] U [310;360] -> OK
			mirror[index].transform.Rotate(new Vector3(0, 0, 5));
	}

	public void TurnLeft(int index)
    {
		if (mirror[index].eulerAngles.z >= 310 || mirror[index].eulerAngles.z <= 50)
			mirror[index].transform.Rotate(new Vector3(0, 0, -5));
	}
}
