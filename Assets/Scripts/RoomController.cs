﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    [SerializeField]
    private string startingDialogue;
    [SerializeField]
    private int remainingInteractables;
    [SerializeField]
    private string endingDialogue;
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private DialogueController dialogueController;

    private bool isEnding = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunStartingDialogueAfterDelay(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnding && remainingInteractables == 0 && dialogueController.Done)
        {
            StartCoroutine(RunEndingDialogueAfterDelay(1));
        }
        else if (isEnding && dialogueController.Done)
        {
            StartCoroutine(MoveToNextRoomAfterDelay(1));
        }
    }

    public void InteractableClicked(string dialogueName)
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        clickedButton.GetComponent<Button>().interactable = false;
        clickedButton.GetComponent<Interactable>().InteractedWith();
        dialogueController.StartDialogue(dialogueName);
        remainingInteractables -= 1;
    }

    IEnumerator RunStartingDialogueAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        if (!string.IsNullOrWhiteSpace(startingDialogue))
            dialogueController.StartDialogue(startingDialogue);
    }

    IEnumerator RunEndingDialogueAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        isEnding = true;
        if (!string.IsNullOrWhiteSpace(endingDialogue))
            dialogueController.StartDialogue(endingDialogue);
    }

    IEnumerator MoveToNextRoomAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        if (!string.IsNullOrWhiteSpace(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }
}