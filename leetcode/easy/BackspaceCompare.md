### 比较含退格的字符串

URL : https://leetcode-cn.com/problems/backspace-string-compare/

给定 `S` 和` T` 两个字符串，当它们分别被输入到空白的文本编辑器后，判断二者是否相等，并返回结果。 `# `代表退格字符。

**注意**：如果对空文本输入退格字符，文本继续为空。

**示例 1：**

```reStructuredText
输入：S = "ab#c", T = "ad#c"
输出：true
解释：S 和 T 都会变成 “ac”。
```

**示例 2：**

```reStructuredText
输入：S = "ab##", T = "c#d#"
输出：true
解释：S 和 T 都会变成 “”。
```

**示例 3：**

```reStructuredText
输入：S = "a##c", T = "#a#c"
输出：true
解释：S 和 T 都会变成 “c”。
```

**示例 4：**

```reStructuredText
输入：S = "a#c", T = "b"
输出：false
解释：S 会变成 “c”，但 T 仍然是 “b”。
```



**提示：**

1. `1 <= S.length <= 200`
2. `1 <= T.length <= 200`
3. `S` 和 `T` 只含有小写字母以及字符 `'#'`。



### 情景扩展

要求编写一个指令过滤器，业务情景：在同一帧内会被添加若干指令，其中分为 执行类、撤销类。在下一帧会执行指令缓冲，要求指令缓冲中都为有效执行类指令。