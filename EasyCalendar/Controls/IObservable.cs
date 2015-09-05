namespace EasyCalendar.Controls
{
    public interface IObservable
    {
        IObserver Observer { get; set; }
    }
}
