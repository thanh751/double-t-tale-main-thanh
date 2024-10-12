using TMPro;
using UnityEngine;
using UnityEngine.UI;
//Quan ly toan bo game, ve scoring, UI...
public class GameManager : MonoBehaviour
{
    private Player player;
    private Spawner spawner;
    public static GameManager Instance { get; private set; }
    //get cho quyen access tu moi nguon, nhung private set chi cho class nay duoc tuy chinh

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    public float score;
    //dung de tinh diem cho thoi khong le nhu 2,4s tot hon

    public GameOverScreen GameOverScreen;


    public float gameSpeed { get; private set; } 
    public float initialGameSpeed = 5f;
    public float gameSpeedChange = 0.1f;
    private void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(gameObject);
        }
    private void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }
    private void Start()
        {
            player = FindObjectOfType<Player>();
            spawner = FindObjectOfType<Spawner>();
            NewGame();
        }
  
        private void NewGame()
        {
            // Obstacle[] obstacles = FindObjectOfType
            gameSpeed = initialGameSpeed;
            enabled = true;
            player.gameObject.SetActive(true);
            spawner.gameObject.SetActive(true);
            UpdateHiScore();
        }
        public void GameOver()
        {
            HealthManager.health = 0;
            GameOverScreen.Setup(score);
            gameSpeed = 0f;
            enabled = false;
            player.gameObject.SetActive(false);
            spawner.gameObject.SetActive(false);
            UpdateHiScore();
           
    }
        private void Update()
    {
            gameSpeed = gameSpeed + gameSpeedChange * Time.deltaTime;
            score += gameSpeed * Time.deltaTime;
            scoreText.text = Mathf.FloorToInt(score).ToString("D5");
            //Floor de lam tron xuong, D5 de luon hien 5 chu so
        }

        private void UpdateHiScore()
        {
            float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

            if (score > hiscore)
            {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
            }

            hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
   }
}
