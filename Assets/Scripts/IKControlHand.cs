using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControlHand : MonoBehaviour
{
    [SerializeField]
    private bool _isActive;

    [SerializeField]
    private Transform _pointHandObject;

    [SerializeField]
    private Transform _pointHandObjectL;

    [SerializeField]
    private float _valueWeight;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_animator)
        {
            if (_isActive)
            {
                if (_pointHandObject != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _valueWeight);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, _valueWeight);

                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _pointHandObject.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _pointHandObject.rotation);

                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, _valueWeight);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, _valueWeight);

                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointHandObjectL.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointHandObjectL.rotation);
                }
            }
            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);

                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            }
        }
    }
}
