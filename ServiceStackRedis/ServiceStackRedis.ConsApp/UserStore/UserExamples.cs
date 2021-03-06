﻿using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStackRedis.ConsApp.Config;
using ServiceStackRedis.ConsApp.Entities;

namespace ServiceStackRedis.ConsApp.UserStore
{
    public static class UserExamples
    {
        private static readonly RedisClient Redis = new RedisClient(RedisConsoleConfig.SingleHost);

        public static void OnBeforeEachInvokeMeothod()
        {
            Redis.FlushAll();
        }

        public static void StoreAndRetrieveUsers()
        {
            var redisUsers = Redis.As<User>();
            redisUsers.Store(new User { Id = redisUsers.GetNextSequence(), Name = "ayende" });
            redisUsers.Store(new User { Id = redisUsers.GetNextSequence(), Name = "mythz" });

            var allUsers = redisUsers.GetAll();
            allUsers.PrintDump();
        }
    }
}
