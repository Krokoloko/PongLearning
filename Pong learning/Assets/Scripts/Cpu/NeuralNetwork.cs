using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    class NN
    {
        class Neuron
        {
            public Neuron[] Neighbours
            {
                get
                {
                    return Neighbours;
                }
                set
                {
                    Neighbours = Neighbours;
                }
            }

            public float Frequency {
                get
                {
                    return Frequency;
                }
                set
                {
                    Frequency = value;
                }
            }

            public Neuron(){}
            public Neuron(Neuron[] adjecents)
            {
                Neighbours = adjecents;
            }
        }
        private Neuron[] Network;
        private Neuron Output;
        public NN(int neurons)
        {
            Network = new Neuron[neurons];
            Output = new Neuron();
        }

        public Neuron GetOutPut()
        {
           
        }

        
        
    }
}

