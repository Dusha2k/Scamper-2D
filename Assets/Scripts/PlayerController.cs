using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private Transform _feetPos;
    [SerializeField] private LayerMask _whatIsGrounded;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _playerCollider;
    [SerializeField] private Component _playerComponent;
    [SerializeField] private ParticleSystem _dustParticle;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _deathSound;
    [SerializeField] private AudioSource _score;
    [SerializeField] private Joystick _joystick;
    private ParticleSystem.EmissionModule _dustEmission;

    [SerializeField] private float _checkRadius;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private float _moveInput;
    private float _delay = 2;

    private bool _isGrounded;
    private bool _isDead = false;
    private bool _facingRight = true;

    private int _extraJumps;
    private int _countJumpWhenDead = 1;

    static int LoadCount = 0;
    void Start()
    {
        _dustEmission = _dustParticle.emission;

        if (LoadCount % 10 == 0)  
        {
            ShowAd();
        }
        LoadCount++;

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4015237", false);
        }
    }

    
    void Update()
    {
        _moveInput = _joystick.Horizontal;

        //Activation dust particle
        if(_moveInput != 0 && _isGrounded)
        {
            _dustEmission.rateOverTime = 20f;
        }
        else
        {
            _dustEmission.rateOverTime = 0f;
        }

        SetAnimation();

        //Ground checker
        _isGrounded = Physics2D.OverlapCircle(_feetPos.position, _checkRadius, _whatIsGrounded);
    }

    void FixedUpdate()
    {
        

        //The movement of the character
        _playerRb.velocity = new Vector2(_moveInput * _speed, _playerRb.velocity.y);

        //Turn the character on the y axis
        if (_facingRight == false && _moveInput > 0)
        {
            Flip();
        }
        else if(_facingRight == true && _moveInput < 0)
        {
            Flip();
        }
    }

    //Method for turning the character on the y-axis
    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void SetAnimation()
    {
        _animator.SetFloat("xVelocity", Mathf.Abs(_playerRb.velocity.x));
        if (_playerRb.velocity.y > 2)
        {
            _animator.SetBool("isJumping", true);
            _animator.SetBool("isFalling", false);
        }

        if (_playerRb.velocity.y < -2 && _isDead == false)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", true);
        }

        if (_isGrounded == true || _isDead == true)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", false);
        }
    }

    public void Jump()
    {
        if (_isGrounded == true)
        {
            _playerRb.velocity = Vector2.up * _jumpForce;
            _extraJumps = 1;
            _jumpSound.Play();
        }

        if(_isGrounded == false && _extraJumps > 0)
        {
            _playerRb.velocity = Vector2.up * _jumpForce;
            _extraJumps--;
            _jumpSound.Play();
        }

    }

    public void Dead()
    {
        _extraJumps = 0;
        _isGrounded = false;
        _isDead = true;
        _playerRb.rotation = -180f;
        _playerCollider.isTrigger = true;
        if (_countJumpWhenDead > 0)
        {
            _deathSound.Play();
            --_countJumpWhenDead;
            _playerRb.velocity = Vector2.up * _jumpForce;
        }
        _playerComponent.GetComponent<PlayerController>().enabled = false;
        StartCoroutine(LoadLevel(_delay));
    }

    //CollectibleScore sound
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Score")
        {
            _score.Play();
        }

    }
    IEnumerator LoadLevel(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
    }

    
}
