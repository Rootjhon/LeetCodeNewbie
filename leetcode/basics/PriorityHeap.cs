using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public sealed class PriorityHeap<T>
{
    #region [Enum]
    public enum HeapType { Max, Min }
    #endregion

    #region [Fields]
    private const int _DefaultCapacity = 4;

    private List<T> _Vals;
    private List<int> _Vals_Priority;

    private Func<int, int, bool> _LessOrEqual;

    public int Count => _Vals.Count;
    #endregion

    #region [Construct]
    public PriorityHeap(HeapType varType) : this(_DefaultCapacity, varType) { }
    public PriorityHeap(int varCapacity, HeapType varType)
    {
        if (varType == HeapType.Min)
        {
            _LessOrEqual = LessOrEqual;
        }
        else
        {
            _LessOrEqual = MoreOrEqual;
        }
        _Vals = new List<T>(varCapacity);
        _Vals_Priority = new List<int>(varCapacity);
    }
    private bool LessOrEqual(int varParent, int varCurrent) => varParent <= varCurrent;
    private bool MoreOrEqual(int varParent, int varCurrent) => varParent >= varCurrent;
    #endregion

    #region [API]
    public T PeekTop() => _Vals.Count == 0 ? default(T) : _Vals[0];
    public T ExtractTop()
    {
        if (_Vals.Count == 0) return default(T);
        var tempOp = _Vals[0];

        var tempLastIdx = _Vals.Count - 1;
        if (tempLastIdx != 0) Swap(0, tempLastIdx);
        _Vals.RemoveAt(tempLastIdx);
        _Vals_Priority.RemoveAt(tempLastIdx);

        FloatDownHeap();

        return tempOp;
    }
    public void Inster(T varVal, int varPriority)
    {
        _Vals.Add(varVal);
        _Vals_Priority.Add(varPriority);
        FloatUpHeap();
    }
    #endregion

    #region [Business]
    private void FloatDownHeap()
    {
        if (_Vals_Priority.Count == 0) return;

        var tempCurIdx = 0;
        while (true)
        {
            var tempParentVal = _Vals_Priority[tempCurIdx];

            var tempChild_L = tempCurIdx * 2 + 1;
            if (tempChild_L >= _Vals_Priority.Count) break;
            var tempChild_L_Val = _Vals_Priority[tempChild_L];

            var tempChild_R = tempCurIdx * 2 + 2;
            if (tempChild_R >= _Vals_Priority.Count)
            {
                if (!_LessOrEqual(tempParentVal, tempChild_L_Val))
                {
                    Swap(tempCurIdx, tempChild_L);
                }
                break;
            }
            else
            {
                var tempChild_R_Val = _Vals_Priority[tempChild_R];

                if (_LessOrEqual(tempChild_L_Val, tempChild_R_Val))
                {
                    if (_LessOrEqual(tempParentVal, tempChild_L_Val))
                    {
                        break;
                    }
                    else
                    {
                        Swap(tempCurIdx, tempChild_L);
                        tempCurIdx = tempChild_L;
                    }
                }
                else
                {
                    if (_LessOrEqual(tempParentVal, tempChild_R_Val))
                    {
                        break;
                    }
                    else
                    {
                        Swap(tempCurIdx, tempChild_R);
                        tempCurIdx = tempChild_R;
                    }
                }
            }

        }
    }
    private void FloatUpHeap()
    {
        var tempCurIdx = _Vals_Priority.Count - 1;
        var tempCurVal = _Vals_Priority[tempCurIdx];
        while (true)
        {
            var tempParentIdx = (tempCurIdx - 1) / 2;
            var tempPraentVal = _Vals_Priority[tempParentIdx];
            if (!_LessOrEqual(tempPraentVal, tempCurVal))
            {
                Swap(tempParentIdx, tempCurIdx);
                tempCurIdx = tempParentIdx;
                continue;
            }
            break;
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Swap(int varA_Idx, int varB_Idx)
    {
        var temp_P = _Vals_Priority[varA_Idx];
        _Vals_Priority[varA_Idx] = _Vals_Priority[varB_Idx];
        _Vals_Priority[varB_Idx] = temp_P;

        var temp_V = _Vals[varA_Idx];
        _Vals[varA_Idx] = _Vals[varB_Idx];
        _Vals[varB_Idx] = temp_V;
    }
    #endregion
}