using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _bazooka;
    [SerializeField] private Weapon _machineGun;
    [SerializeField] private Squad _squad;
    [SerializeField] private Weapon _artStrike;
    [SerializeField] private Button _squadButton;
    [SerializeField] private Button _machineGunButton;
    [SerializeField] private Button _missileButton;
    [SerializeField] private Button _artStrikeButton;

    private int _maney;
    private int _startCountManey = 100;
    private Weapon _currentWeapon;
    private RaycastHit _hit;
    private ISelectable _currentISelectable;
    private string _score = "_score";

    public Weapon CurrentWeapon => _currentWeapon;
    public int Maney => _maney;

    public UnityAction<int> ChangedManeyCount;

    private void OnEnable()
    {
        _maney = PlayerPrefs.GetInt(_score);
        AddManey(_startCountManey);
        _machineGunButton.onClick.AddListener(OnMachineGunButtonClick);
        _missileButton.onClick.AddListener(OnMessileButtonClick);
        _squadButton.onClick.AddListener(OnSquadButtonClick);
        _artStrikeButton.onClick.AddListener(OnArtStrakeButtonClick);
    }
    private void OnDisable()
    {
        _machineGunButton.onClick.RemoveListener(OnMachineGunButtonClick);
        _missileButton.onClick.RemoveListener(OnMessileButtonClick);
        _squadButton.onClick.RemoveListener(OnSquadButtonClick);
        _artStrikeButton.onClick.RemoveListener(OnArtStrakeButtonClick);
    }

    public void Shooting(Weapon weapon)
    {
        weapon.Shoot();
    }

    public void AddManey(int maneyCount)
    {
        PlayerPrefs.SetInt(_score, _maney += maneyCount);
        _maney = PlayerPrefs.GetInt(_score);
        ChangedManeyCount?.Invoke(_maney);
    }

    public void ReducesManey(int price)
    {
        PlayerPrefs.SetInt(_score, _maney -= price);
        _maney = PlayerPrefs.GetInt(_score);
        ChangedManeyCount?.Invoke(_maney);
    }

    private void OnArtStrakeButtonClick()
    {
        Shooting(_artStrike);
    }

    private void OnSquadButtonClick()
    {
        _squad.OnSquadsButtonClick();
    }

    private void Update()
    {
        AimSelect();
    }

    private void OnMachineGunButtonClick()
    {
        Shooting(_machineGun);
    }

    private void OnMessileButtonClick()
    {
        Shooting(_bazooka);
    }

    private void AimSelect()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out _hit))
        {
            if (_hit.collider.gameObject.TryGetComponent<ISelectable>(out ISelectable selectable))
            {
                if (_currentISelectable != null && _currentISelectable != selectable)
                {
                    _currentISelectable.Deselect();
                }

                selectable.Select();
                _currentISelectable = selectable;
            }
            else
            {
                if (_currentISelectable != null)
                {
                    _currentISelectable.Deselect();
                }
            }                  
        }
        else
        {
            if (_currentISelectable != null)
            {
                _currentISelectable.Deselect();
            }
        }
    }
}
