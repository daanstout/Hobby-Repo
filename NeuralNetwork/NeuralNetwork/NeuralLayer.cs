using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork {
    public class NeuralLayer {
        /// <summary>
        /// The weights of the layer
        /// <para>Every column is a neuron</para>
        /// <para>Every row is weight for the connection to the previous' layer's neuron at that position</para>
        /// </summary>
        public readonly Matrix weights;
        /// <summary>
        /// The input of the layer
        /// </summary>
        private Matrix input;
        /// <summary>
        /// The output of the layer
        /// </summary>
        public Matrix output { get; private set; }

        /// <summary>
        /// How many neurons there are
        /// </summary>
        private readonly int numNeurons;
        /// <summary>
        /// How many connections each neuron has to the previous layer
        /// <para>Is the same as the number of neurons in the previous layer</para>
        /// </summary>
        public readonly int inputsPerNeuron;

        /// <summary>
        /// The bias of this layer
        /// </summary>
        private readonly float bias;

        /// <summary>
        /// Instantiates a new neural layer
        /// </summary>
        /// <param name="numNeurons">How many neurons this layer should have</param>
        /// <param name="inputsPerNeuron">How many inputs a neuron has<para>Is the same as the number of neurons in the previous layer</para></param>
        /// <param name="bias">The bias of this layer</param>
        /// <param name="weights">The weights to use for this layer<para>Keep null for random weights</para></param>
        public NeuralLayer(int numNeurons, int inputsPerNeuron, float bias, Matrix weights = null) {
            this.numNeurons = numNeurons;
            this.inputsPerNeuron = inputsPerNeuron;
            this.bias = bias;

            if (weights == null) {
                this.weights = new Matrix(this.inputsPerNeuron, this.numNeurons);
                SetWeights();
            } else
                this.weights = weights;
        }

        /// <summary>
        /// Set the weights to a random value between -1.0f and 1.0f (excluding)
        /// </summary>
        private void SetWeights() {
            Random random = new Random();

            for(int row = 0; row < inputsPerNeuron; row++) {
                for(int column = 0; column < numNeurons; column++) {
                    weights[row, column] = (float)(random.NextDouble() * 2 - 1);
                }
            }
        }

        /// <summary>
        /// Calculate this layer's output based on an input
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public Matrix Calculate(Matrix inputs) {
            input = inputs;

            if (!input.CanMultiply(weights))
                throw new ArgumentException();

            output = input * weights;

            for(int neuron = 0; neuron < numNeurons; neuron++) {
                output[0, neuron] = Sigmoid(output[0, neuron] + bias);
            }

            return output;
        }

        /// <summary>
        /// The activation function for this layer<para>This keeps the neuron level between -1.0f and 1.0f</para>
        /// </summary>
        /// <param name="input">The activation level</param>
        /// <returns>The level of the neuron</returns>
        private float Sigmoid(float input) => 1 / (1 + (float)Math.Exp(-input));
    }
}
