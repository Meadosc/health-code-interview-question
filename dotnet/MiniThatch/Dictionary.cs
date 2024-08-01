namespace MiniThatch;
using Collections = System.Collections.Generic;
using System.Text.Json;

public class Dictionary<K, V> : Collections.Dictionary<K, V>
{
    private readonly JsonSerializerOptions serializerOptions = new()
    {
        WriteIndented = true,
    };

    public override string ToString()
    {
        return JsonSerializer.Serialize(this, serializerOptions);
    }

    public override bool Equals(object obj)
    {
        if (obj is Dictionary<K, V> other)
        {
            return this.Count == other.Count && !this.Except(other).Any();
        }
        else
        {
            return false;
        }
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}