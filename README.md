# ANN-Traffic

The problem with this program, is that the problem I use in it is too simple to need an ANN. This does not mean that the ANN won't be effective, it just means that I could have just used a basic algorithm to find the solution quicker. Remember folks, always ask yourself whether you really need machine learning. However, this program still shows off the basics of how an ANN and GA can work.

This Windows Forms program is a demonstration of an Artificial Neural Network being trained by a Genetic Algorithm.

The problem that the ANN is trying to solve is getting as many cars as possible through an intersection. It is a very basic problem and simply requires the ANN to switch direction of traffic to the axis with the most traffic.

The ANN has a fixed structure of four input nodes (one for each side of the intersection) and one output node (direction to move traffic). The nodes have a fixed value between 0 and 1 by using an activation function (Tanh). The weights between nodes of different layers are fixed between -1 and +1.

The genetic algorithm takes random pairs of genes (weights of each ANN, better scoring ones have higher change of being selected), and randomly combines them, and occasionally will mutate one.

Description of ANN Panel when running program:
-If a weight is black it is positive, if it is grey it is negative. 
-The thicker a weight is, the higher it's absolute value is.
-The values on the input nodes are from performing a logarithmic function on the amount of cars in each side of traffic.
-The output node being greater than or less than 0.5 changes which way traffic flows.
