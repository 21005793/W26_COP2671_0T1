using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameMAnager;

    public int difficulty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gameMAnager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(setDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        gameMAnager.StartGame(difficulty);
    }
}
