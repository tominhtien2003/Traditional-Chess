using UnityEngine;

public class Block : BaseBlock
{
    private void Awake()
    {
        blockAnimation = GetComponent<Animator>();
    }
    private void Start()
    {
        blockState = BlockState.NORMAL;
        buttonPanel.forward = Camera.main.transform.forward;
    }
}
