using GunComponents;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace CharacterComponents
{
    internal class States : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private CharacterController _controller;
        [SerializeField, HideInInspector]
        private int _level = 1;
        [SerializeField]
        private int _xpMax;
        [SerializeField]
        private int _xp;
        [SerializeField]
        private int _hpMax;
        [SerializeField]
        private int _hp;
        [SerializeField]
        private int _spMax;
        [SerializeField]
        private int _sp;
        [SerializeField]
        private int _restoreSP;
        [SerializeField]
        private int _expendSP;
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _speedRun;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _controller.run += ExpendStamina;
            _controller.walk += RestoreStamina;
            _controller.idle += RestoreStamina;
            _controller.changeHp += ChangeHp;
            _controller.riseXp += RiseXp;
        }

        private void OnDisable()
        {
            _controller.run -= ExpendStamina;
            _controller.walk -= RestoreStamina;
            _controller.idle -= RestoreStamina;
            _controller.changeHp -= ChangeHp;
            _controller.riseXp -= RiseXp;
        }

        internal float Speed { get {  return _speed; } }

        internal float SpeedRun {  get { return _speedRun; } }

        internal int Level { get { return _level; } }
        internal float XPNormalized { get { return ((float)_xp) / _xpMax; } }
        internal float HPNormalized { get { return ((float)_hp) / _hpMax; } }
        internal float SPNormalized { get { return ((float)_sp) / _spMax; } }

        internal bool IsItFullHp()
        {
            return _hp == _hpMax;
        }

        internal bool IsItFullSp()
        {
            return _sp == _spMax;
        }

        internal bool HasSp()
        {
            return _sp > 0;
        }

        internal void RiseXp(int x)
        {
            if (x < 0) { return; }
            _xp += x;
            while (_xp >= _xpMax)
            { 
                LevelUp();
            }
            _controller.xpChange?.Invoke();
        }

        private void LevelUp()
        {
            _level++;
            _controller.levelUp?.Invoke();
            _xp -= _xp;
            _xpMax *= 2;
        }

        private void ChangeHp(int x)
        {
            _hp += x;
            if (_hp <= 0)
            {
                _hp = 0;
                Die();
            }
            else
            {
                _hp = _hpMax;
            }
        }

        private void Die()
        {
            _controller.die?.Invoke();
        }

        private void ExpendStamina()
        {
            if (!HasSp()) { return; }
            _sp -= _sp - _expendSP >= 0 ? _expendSP : _sp;
            _controller.spChange?.Invoke();
        }

        private void RestoreStamina()
        {
            if (IsItFullSp()) { return; }
            _sp += _sp + _restoreSP <= _spMax ? _restoreSP : _spMax - _sp;
            _controller.spChange?.Invoke();
        } 
    }
}