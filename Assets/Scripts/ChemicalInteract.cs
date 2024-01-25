using UnityEngine;
using DG.Tweening;

public class ChemicalInteract : MonoBehaviour
{
	private bool isClick = false;

	public void BottleUpDown()
	{
		if (isClick)
		{
			transform.DOLocalMoveY(-150, 1);
			isClick = false;
		} 
		else
		{
			transform.DOLocalMoveY(-50, 1);
			isClick = true;
		}
	}
}
