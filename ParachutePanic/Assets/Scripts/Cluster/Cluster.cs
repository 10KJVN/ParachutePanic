using UnityEngine;

/// <summary>
/// This class handles the movement behavior of all clusters
/// Parachutes, Obstacles, Heals you name it.
/// It initiates these with randomized speed values as well.    
/// BounceSpeed is the multiplying factor of the HorizontalMoveSpeed.
/// </summary>

public class Cluster : MonoBehaviour
{
    [Tooltip("Movement Variable")]
    [SerializeField] private float bounceSpeed;
    [Tooltip("Auto assigned, serialized to verify")]
    [SerializeField] private ScoreHandler scoreSystem;

    private float horizontalMoveSpeed;
    private float verticalMoveSpeed;
    private int posX;
    private int posY;
    private int speedX;
    private int speedY;

    private void InitiateCluster( int height )
    {
        var heightVariation = -5;
        var minimumHorizontalPosition = -9;
        var maximumHorizontalPosition = 9;

        var minimumHorizontalSpeed = 7;
        var maximumHorizontalSpeed = 16;
        var minimumVerticalSpeed = 6;
        var maximumVerticalSpeed = 7;
        
        posX = Random.Range( minimumHorizontalPosition, maximumHorizontalPosition );
        posY = height * heightVariation;
        
        speedX = Random.Range( minimumHorizontalSpeed, maximumHorizontalSpeed );
        speedY = Random.Range( minimumVerticalSpeed, maximumVerticalSpeed );
    }
    
    private void Start()
    {
        scoreSystem = GameObject.Find( "Managers" ).GetComponent<ScoreHandler>();
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
            scoreSystem.DecrementScore( 1 );
            Destroy( gameObject );
        }
        
        // If Enemy missed player, score +2
        // Score Calculation -> BottomBound.cs
    }

    private int CalculatePosition( int currentPos, int velocity )
    {
        return currentPos + velocity;
    }

    private int CalculateVelocity( int pos, int velocity, int min, int max )
    {
        if ( pos <= min || pos >= max )
        {
            velocity *= -1;
        }

        return velocity;
    }

    // TODO: Debug Time related stutter bug, probs happens here.
    private void UpdateClusterPosition()
    {
        var min = -10;
        var max = 10;
        var half = 2;

        posX = CalculatePosition( posX, speedX );
        speedX = CalculateVelocity( posX, speedX, min, max );
        
        posY = CalculatePosition( posY, speedY );

        horizontalMoveSpeed += posX * bounceSpeed * Time.deltaTime;
        verticalMoveSpeed = posY * Time.deltaTime / half;
    }
}
