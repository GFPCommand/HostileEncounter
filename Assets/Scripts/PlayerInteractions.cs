using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private Button actionButton;

	private const string IS_ACTION = "IsAction";

	[HideInInspector]
	public string objectTag = string.Empty;

	private void OnTriggerEnter(Collider other)
	{
		objectTag = other.gameObject.tag;

		switch (objectTag)
		{
			case "Lasers":
				actionButton.interactable = true;
				break;
			case "Wires":
				actionButton.interactable = true;
				break;
			case "Chemical":
				actionButton.interactable = true;
				break;
			case "Shield":
				actionButton.interactable = true;
				break;
			case "Bio":
				actionButton.interactable = true;
				break;
			case "Switchers":
				actionButton.interactable = true;
				break;
			default:
				Debug.Log(other.gameObject.tag);
				actionButton.interactable = false;
				break;
		}	
	}

	private void OnTriggerExit(Collider other)
	{
		actionButton.interactable = false;
	}

	public IEnumerator ActionAnim()
	{
		animator.SetBool(IS_ACTION, true);

		yield return new WaitForSeconds(1f);

		animator.SetBool(IS_ACTION, false);
	}
}
