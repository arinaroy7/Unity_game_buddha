using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BuddhaController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedDownBuddha;
    [SerializeField] private float _speedUpIncrement;
    [SerializeField] private Button _button;
    [SerializeField] private Image _filledImage;
    [SerializeField] private Transform _upperBound;
    [SerializeField] private Transform _lowerBound;
    [SerializeField] private Transform _imageBuddha;
    [SerializeField] private TextMeshProUGUI _ProgressBar;
    [SerializeField] private Material backgroundMaterial;
    [SerializeField] private float _scrollSpeed = 0.8f;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _gameOverImage;
    [SerializeField] private RectTransform _image1;
    [SerializeField] private RectTransform _image2;
    [SerializeField] private RectTransform _image3;
    [SerializeField] private float _imageMoveSpeed = 50f;

    private Vector2 _offset;
    private float _value = 0.5f;
    private int _clickCount = 0;
    private bool _isGameOver = false;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
        ResetGame();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        if (_isGameOver) return;

        _value += _speedUpIncrement;
        if (_value > 1f)
        {
            _value = 1f;
        }

        _clickCount++;
        if (_clickCount >= 20)
        {
            HidePlatform();
        }
    }

    private void Update()
    {
        float previousValue = _value;
        _value -= _moveSpeed * Time.deltaTime;
        _value = Mathf.Clamp(_value, 0f, 1f);
        _offset.y += _scrollSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset = _offset;
        MoveImages();
        UpdateBuddhaProgress();
        if (_value <= 0f)
        {
            EndGame();
        }
    }

    private void UpdateBuddhaProgress()
    {
        _imageBuddha.position = Vector3.Lerp(_lowerBound.position, _upperBound.position, _value);
        _filledImage.fillAmount = _value;
    }

    private void ResetGame()
    {
        _value = 0.2f;
        _offset = Vector2.zero;
        backgroundMaterial.mainTextureOffset = _offset;
        _clickCount = 0;
        _isGameOver = false;

        if (_platform != null)
        {
            _platform.SetActive(true);
        }

        if (_gameOverImage != null)
        {
            _gameOverImage.SetActive(false);
        }

        UpdateBuddhaProgress();
    }

    private void HidePlatform()
    {
        if (_platform != null)
        {
            _platform.SetActive(false);
        }
    }

    private void GameOver()
    {
        _isGameOver = true;
        if (_gameOverImage != null)
        {
            _gameOverImage.SetActive(true);
        }
        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void EndGame()
    {
        if (_platform != null)
            _platform.SetActive(false);
        if (_filledImage != null)
            _filledImage.gameObject.SetActive(false);
        if (_filledImage.transform.parent != null)
            _filledImage.transform.parent.gameObject.SetActive(false);
        if (_imageBuddha != null)
            _imageBuddha.gameObject.SetActive(false);
        if (_gameOverImage != null)
            _gameOverImage.SetActive(true);
    }

    private void MoveImages()
    {
        _image1.anchoredPosition -= new Vector2(0, _imageMoveSpeed * Time.deltaTime);
        _image2.anchoredPosition -= new Vector2(0, _imageMoveSpeed * Time.deltaTime);
        _image3.anchoredPosition -= new Vector2(0, _imageMoveSpeed * Time.deltaTime);

        if (_image1.anchoredPosition.y < -_image1.rect.height)
        {
            _image1.anchoredPosition = new Vector2(
                _image1.anchoredPosition.x,
                _image3.anchoredPosition.y + _image3.rect.height
            );
        }

        if (_image2.anchoredPosition.y < -_image2.rect.height)
        {
            _image2.anchoredPosition = new Vector2(
                _image2.anchoredPosition.x,
                _image1.anchoredPosition.y + _image1.rect.height
            );
        }

        if (_image3.anchoredPosition.y < -_image3.rect.height)
        {
            _image3.anchoredPosition = new Vector2(
                _image3.anchoredPosition.x,
                _image2.anchoredPosition.y + _image2.rect.height
            );
        }
    }
}