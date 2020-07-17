

### 环形链表 II

URL : https://leetcode-cn.com/problems/linked-list-cycle-ii/

给定一个链表，返回链表开始入环的第一个节点。 如果链表无环，则返回 null。

为了表示给定链表中的环，我们使用整数 pos 来表示链表尾连接到链表中的位置（索引从 0 开始）。 如果 pos 是 -1，则在该链表中没有环。

**说明：**不允许修改给定的链表。

**示例 1：**

```reStructuredText
输入：head = [3,2,0,-4], pos = 1
输出：tail connects to node index 1
解释：链表中有一个环，其尾部连接到第二个节点。
```

![img](https://assets.leetcode-cn.com/aliyun-lc-upload/uploads/2018/12/07/circularlinkedlist.png) 

**示例 2：**

```reStructuredText
输入：head = [1,2], pos = 0
输出：tail connects to node index 0
解释：链表中有一个环，其尾部连接到第一个节点。
```

![img](https://assets.leetcode-cn.com/aliyun-lc-upload/uploads/2018/12/07/circularlinkedlist_test2.png) 

**示例 3：**

```reStructuredText
输入：head = [1], pos = -1
输出：no cycle
解释：链表中没有环。
```

![img](https://assets.leetcode-cn.com/aliyun-lc-upload/uploads/2018/12/07/circularlinkedlist_test3.png) 



**进阶：**

你是否可以不用额外空间解决此题？



### 题解

#### **HashSet** 

> 常规暴力解法

#### **Floyd 算法**

> 追及问题

想象一下，两个人在圆形操场，A走路，B跑步，那么B与A会在某一时刻再次相遇。

因此，问题分解为两步

		 - 环的判断
		 - 环的入口

<img src="https://pic.leetcode-cn.com/ea37804a3d86a51a1bf827b9068e1f515ffddf840a0563ea0d1174c58ac64352-image.png" style="zoom:50%;" /> 

给定阶段 1 找到的相遇点，阶段 2 将找到环的入口。首先我们初始化额外的两个指针： ptr1 ，指向链表的头， ptr2 指向相遇点。然后，我们每次将它们往前移动一步，直到它们相遇，它们相遇的点就是环的入口，返回这个节点。

<img src="https://pic.leetcode-cn.com/99987d4e679fdfbcfd206a4429d9b076b46ad09bd2670f886703fb35ef130635-image.png" style="zoom:50%;" /> 

我们利用已知的条件：慢指针移动 1 步，快指针移动 2 步，来说明它们相遇在环的入口处。（下面证明中的 tortoise 表示慢指针，hare 表示快指针）

![UySDEQ.png](https://s1.ax1x.com/2020/07/17/UySDEQ.png) 



![UySOKK.gif](https://s1.ax1x.com/2020/07/17/UySOKK.gif) 

