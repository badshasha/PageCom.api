using PageCome.Api.Demain.BaseDomain;

namespace PageCome.Api.Demain;

public class Book : BaseDomainInfo
{
    public String Name { get; set; }
    public String Description { get; set; }
    public Double Price { get; set; }
}