using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

    private Renderer renderer;
    private Animator animator;

    public void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
        bolaRig.velocity *= multiplier;

        //animasi
        animator.SetTrigger("hit");

        //playSFX
        audioManager.PlaySFX(collision.transform.position);

        //playVFX
        vfxManager.PlayVFX(collision.transform.position);

        //score add
        scoreManager.AddScore(score);
    }
}
