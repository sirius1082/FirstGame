using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KWJ.FPS.Controller
{
    public class FpsMove : MonoBehaviour
    {


        [Header ("PlayerStats")] 
        [SerializeField]
        private float walkSpeed;

        [SerializeField]
        private float lookSensitivity;

        //카메라의 각도 제한
        [SerializeField]
        private float cameraRotationLimit;
        private float currentCameraRotationX;

        [SerializeField]
        private Camera theCamera;

        private Rigidbody myRigid;



        void Start()
        {
            myRigid = GetComponent<Rigidbody>();

        }

        
        void Update()
        {
            Move();
            CameraRotation();
            CharacterRotation();
        }

        //캐릭터 움직이는 함수
        private void Move()
        {
            float _moveDirX = Input.GetAxisRaw("Horizontal");
            float _moveDirZ = Input.GetAxisRaw("Vertical");

            Vector3 _moveHorizontal = transform.right * _moveDirX;
            Vector3 _moveVertical = transform.forward * _moveDirZ;

            Vector3 _velocity = (_moveHorizontal +  _moveVertical).normalized * walkSpeed;

            myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        }

        //캐릭터 좌우 회전
        private void CharacterRotation()
        {
            float _yRotation = Input.GetAxisRaw("Mouse X");
            Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
            myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        }

        //카메라 상하 회전
        private void CameraRotation()
        {
            float _xRotation = Input.GetAxisRaw("Mouse Y");
            float _cameraRotationX = _xRotation * lookSensitivity;
            currentCameraRotationX -= _cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX , -cameraRotationLimit , cameraRotationLimit);

            theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);

        }
    }
}