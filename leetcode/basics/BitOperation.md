# 位运算技巧

## 字符相关


### 利用  按位或` |` 和 空格 将英文字符转换为 小写

```c
('a' | ' ') = 'a'
('A' | ' ') = 'a'
```

```reStructuredText
a = 0110 0001   a ~ z = 97 ~ 122

A = 0100 0001    A ~ Z = 65 ~ 90

space = 0010 0000   = 32

本质上是利用 等差间隔 32 = 2 ^ 5
```

**相同位只要一个为1即为1。**

----

### 利用 按位与 & 和 下划线 将英文转化为 大写

```c
('b' & '_') = 'B'
('B' & '_') = 'B'
```

```reStructuredText
_ = 0101 1111 = 95
```

**相同位的两个数字都为1，则为1；若有一个不为1，则为0。**

---

### 利用 按位异或 和 空格 将英文 大小写反转

```c
('d' & ' ') = 'D'
('d' & ' ') = 'd'
```

---

## 数值类




