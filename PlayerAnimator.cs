using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        EventsLib.SpeedChanged.OnEventCalled += ToggleMove;
        EventsLib.GroundedChanged.OnEventCalled += ToggleHover;
    }

    private void ToggleHover(object sender, EventArgsLib.GroundedChangedEventArgs e)
    {
        _animator.SetBool("grounded", e._grounded);
    }

    private void ToggleMove(object sender, EventArgsLib.SpeedChangedEventArgs e)
    {
        _animator.SetFloat("walkRun", e._speed);
    }

    private void OnDisable()
    {
        EventsLib.SpeedChanged.OnEventCalled -= ToggleMove;
        EventsLib.GroundedChanged.OnEventCalled -= ToggleHover;
    }
}
