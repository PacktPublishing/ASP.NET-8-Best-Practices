using Microsoft.AspNetCore.Mvc;

namespace BucksCoffeeShopAfter.Helpers;

public static class BucksUrlExtensions
{
    public static string HomeUrl(this IUrlHelper helper) =>
        helper.PageLink("/Index")!;
        
    public static string PrivacyUrl(this IUrlHelper helper) =>
        helper.PageLink("/Privacy")!;
}
