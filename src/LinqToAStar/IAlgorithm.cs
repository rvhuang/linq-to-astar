using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LinqToAStar
{
    [ComVisible(true)]
    public interface IAlgorithm
    {
        string AlgorithmName { get; }

        Node<TFactor, TStep> Run<TFactor, TStep>(HeuristicSearchBase<TFactor, TStep> source);
    }
}