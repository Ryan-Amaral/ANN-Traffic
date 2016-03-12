# ANN-Traffic

This Windows Forms program is a demonstration of an Artificial Neural Network being trained by a Genetic Algorithm.

The problem that the ANN is trying to solve is getting as many cars as possible through an intersection. It is a very basic problem and simply requires the ANN to switch direction of traffic to the axis with the most traffic.

The ANN has a fixed structure of four input nodes (one for each side of the intersection) and one output node (direction to move traffic). The nodes have a fixed value between 0 and 1 by using an activation function (Tanh). The weights between nodes of different layers are fixed between -1 and +1. The output node has a bias of between -4 and +4 to move the activation function to the extremes if needed.

The genetic algorithm takes random pairs of genes (weights of each ANN, better scoring ones have higher change of being selected), and randomly combines them, and occasionally will mutate one.
