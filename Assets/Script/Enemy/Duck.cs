using UnityEngine;
using UnityEngine.Rendering;
public class Duck : MonoBehaviour , IPlayerDamageable
{
    Vector2 pos;
    //HP
    public int Break;

    private float damageTimer;

    public float enemySpeedmin;

    public float deathDestination;

    //sprite
    [SerializeField] private SortingGroup sortingGroup;

    [SerializeField] private GameObject popEffect;

    //audio
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioDeath;

    PlayerManager player;

    public enum State
    {
        move,   //�O�i��
        damage  //�_���[�W���󂯂�
    }
    State state;
    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerManager>();

        state = State.move;
        pos = transform.position;

        audioSource = GetComponent<AudioSource>();
    }
    void Update()   
    {

        sortingGroup.sortingOrder = Mathf.RoundToInt(-transform.position.y) * 100;

        switch (state)
        {
            case State.move:
                pos.x += Time.deltaTime * -enemySpeedmin;
                transform.position = pos;
                break;
            case State.damage:
                EDamage();
                break;
        }

        //���ʂƂ���|�C���g
        if (transform.position.x < deathDestination)
        {
            player.UpdateHealth();

            Destroy(this.gameObject);
            Instantiate(popEffect, transform.position, transform.rotation);
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


    void EDamage()//��u�~�܂��āA�܂��O�i���
    {

        // ���Ԃ𑝂₷
        damageTimer += Time.deltaTime;

        //���Ԃ��O�D�T�߂���ƑO�ɓ����n�߂�
        if (damageTimer >= 0.5f)
        {
            damageTimer = 0;
            state = State.move;
        }
    }
}
