using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField] private List<AnimationClip> flowerClips;
    private Animator flowerAnimator;
    private int randomClipIndex;

    private void Awake()
    {
        flowerAnimator = GetComponent<Animator>();
        randomClipIndex = Random.Range(0, flowerClips.Count);
    }
    private void Start()
    {
        flowerAnimator.Play(flowerClips[randomClipIndex].name);
    }
}
