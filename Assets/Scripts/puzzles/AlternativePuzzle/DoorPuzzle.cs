using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorPuzzle : MonoBehaviour {

    /// <summary>
    /// Reference to the audiosource.
    /// </summary>
    private AudioSource source;

    /// <summary>
    /// Reference to the door.
    /// </summary>
    private GameObject door;

    /// <summary>
    /// Reference to the door unlock sound.
    /// </summary>
    [SerializeField]private AudioClip doorUnlockSound;
    
    /// <summary>
    /// Reference to the inventoryUI script.
    /// </summary>
    private InventoryUI inventoryUI;

    /// <summary>
    /// A list (array) to keep track of the items collected.
    /// </summary>
    private List<GameObject> itemsCollected = new List<GameObject>();

    /// <summary>
    /// Reference to the Inspect script.
    /// </summary>
    private Inspect inspect;

    /// <summary>
    /// Reference to the audiomanager script to play audio files.
    /// </summary>
    private AudioManager audioManager;

    /// <summary>
    /// Reference to the screen fader script.
    /// </summary>
    private ScreenFader fader;

    private void Start()
    {
        door = this.gameObject;

        inventoryUI = GameObject.FindObjectOfType<InventoryUI>();
        inventoryUI.InventoryStatus += checkPuzzleState;

        inspect = GameObject.FindObjectOfType<Inspect>();
        inspect.InspectingObjectEvent += unlockDoor;

        audioManager = GameObject.FindObjectOfType<AudioManager>();

        fader = GameObject.FindObjectOfType<ScreenFader>();
        fader.FadeInStatus += proceedToNextScene;
    }

    /// <summary>
    /// When you click on the door, screen will fade in.
    /// </summary>
    /// <param name="obj"></param>
    private void unlockDoor(GameObject obj)
    {
        if (obj.name == door.name)
        {
            fader.ScreenFadeIn();
        }
    }

    /// <summary>
    /// Change scene
    /// </summary>
    private void proceedToNextScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Checks if the inventory is full with the collectable items, if so the door will be unlocked.
    /// </summary>
    private void checkPuzzleState()
    {
        itemsCollected.Add(new GameObject());
        if (itemsCollected.Count == inventoryUI.GetItemSlots.Count)
        {
            door.tag = Tags.inspectable; 
            audioManager.PlayAudioOneShot(doorUnlockSound, 3);
        }
    }

}
