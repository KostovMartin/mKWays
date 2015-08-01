namespace MkAjax.Demo
{
    public class MainObject
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public OtherObject Data { get; set; }
    }

    public class OtherObject
    {
        public string Description { get; set; }
    }
}