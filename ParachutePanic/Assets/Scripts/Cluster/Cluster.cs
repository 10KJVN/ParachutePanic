using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// This class handles the movement behaviour of all clusters
/// Parachutes, Obstacles, Heals you name it.
/// It initiates these with randomized speed values as well.
/// BounceSpeed is the multiplying factor of the HorizontalMoveSpeed.
/// 
/// TO-DO: Less Magic numbers in InitCluster function.
/// </summary>

public class Cluster : MonoBehaviour
{
    [Header( "Movement Variable" )]
    public float bounceSpeed;
    
    [SerializeField] private ScoreManager scoreManager;

    private float horizontalMoveSpeed;
    private float verticalMoveSpeed;
    private int posX;
    private int posY;
    private int speedX;
    private int speedY;

    private void InitiateCluster( int height )
    {
        posX = Random.Range( -9, 9 );
        posY = height * -5;
        
        speedX = Random.Range( 7, 16 );
        speedY = Random.Range( 6, 7 );
    }


    private void Start()
    {
        scoreManager = GameObject.Find( "ScoreManager" ).GetComponent<ScoreManager>();
        horizontalMoveSpeed = posX + speedX;
        verticalMoveSpeed = posY + speedY;
        
        for ( int t = 0; t <= 10; t += 1 )
        {
            InitiateCluster( t );
        }
    }

    private void Update()
    {
        transform.Translate( Vector2.right * horizontalMoveSpeed * Time.deltaTime );
        transform.Translate( Vector2.down * verticalMoveSpeed * Time.deltaTime );
        UpdateClusterPosition();
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (collision.gameObject.CompareTag( "Boundary" ))
        {
            transform.position = new Vector3( transform.position.x, transform.position.y - 1, transform.position.z );
            horizontalMoveSpeed *= -1;
        }
        
        if (collision.gameObject.CompareTag( "BoundsOut" ))
        {
            scoreManager.ChangeScore( -1 );
            Destroy( gameObject );
        }
        
        // If Enemy missed player, score +2
        // Score Calculation -> BottomBound.cs
    }

    int CalculatePosition( int currentPos, int velocity )
    {
        return currentPos + velocity;
    }

    int CalculateVelocity( int pos, int velocity, int min, int max )
    {
        if ( pos <= min || pos >= max )
        {
            velocity *= -1;
        }

        return velocity;
    }

    private void UpdateClusterPosition()
    {
        posX = CalculatePosition( posX, speedX );
        speedX = CalculateVelocity( posX, speedX, -10, 10 );
        
        posY = CalculatePosition( posY, speedY );

        horizontalMoveSpeed += posX * bounceSpeed * Time.deltaTime;
        verticalMoveSpeed = posY * Time.deltaTime / 2;
    }
}
