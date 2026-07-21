using UnityEngine;

public class Bird : MonoBehaviour , IPlayerDamageable
{
    //HP
    public int Break;

    public float enemySpeedmin;

    // �J�n�n�_
    public Vector2 startPos;
    // �I���n�_
    public Vector2 endPos;
    // �ʂ̍���
    public float arcHeight = 3.0f;
    // �ړ��ɂ����鎞��
    public float duration = 1.0f;

    private float timer = 0.0f;

    [SerializeField] private GameObject popEffect;

    PlayerManager player;

    public enum State
    {
        flying, //��Ԃ����I�I
    }

    State state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerManager>();

        state = State.flying;
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case State.flying:
                AirMove();
                break;
        }

        if (transform.position.x < -6)
        {
            player.UpdateHealth();

            Destroy(this.gameObject);
            Instantiate(popEffect, transform.position, transform.rotation);
        }
    }

    void AirMove()
    {
        // ���Ԃ𑝂₷
        timer += Time.deltaTime;
        float ratio = timer / duration;

        // �ړ����I�������~�߂�
        if (ratio >= 1.0f)
        {
            ratio = 1.0f;
        }

        // --- �ʂ�`���v�Z ---
        // 1. �܂������i�ވʒu���v�Z
        Vector2 currentPos = Vector2.Lerp(startPos, endPos, ratio);

        // 2. �ʂ̍����i�R�Ȃ�j���v�Z (sin�֐��𗘗p)
        float heightOffset = Mathf.Sin(ratio * Mathf.PI) * arcHeight;

        // 3. Y���W�ɍ����𑫂�
        currentPos.y += heightOffset;

        // �I�u�W�F�N�g���ړ�
        transform.position = currentPos;
    }

    public void Hit(int damage)//�_���[�W����
    {
        Break -= damage;

        E_HP Hscript = GetComponent<E_HP>();     //�����I�u�W�F�N�g��HP�o�[�X�N���v�g�Ăяo��
        Hscript.damageHP(damage);               //HP�o�[�̏���

        if (Break <= 0)//�G�L�����N�^�[�̂g�o���O�̏ꍇ
        {
            player.score += 100;
            //�X�R�A���Z�p�X�N���v�g
            Destroy(this.gameObject);
            Instantiate(popEffect,transform.position, transform.rotation);
        }
    }
}
