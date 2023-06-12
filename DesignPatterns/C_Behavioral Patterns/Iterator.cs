namespace DesignPatterns.C_Behavioral_Patterns;

#region Aggregator

public interface IAggregator<T>
{
    void Add(T item);
    void Remove(T item);
    void Clear();
    int Count { get; }
    IIterator<T> Iterator { get; }
    T this[int index] { get; set; }
}

public class Aggregator<T> : IAggregator<T>
{
    private List<T> _items = new List<T>();
    private IIterator<T> _iterator;


    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }

    public void Clear()
    {
        _items.Clear();
    }

    public int Count => _items.Count;

    public T this[int index]
    {
        get { return _items[index]; }
        set { _items[index] = value; }
    }

    public IIterator<T> Iterator => _iterator ??= new Iterator<T>(this);
}


#endregion

#region Iterator

public interface IIterator<T>
{
    T Current { get; }
    T Previous { get; }
    T Next { get; }
    bool HasNext();
}

public class Iterator<T> : IIterator<T>
{
    private readonly IAggregator<T> _aggregator;
    private int _currentIndex;

    public Iterator(IAggregator<T> aggregator)
    {
        _aggregator = aggregator;
        _currentIndex = -1;
    }


    public T Current => _aggregator[_currentIndex];

    public T Previous=> _aggregator[--_currentIndex];

    public T Next=>_aggregator[++_currentIndex];
    
    public bool HasNext()
    {
        if (_currentIndex == -1)
        {
            _currentIndex = 0;
            return true;
        }
        else if(_currentIndex!= _aggregator.Count-1)
        {
            _currentIndex++;
            return true;
        }
        
        return false;
    }
}

#endregion