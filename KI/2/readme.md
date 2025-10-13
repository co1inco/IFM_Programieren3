
# Depth-First-Search (DFS)
Check child childs first
* Ignores path costs
* Does not require queue

1. Begin with initial Node
2. Mark Node as Visited (only graph search)
3. Is Node the searched Node -> return
4. Go through each child node that is not visited and do Step 2


# Breath-First-Search
Check childs first. Then their childs
* Ignores path costs
* Requires queue


1. Add Initial node to a queue
2. Pop node from queue
3. Mark node as visited (only graph search)
4. Is Node the searched Node -> return
5. Add unvisited children to queue
6. Repeat from 2 until queue is empty

The child nodes are added to the end of the queue.
This way the graph is processed "flat" or when looking at the tree representation, the three is searched layer by layer


# Branch-and-Bound
Similar to Breath first, except that a Priority queue is used.
A branch is added with the cost of the path to the node.

Repeat detection, check if the node was already added with lower path cost?


# Best-First
Works like Branch-and-Bound except that the path remaining cost to the target node is used as priority.
The remaining cost must be somehow estimated.

Calculating the actual Path cost from the target would only make sense if this node is search for from different nodes. 
This also only works if the data structur allows access to the "parent" nodes.
