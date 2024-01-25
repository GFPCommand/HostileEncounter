using DG.Tweening;
using UnityEngine;

public class ShieldInteract : MonoBehaviour
{
	private void Start()
	{
		int startState = Random.Range(1, 7);

		Vector3 rot = new(0, 0, 360 / startState);

		transform.eulerAngles = rot;
	}

	public void RotateShieldBlock()
    {
        transform.DOLocalRotate(transform.eulerAngles + new Vector3 (0, 0, 60), 1);
    }
}
