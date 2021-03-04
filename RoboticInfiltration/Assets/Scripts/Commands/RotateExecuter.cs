using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class RotateExecuter : IExecuter {
    public int degrees;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float turnDuration;
    private float turnTimer = 0.0f;

    public void Execute(RobotEntity entity) {
        turnTimer += Time.deltaTime;
        entity.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, turnTimer / turnDuration);

        if (turnTimer >= turnDuration)
            entity.SetExecuter(ParseExecuter.instance);
    }

    public void Finish(RobotEntity entity) { }
    public void Initiate(RobotEntity entity) {
        initialRotation = entity.transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0.0f, degrees, 0.0f);
        turnDuration = degrees / entity.rotationSpeed;
    }
}
