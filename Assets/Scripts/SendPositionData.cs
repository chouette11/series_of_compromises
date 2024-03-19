public class SendPositionData
{
    public float x;
    public float y;
    public float z;
    public string id;
    public string typeText;
    public bool isVisible;
    public string sender;

    public SendPositionData(float x, float y, float z, string id, string typeText, bool isVisible, string sender)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.id = id;
        this.typeText = typeText;
        this.isVisible = isVisible;
        this.sender = sender;
    }
}