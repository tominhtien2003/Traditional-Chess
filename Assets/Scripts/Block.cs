using System;
using UnityEngine;

public class Block : BaseBlock
{
    private void Awake()
    {
        blockAnimation = GetComponent<Animator>();

        board = GetComponentInParent<Board>();
    }
    private void Start()
    {
        blockState = BlockState.NORMAL;
    }
}
