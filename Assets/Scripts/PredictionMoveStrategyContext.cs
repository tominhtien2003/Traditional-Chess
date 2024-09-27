using UnityEngine;

public class PredictionMoveStrategyContext
{
    private IPredictionMoveStrategy _strategy;

    public void SetStrategy(IPredictionMoveStrategy strategy)
    {
        _strategy = strategy;
        //Debug.Log("SetStrategy ");
    }

    public void ExecutePredictionMove(Block block)
    {
        _strategy?.PredictionMove(block);
        //Debug.Log("ExecutePredictionMove ");
    }
}
