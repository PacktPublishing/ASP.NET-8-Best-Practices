using System.Text;

namespace EmojiMiddleware.Infrastructure;

public class EmojiStream: Stream
{
    private readonly Stream _responseStream;

    private readonly Dictionary<string, string> _map = new()
    {
        { ":-)", "😊" },
        { ":)", "😊" },
        { ";-)", "😉" }
    };

    public EmojiStream(Stream responseStream)
    {
        ArgumentNullException.ThrowIfNull(responseStream);

        _responseStream = responseStream;
    }

    public override bool CanRead => _responseStream.CanRead;
    public override bool CanSeek => _responseStream.CanSeek;
    public override bool CanWrite => _responseStream.CanWrite;
    public override long Length => _responseStream.Length;
    public override long Position
    {
        get => _responseStream.Position;
        set => _responseStream.Position = value;
    }

    public override void Flush()
    {
        _responseStream.Flush();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return _responseStream.Read(buffer, offset, count);
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return _responseStream.Seek(offset, origin);
    }

    public override void SetLength(long value)
    {
        _responseStream.SetLength(value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        var html = Encoding.UTF8.GetString(buffer, offset, count);
        foreach (var emoticon in _map)
        {
            if (!html.Contains(emoticon.Key)) continue;

            html = html.Replace(emoticon.Key, emoticon.Value);
        }
        buffer = Encoding.UTF8.GetBytes(html);

        _responseStream.Write(buffer, 0, buffer.Length);
    }
}
