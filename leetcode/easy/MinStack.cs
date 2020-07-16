#define V1

using System.Collections.Generic;

public sealed class MinStack
{
    #region [Fields]
    private Stack<int> _rawStack;
    private Stack<int> _assistStack;
    #endregion

    #region [Construct]
    /** initialize your data structure here. */
    public MinStack()
    {
        _rawStack = new Stack<int>();
        _assistStack = new Stack<int>();
    }
    #endregion

    #region [API]
    public void Push(int x)
    {
        _rawStack.Push(x);
        if (_assistStack.Count != 0)
        {
            var tempMin = _assistStack.Peek();
            _assistStack.Push(tempMin < x ? tempMin : x);
        }
        else
        {
            _assistStack.Push(x);
        }
    }

    public void Pop()
    {
        _rawStack.Pop();
        _assistStack.Pop();
    }

    public int Top()
    {
        return _rawStack.Peek();
    }

    public int GetMin()
    {
        return _assistStack.Peek();
    }
    #endregion
}