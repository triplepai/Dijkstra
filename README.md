# Dijkstra algorithm C#

![](image/sample.JPG)

I learn and wrote the code via this link
https://www.youtube.com/watch?v=pVfj6mxhdMw 


Sample step of Dijkstra algorithm

1. Set up the node and weight of each connection node
2. Create a table to record lowest weight of each node and set lowest weight to infinite except start node = 0
3. Set all node in unvisited list
4. Loop all connected node of current/start node by start at lowest weight connected node first
5. Connected node must not be visited node
6. If table record of this connected node have lowest weight more than current node (weight) + this connected node (weight)
then update the lowest weight
7. Set current node to visited node
9. Set next current node by choosing lowest weight connected node of current node
10. If still have unvisited node then goto 4.
