﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DMS.Log4net
{
    /// <summary>
    /// nlog扩展
    /// </summary>
    public static class Log4Extensions
    {
        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configPath">配置文件路径，默认调用当前项目执行目录下面的log4net.config作为配置文件</param>
        /// <returns></returns>
        public static void ConfigureLog4net(this IConfiguration configuration, string configPath = "")
        {
            Configure(configPath);
        }

        /// <summary>
        /// 使用Log4net
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configPath">配置文件路径，默认调用当前项目执行目录下面的log4net.config作为配置文件</param>
        /// <returns></returns>
        public static IWebHostBuilder UseLog4net(this IWebHostBuilder builder, string configPath = "")
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }
            Configure(configPath);
            return builder;
        }


        /// <summary>
        /// 设置配置文件
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configPath">配置文件路径，默认调用当前项目执行目录下面的log4net.config作为配置文件</param>
        /// <returns></returns>
        public static void Configure(string configPath)
        {
            if (string.IsNullOrEmpty(configPath))
            {
                var currentDir = Directory.GetCurrentDirectory();
                configPath = $@"{currentDir}\nlog.config";
            }
            else
            {
                Log4Context.Configure(configPath);
            }
        }
    }
}