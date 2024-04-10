using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
	public PlayerMovement playerMovement;
	public List<int> playerFinish;
	public List<TextMeshProUGUI> playerLabels;
	public int index;
	// Start is called before the first frame update
	void Start()
	{
		playerFinish = new();
	}
	private void OnTriggerEnter(Collider other)
	{
		var player = other.GetComponent<PlayerMovement>();
		UpdateScoreboard(player.playerIndex);
	}
	void UpdateScoreboard(int playerIndex)
	{
		if (playerFinish.Contains(playerIndex))
			return;

		playerFinish.Add(playerIndex);
		playerLabels[index].text = $"Speler {playerIndex + 1}";
		index++;
	}
}
