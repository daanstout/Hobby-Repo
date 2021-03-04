using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RobotEntity : MonoBehaviour {
    private IExecuter executer = NullExecuter.instance;
    [SerializeField]
    private string[] commands;
    private int currentCommandIndex = 0;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 90.0f;

    public event Action OnCollision;

    private void Update() {
        executer.Execute(this);

        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    executer = ParseExecuter.instance;
        //    currentCommandIndex = 0;
        //}
    }

    public string PeekCommand() {
        return commands[currentCommandIndex];
    }

    public string GetCommand() {
        if (currentCommandIndex >= commands.Length)
            currentCommandIndex = 0;

        currentCommandIndex++;
        return commands[currentCommandIndex - 1];
    }

    public void SetCommands(string[] commands) {
        this.commands = commands;
        currentCommandIndex = 0;
    }

    public void Restart() {
        executer = ParseExecuter.instance;
        currentCommandIndex = 0;
    }

    public void SetExecuter(IExecuter executer) {
        this.executer.Finish(this);
        this.executer = executer;
        this.executer.Initiate(this);
    }

    public void MoveForward() {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        OnCollision?.Invoke();
    }
}
