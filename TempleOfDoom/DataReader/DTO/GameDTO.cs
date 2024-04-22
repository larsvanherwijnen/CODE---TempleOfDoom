namespace DataReader.DTO;


public class GameObject
{
    public RoomsDto[] rooms { get; set; }
    public ConnectionsDto[] connections { get; set; }
    public PlayerDto player { get; set; }
}

public class RoomsDto
{
    public int id { get; set; }
    public string type { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public ItemsDto[]? items { get; set; }
    public SpecialFloorTilesDto[]? specialFloorTiles { get; set; }
    public EnemiesDto[]? enemies { get; set; }
}

public class ItemsDto
{
    public string type { get; set; }
    public int damage { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public string color { get; set; }
}

public class SpecialFloorTilesDto
{
    public string type { get; set; }
    public string direction { get; set; }
    public int x { get; set; }
    public int y { get; set; }
}

public class EnemiesDto
{
    public string type { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int minX { get; set; }
    public int minY { get; set; }
    public int maxX { get; set; }
    public int maxY { get; set; }
}

public class ConnectionsDto
{
    public int NORTH { get; set; }
    public int SOUTH { get; set; }
    public DoorsDto[] doors { get; set; }
    public int WEST { get; set; }
    public int EAST { get; set; }
    public PortalDto[] portal { get; set; }

}

public class DoorsDto
{
    public string type { get; set; }
    public string color { get; set; }
    public int no_of_stones { get; set; }
}

public class PortalDto
{
    public int roomId { get; set; }
    public int x { get; set; }
    public int y { get; set; }
}

public class PlayerDto
{
    public int startRoomId { get; set; }
    public int startX { get; set; }
    public int startY { get; set; }
    public int lives { get; set; }
}