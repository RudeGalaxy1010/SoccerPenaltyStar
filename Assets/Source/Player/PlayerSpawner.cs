using UnityEngine;

public class PlayerSpawner
{
    private Vector3 _ballOffset;

    public PlayerSpawner(Vector3 ballOffset)
    {
        _ballOffset = ballOffset;
    }

    public Player CreatePlayer(Map map, Player playerPrefab)
    {
        Player player = Object.Instantiate(playerPrefab, map.PlayerSpawnPosition, Quaternion.identity);
        return player;
    }

    public Ball CreateBall(Vector3 playerPosition, Ball ballPrefab)
    {
        Vector3 ballPosition = playerPosition + _ballOffset;
        Ball ball = Object.Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        return ball;
    }
}
