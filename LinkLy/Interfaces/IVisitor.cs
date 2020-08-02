using LinkLy.Models;

namespace LinkLy.Interfaces
{
    public interface IVisitor
    {
        public IpInfo GetIpInfo(string ipNumber);
    }
}
