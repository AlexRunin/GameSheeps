using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/AudioManager")] //Создаем меню для Unity
public class SoundManager : ScriptableObject
{
    [SerializeField] private AudioClip shootClip; // выстрел
    [SerializeField] private AudioClip sheepHitClip; // поподание овцы в сено
    [SerializeField] private AudioClip sheepDropClip; // поподание овечки в ад
    [SerializeField] private AudioClip motor;
    [SerializeField] private AudioClip arrow;

    [SerializeField] private Vector3 cameraPosition;

    private void PlaySound(AudioClip audioClip)
    {
       // cameraPosition = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(audioClip, cameraPosition);
    }
    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }
    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }
    public void PlayDropClip()
    {
        PlaySound(sheepDropClip);
    }
    public void PlayArrow()
    {
        PlaySound(arrow);
    }
    public void PlayMotor()    
    {
        PlaySound(motor);
    }
}
