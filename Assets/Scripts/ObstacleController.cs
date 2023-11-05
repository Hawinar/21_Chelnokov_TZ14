using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb2d;

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rb2d.MovePosition(new Vector2(_rb2d.position.x - 0.05f, _rb2d.position.y));
    }
}
