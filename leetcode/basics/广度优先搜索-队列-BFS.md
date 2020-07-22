### 队列和 BFS

广度优先搜索（BFS）的一个常见应用是找出从根结点到目标结点的最短路径。

使用 BFS 的两个主要方案：**遍历 **或 **找出最短路径**



![U7xc5j.gif](https://s1.ax1x.com/2020/07/22/U7xc5j.gif) 



> 在特定问题中执行 BFS 之前确定结点和边缘非常重要。通常，结点将是实际结点或是状态，而边缘将是实际边缘或可能的转换。

### 伪代码模版

- 存在多次访问同一节点的情况

```c
/**
 * Return the length of the shortest path between root and target node.
 */
int BFS(Node root, Node target) {
    Queue<Node> queue;  // store all nodes which are waiting to be processed
    int step = 0;       // number of steps neeeded from root to current node
    // initialize
    add root to queue;
    // BFS
    while (queue is not empty) {
        step = step + 1;
        // iterate the nodes which are already in the queue
        int size = queue.size();
        for (int i = 0; i < size; ++i) {
            Node cur = the first node in queue;
            return step if cur is target;
            for (Node next : the neighbors of cur) {
                add next to queue;
            }
            remove the first node from queue;
        }
    }
    return -1;          // there is no path from root to target
}
```

> 1. 如代码所示，在每一轮中，队列中的结点是 **等待处理的结点** 。
>
> 2. 在每个更外一层的 `while` 循环之后，我们 **距离根结点更远一步** 。变量 `step` 指示从根结点到我们正在访问的当前结点的距离。



- isted 标识，避免多次访问同节点 *(这里采用HashSet)*

```c
/**
 * Return the length of the shortest path between root and target node.
 */
int BFS(Node root, Node target) {
    Queue<Node> queue;  // store all nodes which are waiting to be processed
    Set<Node> used;     // store all the used nodes
    int step = 0;       // number of steps neeeded from root to current node
    // initialize
    add root to queue;
    add root to used;
    // BFS
    while (queue is not empty) {
        step = step + 1;
        // iterate the nodes which are already in the queue
        int size = queue.size();
        for (int i = 0; i < size; ++i) {
            Node cur = the first node in queue;
            return step if cur is target;
            for (Node next : the neighbors of cur) {
                if (next is not in used) {
                    add next to queue;
                    add next to used;
                }
            }
            remove the first node from queue;
        }
    }
    return -1;          // there is no path from root to target
}
```



有两种情况你不需要使用哈希集：

1. 你完全确定没有循环，例如，在树遍历中；
2. 你确实希望多次将结点添加到队列中。