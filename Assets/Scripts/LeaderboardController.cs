using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;

public class LeaderboardController : MonoBehaviour
{
    public IntegerVariableReference highScore;
    public TMP_InputField playerName;
    string LeaderboardID = "11274";
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerName.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucessfully set player name");
            }
            else
            {
                Debug.LogError("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return FetchTopHighscores();
    }
    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucess");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.LogError("Failed");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
    public void SubmitScore()
    {
        string PlayerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(PlayerID, (int)highScore.Value, LeaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucessfully added scores");
            }
            else
            {
                Debug.LogError("Failed to add scores");
            }
        });
    }
    public IEnumerator FetchTopHighscores()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(LeaderboardID, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

}
