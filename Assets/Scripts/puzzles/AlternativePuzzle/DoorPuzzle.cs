using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  Door unlock sound --
 * 
 *  Random voice audio
 * 
 *  Kerntaken documenten
 * 

 * */

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
    /// Reference to the MenuOptions script to use the "goToMainMenu" function.
    /// </summary>
    private MenuOptions menu;

    /// <summary>
    /// Reference to the audiomanager script to play audio files.
    /// </summary>
    private AudioManager audioManager;

    private void Start()
    {
        door = this.gameObject;

        inventoryUI = GameObject.FindObjectOfType<InventoryUI>();
        inventoryUI.InventoryStatus += checkPuzzleState;

        inspect = GameObject.FindObjectOfType<Inspect>();
        inspect.InspectingObjectEvent += unlockDoor;

        menu = GameObject.FindObjectOfType<MenuOptions>();

        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void unlockDoor(GameObject obj)
    {
        if (obj.name == door.name)
        { 
            menu.goToMainMenu();
            return;
        }
    }

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
