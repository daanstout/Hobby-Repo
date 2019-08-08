using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circuit_Builder.Wires;

namespace Circuit_Builder.Gates {
    public abstract class Gate {
        protected List<Wire> inputs;
        protected Wire[] outputs;
        protected bool state;

        protected Gate(int outputCount = 1) {
            inputs = new List<Wire>();
            outputs = new Wire[outputCount];
        }

        public virtual void Update() {
            bool newState = CalculateNewState();

            if (state == newState)
                return;

            state = newState;

            foreach (Wire wire in outputs)
                wire.Update(state);
        }

        public virtual void AddInput(Wire input) {
            if (input == null)
                return;

            if (inputs.Contains(input))
                return;

            input.AddEndpoint(this);
            inputs.Add(input);
        }

        public abstract void AddOutput(Wire output);

        protected abstract bool CalculateNewState();
    }

    public class AndGate : Gate {
        public AndGate() : base(1) { }

        protected override bool CalculateNewState() {
            foreach (Wire wire in inputs)
                if (!wire.state)
                    return false;

            return true;
        }

        public override void AddOutput(Wire output) {
            if (output == null)
                return;

            outputs[0] = output;
        }
    }

    public class OrGate : Gate {
        public OrGate() : base(1) { }

        protected override bool CalculateNewState() {
            foreach (Wire wire in inputs)
                if (wire.state)
                    return true;

            return false;
        }

        public override void AddOutput(Wire output) {
            if (output == null)
                return;

            outputs[0] = output;
        }
    }

    public class NorGate : Gate {
        public NorGate() : base(1) { }

        protected override bool CalculateNewState() {
            foreach (Wire wire in inputs)
                if (wire.state)
                    return false;

            return true;
        }

        public override void AddOutput(Wire output) {
            if (output == null)
                return;

            outputs[0] = output;
        }
    }

    public class NandGate : Gate {
        public NandGate() : base(1) { }

        protected override bool CalculateNewState() {
            foreach (Wire wire in inputs)
                if (!wire.state)
                    return true;

            return false;
        }

        public override void AddOutput(Wire output) {
            if (output == null)
                return;

            outputs[0] = output;
        }
    }

    public class InvertGate : Gate {
        public InvertGate() : base(1) { }

        protected override bool CalculateNewState() {
            if (inputs.Count == 0 || inputs[0] == null)
                return true;

            return !inputs[0].state;
        }

        public override void AddOutput(Wire output) {
            if (output == null)
                return;

            outputs[0] = output;
        }

        public override void AddInput(Wire input) {
            if (input == null)
                return;

            input.AddEndpoint(this);

            if (inputs.Count == 0) {
                inputs.Add(input);
                return;
            }

            inputs[0].RemoveEndpoint(this);
            inputs[0] = input;
        }
    }
}
