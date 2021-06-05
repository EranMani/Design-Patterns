using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameObject actor;
    Animator _anim;
    Command keyQ, keyW, keyE, upArrow;

    Coroutine replayCoroutine;
    bool shouldStartReplay;
    bool isReplaying;

    List<Command> oldCommands = new List<Command>();

    // Start is called before the first frame update
    void Start()
    {
        keyQ = new PerformJump();
        keyW = new PerformPunchAttack();
        keyE = new PerformKickAttack();
        upArrow = new MoveForward();
        _anim = actor.GetComponent<Animator>();
        Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there a replay corotuine active
        if (!isReplaying)
        {
            HandleInput();
        }

        // Start replay coroutine by pressing a button at the handle input function
        StartReplay();      
    }

    private void StartReplay()
    {
        if (shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;

            // If there is a coroutine being played, then stop it
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    private IEnumerator ReplayCommands()
    {
        isReplaying = true;

        for (int i = 0; i < oldCommands.Count; i++)
        {
            oldCommands[i].Execute(_anim, true);
            yield return new WaitForSeconds(1f);
        }

        isReplaying = false;
    }

    void UndoLastCommand()
    {
        if (oldCommands.Count > 0)
        {
            Command c = oldCommands[oldCommands.Count - 1];
            c.Execute(_anim, false);
            oldCommands.RemoveAt(oldCommands.Count - 1);
        }      
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            keyQ.Execute(_anim, true);
            oldCommands.Add(keyQ);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyW.Execute(_anim, true);
            oldCommands.Add(keyW);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            keyE.Execute(_anim, true);
            oldCommands.Add(keyE);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            upArrow.Execute(_anim, true);
            oldCommands.Add(upArrow);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shouldStartReplay = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }
}
