using System.Threading.Tasks;

namespace Firework
{
    public interface IFireworkHub
    {
        Task Add(int type, double x, double y, string color, int tail);
    }
}
