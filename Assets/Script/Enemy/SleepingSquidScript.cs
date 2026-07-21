using UnityEngine;
using UnityEngine.Rendering;

public class SleepingSquidScript : MonoBehaviour, IPlayerDamageable
{
    Vector2 pos;
    //HP
    public int Break;

    private float damageTimer;

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

    [SerializeField] private SortingGroup sortingGroup;

    //animation
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject popEffect;

    //audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioDeath;

    PlayerManager player;
    public enum State
    {
        move,   //�O�i��
        flying, //���
        damage  //�_���[�W���󂯂�
    }

    State state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerManager>();

        state = State.move;
        pos = transform.position;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sortingGroup.sortingOrder = Mathf.RoundToInt(-transform.position.y) * 100;

        switch (state)
        {
            case State.move:
                if (pos.x > startPos.x)
                {
                    pos.x += Time.deltaTime * -enemySpeedmin;
                    transform.position = pos;

                    anim.Play("sleepingState");
                }
                else
                {
                    state = State.flying;
                    anim.Play("flyingState");
                }
                break;
            case State.flying:
                AirMove();
                break;
            case State.damage:
                EDamage();
                break;
        }

        if (transform.position.x < -6)
        {
            player.UpdateHealth();

            Destroy(this.gameObject);
            Instantiate(popEffect, transform.position, transform.rotation);
        }
    }

    void AirMove()//�v���C���[�Ɍ�����
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

    void EDamage()//��u�~�܂��āA�܂��O�i���
    {
        // ���Ԃ𑝂₷
        damageTimer += Time.deltaTime;

        //���Ԃ��O�D�T�߂���ƑO�ɓ����n�߂�
        if (damageTimer >= 0.5)
        {
            damageTimer = 0;
            state = State.move;
        }
    }

    public void Hit(int damage)//�_���[�W����
    {
        Break -= damage;

        E_HP Hscript = GetComponent<E_HP>();     //�����I�u�W�F�N�g��HP�o�[�X�N���v�g�Ăяo��
        Hscript.damageHP(damage);               //HP�o�[�̏���

        state = State.damage;

        if (Break <= 0)//�G�L�����N�^�[�̂g�o���O�̏ꍇ
        {
            player.score += 100;
            //�X�R�A���Z�p�X�N���v�g
            Destroy(this.gameObject);
            Instantiate(popEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(audioDeath, transform.position, 1f);
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        Break--;//�G�L�����N�^�[���|���ꂽ��
    //        if(state == State.move)
    //        {
    //            state = State.damage;
    //        }
    //        if (Break == 0)
    //        {
    //            //this.director.GetComponent<Score>().EnemyHit1();
    //            //this.director.GetComponent<gameDirector>().EnemyHit10();
    //            Destroy(this.gameObject);

    //        }
    //    }
    //}
}
