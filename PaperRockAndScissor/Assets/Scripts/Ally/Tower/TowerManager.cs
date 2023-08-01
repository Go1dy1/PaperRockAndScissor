using DG.Tweening;
using Storage;
using TMPro;
using UnityEngine;


    public class TowerManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _collectedHealText;
        [SerializeField] private GameObject _myCastleObject;
        public static int HealPointTower { get; private set;}
        private readonly Vector3 _myFrontPosition = new Vector3(0.04f,0f,-19.298f);
        private readonly Vector3 _myBackPosition = new Vector3(0f,0f,-19.66f);
        public Transform AllyPos{get;private set;}
        internal static TowerManager Ally;

        private void Awake()
        {
            HealPointTower = 5;
        }

        private void Start()
        {
            
            Ally= this;
            AllyPos = gameObject.transform;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<EnemyCard>() != null || other.GetComponentInChildren<EnemyCard>() != null)
            {
                MoveTowerTakenDamage();
                CharacterManager.EnemyList.Remove(other.gameObject);
                Destroy(other.gameObject);

                UpdateHealText();
            }
        }

        private void MoveTowerTakenDamage()
        {
            _myCastleObject.transform.DOMove(_myFrontPosition, 0f);
            _myCastleObject.transform.DOMove(_myBackPosition, 1f);
            if (HealPointTower > 0) HealPointTower-- ;
        }

        private void UpdateHealText()
        {
            _collectedHealText.text = HealPointTower.ToString();
        }


    }

