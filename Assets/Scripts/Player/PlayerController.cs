using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projeto.Core.Singleton;
using TMPro;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    public float speed;

    [Header("Lerp")]
    public Transform target;
    public float speedLerp;
    public string tagEnemy = "Enemy";
    public string tagEndLine = "End Line";

    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 7;

    public GameObject endScreen;
    public bool invencible;
    public TextMeshPro uiTextPowerUp;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    public BounceHelper bounceHelper;
    private void Start()
    {
        _startPosition = transform.position; 
        ResetSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, speedLerp * Time.deltaTime);
    }

    public void Bounce()
    {
        bounceHelper.Bounce();
    }

    public void BounceStart()
    {
        bounceHelper.BounceStart();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(tagEnemy))
        {
            if (!invencible)
            {
                EndGame(AnimatorManager.AnimationType.DEAD);
                MoveBack();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tagEndLine))
        {
            if (!invencible) EndGame();
        }
    }

    private void MoveBack()
    {
        transform.DOMoveZ(-1, 1).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.PlayAnim(animationType);
    }

    public void StartRun()
    {
        _canRun = true;
        BounceStart();
        animatorManager.PlayAnim(AnimatorManager.AnimationType.RUN,_currentSpeed / _baseSpeedToAnimation);
    }
    #region POWER UPS
    public void SetPowerUpText(string s) 
    { 
        uiTextPowerUp.text = s; 
    }
    public void PowerUpSpeedUp(float f) 
    { 
        _currentSpeed = f; 
    }
    public void ResetSpeed() 
    { 
        _currentSpeed = speed; 
    }

    public void SetInvencible(bool b) 
    { 
        invencible = b; 
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease) 
    {
        /*var p = transform.position;        
         * p.y = _startPosition.y + amount;        
         * transform.position = p;*/
        transform.DOMoveY(_startPosition.y + amount,
        animationDuration).SetEase(ease);//.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight() 
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }
    #endregion
}
