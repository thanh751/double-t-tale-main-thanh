using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    //public Text nameText;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else Load();
        UpdateCharacter(selectedOption);
    }
    public void NextOption()
    {
        audioManager.PlaySFX(audioManager.click);
        selectedOption++;
        if (selectedOption >= characterDB.characterCount) selectedOption = 0;
        UpdateCharacter(selectedOption);
        Save();
    }
    public void BackOption()
    {
        audioManager.PlaySFX(audioManager.click);
        selectedOption--;
        if (selectedOption < 0) selectedOption = characterDB.characterCount - 1;
        UpdateCharacter(selectedOption);
        Save();
    }
    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprites;
        //nameText.text = character.name;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }
}
