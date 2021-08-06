using System;
namespace LA.Domain
{
    public interface ILayoutService : IService<LayoutViewModel>
    {
        LayoutViewModel GetDefault();
    }
}
