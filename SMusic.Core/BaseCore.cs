namespace SMusic.Core;

using SMusic.Data;
using Microsoft.Extensions.DependencyInjection;

public class BaseCore
{
    protected readonly MusicContext _music;
    public BaseCore(IServiceProvider services)
    {
        _music = services.GetRequiredService<MusicContext>();
    }
}
