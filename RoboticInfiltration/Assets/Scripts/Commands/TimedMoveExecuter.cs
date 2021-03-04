using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class TimedMoveExecuter : IExecuter {
    public float remainingTime;

    public void Execute(RobotEntity owner) {
        owner.MoveForward();

        remainingTime -= Time.deltaTime;

        if (remainingTime < 0)
            owner.SetExecuter(ParseExecuter.instance);
    }

    public void Finish(RobotEntity entity) {
        entity.OnCollision -= () => entity.SetExecuter(ParseExecuter.instance);
    }
    public void Initiate(RobotEntity entity) {
        entity.OnCollision += () => entity.SetExecuter(ParseExecuter.instance);
    }
}
