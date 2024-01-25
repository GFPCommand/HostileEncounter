using UnityEngine;

public class InteractActions : MonoBehaviour
{
	[SerializeField]
	private GameObject lasersUI;
	[SerializeField]
	private GameObject wiresUI;
	[SerializeField]
	private GameObject chemicalUI;
	[SerializeField]
	private GameObject bioUI;
	[SerializeField]
	private GameObject switchersUI;
	[SerializeField]
	private GameObject shieldCanvas;
	[SerializeField]
	private GameObject[] locs;
	[SerializeField]
	private GameObject canvasObj;
	[SerializeField]
	private GameObject player;

	private PlayerInteractions interactions;

    private string objectTag = string.Empty;

	int activeModule = 0;

	private void Start()
	{
		interactions = player.GetComponent<PlayerInteractions>();
	}

	public void Action()
	{
		objectTag = interactions.objectTag;

		StartCoroutine(interactions.ActionAnim());

		// switch object tag and invoke action

		switch (objectTag)
		{
			case "Lasers":
				lasersUI.SetActive(true);

				canvasObj.SetActive(false);
				break;
			case "Wires":
				wiresUI.SetActive(true);

				canvasObj.SetActive(false);
				player.SetActive(false);

				for (int i = 0; i < locs.Length; i++)
				{
					if (locs[i].activeInHierarchy) activeModule = i;

					locs[i].SetActive(false);
				}
				break;
			case "Chemical":
				chemicalUI.SetActive(true);

				canvasObj.SetActive(false);
				break;
			case "Shield":
				shieldCanvas.SetActive(true);

				canvasObj.SetActive(false);
				break;
			case "Bio":
				bioUI.SetActive(true);

				canvasObj.SetActive(false);
				break;
			case "Switchers":
				switchersUI.SetActive(true);

				canvasObj.SetActive(false);
				break;
			default:
				Debug.Log(objectTag);
				break;
		}
	}

	public void Exit()
	{
		wiresUI.SetActive(false);
		lasersUI.SetActive(false);
		chemicalUI.SetActive(false);
		shieldCanvas.SetActive(false);
		bioUI.SetActive(false);
		switchersUI.SetActive(false);

		canvasObj.SetActive(true);
		player.SetActive(true);

		locs[activeModule].SetActive(true);
	}
}
