using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circuit_Builder.Gates;

namespace Circuit_Builder.Wires {
    public class Wire {
        List<Gate> endPoints;
        List<Wire> connections;
        public bool state;

        public Wire() {
            endPoints = new List<Gate>();
            connections = new List<Wire>();
            state = false;
        }

        public void Update(bool newState) {
            if (state == newState)
                return;

            state = newState;

            foreach (Wire connection in connections)
                connection.Update(state);

            foreach (Gate gate in endPoints)
                gate.Update();
        }

        public void AddEndpoint(Gate endPoint) {
            if (endPoint == null)
                return;

            if (endPoints.Contains(endPoint))
                return;

            endPoints.Add(endPoint);
        }

        public void RemoveEndpoint(Gate endPoint) {
            if (endPoint == null)
                return;

            endPoints.Remove(endPoint);
        }
    }
}
