﻿using Volo.Abp.Reflection;

namespace Thatch.SaaS.Permissions;

public class SaaSPermissions
{
    public const string GroupName = "SaaS";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SaaSPermissions));
    }
}