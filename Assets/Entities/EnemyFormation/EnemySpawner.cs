using UnityEngine;
using System.Collections;
//level
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1Prefab;
    
    private int enemiesSpawned = 0;
    private float timeCheck = 0f;

    void Update()
    {
        float spawnAfterSeconds, posX, posY;
        switch (enemiesSpawned)
        {
            case 0:
                spawnAfterSeconds = 1f;
                posX = -2f;
                posY = 3f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 1:
                spawnAfterSeconds = 1f;
                posX = -1f;
                posY = 3f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 2:
                spawnAfterSeconds = 1f;
                posX = 0f;
                posY = 3f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 3:
                spawnAfterSeconds = 1f;
                posX = 1f;
                posY = 3f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 4:
                spawnAfterSeconds = 1f;
                posX = 2f;
                posY = 3f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 5:
                spawnAfterSeconds = 3f;
                posX = 2f;
                posY = 4f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 6:
                spawnAfterSeconds = 0f;
                posX = -2f;
                posY = 4f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            case 7:
                spawnAfterSeconds = 4f;
                posX = 0f;
                posY = 4f;

                SpawnEnemy(spawnAfterSeconds, posX, posY);
                break;
            default:
                break;
        }
    }

    private void SpawnEnemy(float spawnTime, float posX, float posY)
    {
        if (Time.timeSinceLevelLoad > spawnTime + timeCheck)
        {
            GameObject enemy = Instantiate(enemy1Prefab, new Vector3(posX, posY, 0), Quaternion.identity) as GameObject;
            enemy.transform.parent = GameObject.Find("Enemy Spawner").transform;
            enemiesSpawned++;
            timeCheck += spawnTime;
        }
    }
    
    /*
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5.0f;
	public float spawnDelay = 0.5f;
	
	private float xmin;
	private float xmax;
	private bool movingRight = true;
	// Use this for initialization
	void Start () {
		SpawnUntilFull();
		
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		
		xmin = leftmost.x;
		xmax = rightmost.x;
	}

	void SpawnEnemies (){
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;		
		}
		if (NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}else{			
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		if (leftEdgeOfFormation < xmin){
			movingRight = true;
		}else if(rightEdgeOfFormation > xmax){
			movingRight = false;
		}

		if(AllMembersDead()){
			SpawnUntilFull();
		}
	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
    */
}
