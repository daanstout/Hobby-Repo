using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class DistanceMoveExecuter : IExecuter {
    private Vector3 startPos;

    public float distance;

    public void Execute(RobotEntity entity) {
        entity.MoveForward();

        if (Vector3.Distance(startPos, entity.transform.position) >= distance)
            entity.SetExecuter(ParseExecuter.instance);
    }
    public void Finish(RobotEntity entity) {
        entity.OnCollision -= () => entity.SetExecuter(ParseExecuter.instance);
    }
    public void Initiate(RobotEntity entity) {
        startPos = entity.transform.position;
        entity.OnCollision += () => entity.SetExecuter(ParseExecuter.instance);
    }
}
