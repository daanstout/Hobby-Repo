using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

public class ParseExecuter : IExecuter {
    public static readonly ParseExecuter instance = new ParseExecuter();

    private ParseExecuter() { }

    public void Execute(RobotEntity owner) {
        var command = owner.GetCommand();

        var splitCommand = command.Split(' ');

        if (splitCommand[0] == Commands.HALT_COMMAND && splitCommand.Length >= Commands.HALT_ARGUMENT_COUNT + 1) {
            owner.SetExecuter(NullExecuter.instance);
        } else if (splitCommand[0] == Commands.TIMED_MOVE_FORWARD_COMMAND && splitCommand.Length >= Commands.TIMED_MOVE_FORWARD_ARGUMENT_COUNT) {
            var newCommand = new TimedMoveExecuter();

            if (!float.TryParse(splitCommand[1], out float res))
                return;

            newCommand.remainingTime = res;

            owner.SetExecuter(newCommand);
        } else if (splitCommand[0] == Commands.DISTANCE_MOVE_FORWARD_COMMAND && splitCommand.Length >= Commands.DISTANCE_MOVE_FORWARD_ARGUMENT_COUNT) {
            var newCommand = new DistanceMoveExecuter();

            if (!float.TryParse(splitCommand[1], out float res))
                return;

            newCommand.distance = res;

            owner.SetExecuter(newCommand);
        } else if (splitCommand[0] == Commands.ROTATE_LEFT_COMMAND && splitCommand.Length >= Commands.ROTATE_LEFT_ARGUMENT_COUNT) {
            var newCommand = new RotateExecuter {
                degrees = 360 - (Convert.ToInt32(splitCommand[1]) % 360)
            };

            Debug.Log(newCommand.degrees);

            owner.SetExecuter(newCommand);
        } else if (splitCommand[0] == Commands.ROTATE_RIGHT_COMMAND && splitCommand.Length >= Commands.ROTATE_RIGHT_ARGUMENT_COUNT) {
            var newCommand = new RotateExecuter {
                degrees = Convert.ToInt32(splitCommand[1]) % 360
            };

            owner.SetExecuter(newCommand);
        } else if(splitCommand[0] == Commands.WAIT_COMMAND && splitCommand.Length >= Commands.WAIT_ARGUMENT_COUNT) {
            var newCommand = new WaitExecuter();

            if (!float.TryParse(splitCommand[1], out float res))
                return;

            newCommand.waitDuration = res;

            owner.SetExecuter(newCommand);
        }
    }

    public void Finish(RobotEntity entity) { }
    public void Initiate(RobotEntity entity) { }
}
