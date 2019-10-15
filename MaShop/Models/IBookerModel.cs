namespace MaShop.Models
{
    public interface IBookerModel
    {
        string date { get; set; }
        string time { get; set; }
        string user_id { get; set; }
        string style_id { get; set; }

        string AddEvent();
        string DeleteEvent();
        string UpdateEvent();
    }
}