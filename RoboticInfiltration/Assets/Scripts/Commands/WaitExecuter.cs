using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class WaitExecuter : IExecuter {
    public float waitDuration;
    public void Execute(RobotEntity entity) {
        waitDuration -= Time.deltaTime;

        if (waitDuration <= 0)
            entity.SetExecuter(ParseExecuter.instance);
    }
    public void Finish(RobotEntity entity) { }
    public void Initiate(RobotEntity entity) { }
}
