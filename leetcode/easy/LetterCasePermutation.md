### 字母大小写全排列

URL: https://leetcode-cn.com/problems/letter-case-permutation/

给定一个字符串`S`，通过将字符串`S`中的每个字母转变大小写，我们可以获得一个新的字符串。返回所有可能得到的字符串集合。

```reStructuredText
示例:
输入: S = "a1b2"
输出: ["a1b2", "a1B2", "A1b2", "A1B2"]

输入: S = "3z4"
输出: ["3z4", "3Z4"]

输入: S = "12345"
输出: ["12345"]
```

**注意：**

- `S` 的长度不超过`12`。
- `S` 仅由数字和字母组成。



### 题解

思路  - 1

从左往右依次遍历字符，过程中保持 ans 为已遍历过字符的字母大小全排列。

例如，当 `S = "abc"` 时，考虑字母 `"a", "b", "c"`，初始令 `ans = [""]`，依次更新` ans = ["a", "A"]， ans = ["ab", "Ab", "aB", "AB"]`， `ans = ["abc", "Abc", "aBc", "ABc", "abC", "AbC", "aBC", "ABC"]。`

思路 - 2

假设字符串 S 有 **B** 个字母，那么全排列就有 `$ 2^B $`个字符串，且可以用位掩码 bits 唯一地表示。

例如，可以用 00 表示 a7b， 01 表示 a7B， 10 表示 A7b， 11 表示 A7B。注意数字不是掩码的一部分。
