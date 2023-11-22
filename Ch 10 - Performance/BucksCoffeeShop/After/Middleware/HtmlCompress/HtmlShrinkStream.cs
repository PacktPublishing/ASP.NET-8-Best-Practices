using System.Text;
using System.Text.RegularExpressions;

namespace BucksCoffeeShop.Infrastructure.HtmlCompress;

public class HtmlShrinkStream: Stream
{
    private readonly Stream _responseStream;

    public HtmlShrinkStream(Stream responseStream)
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

    public override void Flush() => _responseStream.Flush();
    public override int Read(byte[] buffer, int offset, int count) => 
        _responseStream.Read(buffer, offset, count);

    public override long Seek(long offset, SeekOrigin origin) => 
        _responseStream.Seek(offset, origin);
    
    public override void SetLength(long value) => 
        _responseStream.SetLength(value);

    public override void Write(byte[] buffer, int offset, int count)
    {
        var html = Encoding.UTF8.GetString(buffer, offset, count);
        var reg = new Regex(@"(?<=\s)\s+(?![^<>]*</pre>)");
        html = reg.Replace(html, string.Empty);

        buffer = Encoding.UTF8.GetBytes(html);

        _responseStream.WriteAsync(buffer, 0, buffer.Length);
    }
}

