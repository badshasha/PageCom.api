using System.Reflection.Metadata.Ecma335;

namespace PageCome.Api.Demain.BaseDomain;

public class BaseDomainInfo
{
    public int Id { get; set; }
    public DateTime AddDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;
}