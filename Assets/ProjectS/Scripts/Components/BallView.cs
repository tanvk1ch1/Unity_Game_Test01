using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectS
{
    public class BallView : MonoBehaviour
    {
        #region Member
        
        [SerializeField] private Image _image;
        [SerializeField] private Text _pointText;
        private Animator _animator;
        
        #endregion
        
        #region MonoBehavior
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            gameObject.SetActive(false);
        }
        
        #endregion
        
        #region Method
        
        public void SetPosition(Vector3 pos)
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            transform.localPosition = pos;
        }
        
        public void StartAnimation()
        {
            _animator.SetBool("Attack", true);
        }
        
        public void SetPoint(int point)
        {
            _pointText.text = point.ToString();
        }
        
        public void SetDisable()
        {
            gameObject.SetActive(false);
        }
        
        public void SetColor(Color color)
        {
            _image.color = color;
        }
        
        #endregion
    }
}