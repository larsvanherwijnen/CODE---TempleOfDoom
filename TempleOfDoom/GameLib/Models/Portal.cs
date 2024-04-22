namespace GameLib.Models;

public class Portal 
{
    private Room TargetRoom { get; }
    private Coords TargetCoords { get; }
    
    public Portal(Room targetRoom, Coords coords)
    {
        TargetRoom = targetRoom;
        TargetCoords = coords;
    }
    public void GetSpawnCoords(out Room targetRoom, out Coords spawnCoords)
    {
        targetRoom = TargetRoom;
        spawnCoords = TargetCoords;
    }
}