using UnityEngine;

public class Transitions : MonoBehaviour
{
	private GameObject player;

	/// <summary>
	/// 0 - First room / bio
	/// 1 - Second room / hallway
	/// 2 - Third room / hall
	/// 3 - Fourth room / astro
	/// 4 - Fifth room / security
	/// 5 - Sixth room / room
	/// </summary>
	[SerializeField]
	private GameObject[] locations;

	private void Start()
	{
		player = GameObject.Find("Player");
	}

	enum Spawns
	{
		SpawnBioToHallway,
		SpawnHallwayToBio,
		SpawnHallwayToHall,
		SpawnHallToHallway,
		SpawnHallToAstro,
		SpawnAstroToHall,
		SpawnAstroToSecurity,
		SpawnSecurityToAstro,
		SpawnSecurityToRoom,
		SpawnRoomToSecurity
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			switch (tag)
			{
				case "BioToHallway":

					Transition(locations[1], locations[0], Spawns.SpawnBioToHallway);

					break;
				case "HallwayToBio":

					Transition(locations[0], locations[1], Spawns.SpawnHallwayToBio);

					break;
				case "HallwayToHall":

					Transition(locations[2], locations[1], Spawns.SpawnHallwayToHall);

					break;
				case "HallToHallway":

					Transition(locations[1], locations[2], Spawns.SpawnHallToHallway);

					break;
				case "HallToAstro":

					Transition(locations[3], locations[2], Spawns.SpawnHallToAstro);

					break;
				case "AstroToHall":

					Transition(locations[2], locations[3], Spawns.SpawnAstroToHall);

					break;
				case "AstroToSecurity":

					Transition(locations[4], locations[3], Spawns.SpawnAstroToSecurity);

					break;
				case "SecurityToAstro":

					Transition(locations[3], locations[4], Spawns.SpawnSecurityToAstro);

					break;
				case "SecurityToRoom":

					Transition(locations[5], locations[4], Spawns.SpawnSecurityToRoom);

					break;
				case "RoomToSecurity":

					Transition(locations[4], locations[5], Spawns.SpawnRoomToSecurity);

					break;
			}
		}
	}

	private void Transition(GameObject locEnable, GameObject locDisable, Spawns spawn)
	{
		player.GetComponent<CharacterController>().enabled = false;

		locEnable.SetActive(true);
		locDisable.SetActive(false);

		player.transform.position = GameObject.Find(spawn.ToString()).transform.position;

		player.GetComponent<CharacterController>().enabled = true;
	}
}
