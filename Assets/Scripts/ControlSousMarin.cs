using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControlSousMarin : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;

    [SerializeField] private float _modifierAnimTranslation;
    private Animator _animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    void OnSpeed(InputValue etatBouton)
    {
        if (etatBouton.isPressed)
        {
            _vitessePromenade =_vitessePromenade*2;
            
        }
        else
        {
            _vitessePromenade = _vitessePromenade * 0.5f;
        }

    }
    void OnPromener(InputValue directionBase)
    {
        Vector3 directionAvecVitesse = directionBase.Get<Vector3>();
        directionInput = new Vector3(0f, directionAvecVitesse.z, directionAvecVitesse.y);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mouvement = directionInput;

        _rb.AddForce(mouvement * _vitessePromenade, ForceMode.VelocityChange);

        Vector3 vitesseSurPlanez = new Vector3(0f , 0f, _rb.velocity.z);
        Vector3 vitesseSurPlaney = new Vector3(0f , _rb.velocity.y, 0f);
        _animator.SetFloat("VitesseZ", vitesseSurPlanez.z * _modifierAnimTranslation);
        _animator.SetFloat("VitesseY", vitesseSurPlaney.y * _modifierAnimTranslation);
        _animator.SetFloat("Deplacementz", vitesseSurPlanez.z);
        _animator.SetFloat("Deplacementy", vitesseSurPlaney.y);
    }
}
