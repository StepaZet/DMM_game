using UnityEngine;

namespace MainGameScripts
{
    public class HumanController : MonoBehaviour
    {
        public int EyeDirection;
        public float speed;
        public Vector2 moveDirection;
        public Rigidbody2D currentRb;
        public Vector2 homePosition;
        public GameObject[] pathPoints;

        private int currentPathPointIndex;

        private float pauseStart;
        private const float pauseTime = 1f;

        private Stage currentStage;


        private enum Stage
        {
            Moving,
            Pause
        }

        private void Start()
        {
            speed = 8f;
            EyeDirection = 1;
            pauseStart = Time.time;
            currentPathPointIndex = 0;
            currentStage = Stage.Pause;
        }

        private void FixedUpdate()
        {
            switch (currentStage)
            {
                case Stage.Pause:
                    var difference = Time.time - pauseStart;
                    if (difference >= pauseTime)
                    {
                        currentStage = Stage.Moving;
                    }
                    break;
                case Stage.Moving:
                    Move();
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.GetComponent<Rigidbody2D>().WakeUp();
        }


        private void OnTriggerStay2D(Collider2D col)
        {
            var rb = col.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(EyeDirection);
            Debug.Log(rb.position.x - currentRb.position.x);
            
            if (Mathf.Sign(rb.position.x - currentRb.position.x) == Mathf.Sign(EyeDirection))
            {
                var sprite = col.gameObject.GetComponent<SpriteRenderer>();
                sprite.color = Color.green;
            }
            else
            {
                var sprite = col.gameObject.GetComponent<SpriteRenderer>();
                sprite.color = Color.white;
            }
        }

        private void Move()
        {
            var distanceToNextTarget = Vector3.Distance(
                transform.position, pathPoints[currentPathPointIndex].transform.position);

            currentRb.velocity = moveDirection * speed;

            if (distanceToNextTarget >= speed * Time.fixedDeltaTime)
                return;

            currentPathPointIndex = GetLoopSum(currentPathPointIndex, 1, pathPoints.Length);
            currentStage = Stage.Pause;
            pauseStart = Time.time;
        }

        private int GetLoopSum(int a, int b, int maxValue)
            => (maxValue + a + b) % maxValue;
        
        private void UpdateMoveDirection()
        {
            moveDirection = new Vector2(
                Mathf.Sign(pathPoints[currentPathPointIndex].transform.position.x - currentRb.position.x),
                0f
                );
        }
    }
}
