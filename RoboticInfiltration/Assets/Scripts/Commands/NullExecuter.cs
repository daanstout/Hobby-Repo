using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NullExecuter : IExecuter {
    public static readonly NullExecuter instance = new NullExecuter();

    private NullExecuter() { }

    public void Execute(RobotEntity entity) { }

    public void Finish(RobotEntity entity) { }
    public void Initiate(RobotEntity entity) { }
}
