using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public interface IExecuter {
    void Initiate(RobotEntity entity);
    void Execute(RobotEntity entity);
    void Finish(RobotEntity entity);
}
