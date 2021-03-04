using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Commands {
    public const string HALT_COMMAND = "hlt";
    public const int HALT_ARGUMENT_COUNT = 0;
    public const string TIMED_MOVE_FORWARD_COMMAND = "move_t";
    public const int TIMED_MOVE_FORWARD_ARGUMENT_COUNT = 1;
    public const string DISTANCE_MOVE_FORWARD_COMMAND = "move_d";
    public const int DISTANCE_MOVE_FORWARD_ARGUMENT_COUNT = 1;
    public const string ROTATE_LEFT_COMMAND = "turn_l";
    public const int ROTATE_LEFT_ARGUMENT_COUNT = 1;
    public const string ROTATE_RIGHT_COMMAND = "turn_r";
    public const int ROTATE_RIGHT_ARGUMENT_COUNT = 1;
    public const string WAIT_COMMAND = "wait";
    public const int WAIT_ARGUMENT_COUNT = 1;
}
