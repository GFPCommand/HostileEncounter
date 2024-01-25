using UnityEngine;
using UnityEngine.UI;

public class SwitcherInteract : MonoBehaviour
{
	int index;

    private Image switcherImage;

	[SerializeField]
	private Sprite[] switcherImages;

	private void Start()
	{
		index = 0;

		switcherImage = GetComponent<Image>();

		switcherImage.sprite = switcherImages[index];
	}

	public void Switch()
	{
		index = index == 0 ? 1 : 0;

		switcherImage.sprite = switcherImages[index];
	}
}
