using System;
using System.Text;

namespace leetcode
{
    /// <summary>
    /// URL:https://leetcode-cn.com/problems/remove-outermost-parentheses/
    /// 
    /// 有效括号字符串为空 ("")、"(" + A + ")" 或 A + B，其中 A和 B 都是有效的括号字符串，+ 代表字符串的连接。
    /// 例如，""，"()"，"(())()" 和 "(()(()))" 都是有效的括号字符串。
    /// 
    /// 如果有效字符串 S 非空，且不存在将其拆分为 S = A+B 的方法，我们称其为原语（primitive），其中 A 和 B 都是非空有效括号字符串。
    /// 给出一个非空有效字符串 S，考虑将其进行原语化分解，使得：S = P_1 + P_2 + ... + P_k，其中 P_i 是有效括号字符串原语。
    /// 对 S 进行原语化分解，删除分解中每个原语字符串的最外层括号，返回 S 。
    /// 
    /// 示例 1：
    ///     输入："(()())(())"
    ///     输出："()()()"
    /// 解释：
    ///     输入字符串为 "(()())(())"，原语化分解得到 "(()())" + "(())"，
    ///     删除每个部分中的最外层括号后得到 "()()" + "()" = "()()()"。
    ///    
    /// 示例 2：
    ///     输入："(()())(())(()(()))"
    ///     输出："()()()()(())"
    /// 解释：
    ///     输入字符串为 "(()())(())(()(()))"，原语化分解得到 "(()())" + "(())" + "(()(()))"，
    ///     删除每个部分中的最外层括号后得到 "()()" + "()" + "()(())" = "()()()()(())"。
    ///
    /// 示例 3：
    ///     输入："()()"
    ///     输出：""
    /// 解释：
    ///     输入字符串为 "()()"，原语化分解得到 "()" + "()"，
    ///     删除每个部分中的最外层括号后得到 "" + "" = ""。
    ///  
    /// 提示：
    ///     1. S.length <= 10000
    ///     2. S[i] 为 "(" 或 ")"
    ///     3. S 是一个有效括号字符串
    /// </summary>
    public partial class Solution
    {
        public string RemoveOuterParentheses_v1(string S)
        {
            const char tempRChar = ')';

            var tempLIdx = 0;
            var tempLCount = 1;
            
            for (int iC = 1; iC < S.Length; ++iC)
            {
                var tempC = S[iC];
                if (tempC != tempRChar)
                {
                    tempLCount++;
                    continue;
                }

                if (--tempLCount != 0) continue;

                S = S.Remove(tempLIdx, 1).Remove(--iC, 1);
                tempLIdx = iC + 1;
                tempLCount = 1;
            }
            return S;
        }

        public string RemoveOuterParentheses_v2(string S)
        {
            var s = new StringBuilder();

            var level = 0;

            foreach (var item in S.ToCharArray())
            {
                if (item == ')') --level;
                if (level >= 1) s.Append(item);
                if (item == '(') ++level;
            }

            return s.ToString();
        }
    }
}