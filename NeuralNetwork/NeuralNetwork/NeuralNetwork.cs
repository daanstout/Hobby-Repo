using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork {
    /// <summary>
    /// A neural network that can parse input
    /// </summary>
    public class NeuralNetwork {
        /// <summary>
        /// The number of hidden layers in the neural network
        /// </summary>
        private readonly int numHiddenLayers;

        /// <summary>
        /// The hidden layers in the neural network
        /// </summary>
        private readonly NeuralLayer[] hiddenLayers;

        /// <summary>
        /// The output layer of the neural network
        /// </summary>
        private readonly NeuralLayer outputLayer;

        public readonly float learningRate;

        /// <summary>
        /// Instantiates a new Neural Network
        /// </summary>
        /// <param name="numInputLayers">The number of input neurons the neural network has</param>
        /// <param name="hiddenLayers">The hiddenlayers of the neural network<para>Each int corresponds to how many neurons that layer has</para></param>
        /// <param name="hiddenBias">The bias of the hidden layers<para>bias [i] corresponds to hidden layer [i]</para></param>
        /// <param name="numOutputNeurons">The number of output neurons the neural network has</param>
        /// <param name="outputBias">The bias of the output layer</param>
        /// <param name="hiddenWeights">The weights to use for the hidden layers, keep empty for random values</param>
        /// <param name="outputWeights">The weights to use for the output layers, keep empty for random values</param>
        public NeuralNetwork(int numInputLayers, int[] hiddenLayers, int numOutputNeurons, float learningRate = 1.0f, float[] hiddenBias = null, float outputBias = 1.0f, Matrix[] hiddenWeights = null, Matrix outputWeights = null) {
            numHiddenLayers = hiddenLayers.Length;
            this.learningRate = learningRate;

            this.hiddenLayers = new NeuralLayer[numHiddenLayers];

            int previousNeurons = numInputLayers;

            for (int i = 0; i < hiddenLayers.Length; i++) {
                float bias = hiddenBias == null ? 1.0f : hiddenBias[i];
                Matrix weights = hiddenWeights?[i];

                this.hiddenLayers[i] = new NeuralLayer(hiddenLayers[i], previousNeurons, bias, weights);

                previousNeurons = hiddenLayers[i];
            }

            if (outputWeights == null)
                outputLayer = new NeuralLayer(numOutputNeurons, previousNeurons, outputBias);
            else
                outputLayer = new NeuralLayer(numOutputNeurons, previousNeurons, outputBias, outputWeights);
        }

        /// <summary>
        /// Calculates the output of a certain input
        /// </summary>
        /// <param name="input">The numbers for the input layer</param>
        /// <returns>A Matrix that is 1x(Number of output neurons) with the result</returns>
        public Matrix Calculate(float[] input) {
            NeuralLayer nextLayer = hiddenLayers.Length > 0 ? hiddenLayers[0] : outputLayer;

            if (input.Length != nextLayer.inputsPerNeuron)
                throw new ArgumentException("There are to " + (input.Length > nextLayer.inputsPerNeuron ? "many" : "few") + " inputs for the next layer to handle");

            Matrix result = (Matrix)input;

            for (int i = 0; i < numHiddenLayers; i++) {
                result = hiddenLayers[i].Calculate(result);
            }

            return outputLayer.Calculate(result);
        }

        public float GetTotalError(float[] ideal) {
            float[] actual = (float[])outputLayer.output;

            float totalError = 0.0f;

            for(int i = 0; i < ideal.Length; i++) {
                totalError += 0.5f * (ideal[i] - actual[i]) * (ideal[i] - actual[i]);
            }

            return totalError;
        }

        public void BackPropogation(float[] ideal) {
            float totalError = GetTotalError(ideal);
            float[] actual = (float[])outputLayer.output;

            float totalErrorDivOut1 = -(ideal[0] - actual[0]);
            float difOut1DivNetOut1 = actual[0] * (1 - actual[0]);
            float netOut1DivWeight5 = ((float[])hiddenLayers[0].output)[0];

            float totalErrorDivWeight5 = totalErrorDivOut1 * difOut1DivNetOut1 * netOut1DivWeight5;

            float deltaOut1 = -(ideal[0] - actual[0]) * actual[0] * (1 - actual[0]);
            float totalErrorDivWeight5_Alt = deltaOut1 * ((float[])hiddenLayers[0].output)[0];

            float weight5New = outputLayer.weights[0, 0] - learningRate * totalErrorDivWeight5_Alt;

            float totalErrorDivWeight6 = deltaOut1 * ((float[])hiddenLayers[0].output)[1];

            float weight6New = outputLayer.weights[1, 0] - learningRate * totalErrorDivWeight6;

            float deltaOut2 = -(ideal[1] - actual[1]) * actual[1] * (1 - actual[1]);

        }
    }
}
