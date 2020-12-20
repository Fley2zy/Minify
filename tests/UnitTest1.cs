using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Localization;
using Minify.Model;
using Xunit;

namespace Minify.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TokenIsDifferent()
        {
            TokenGenerator TokenGenerator = new TokenGenerator();
            string Token = TokenGenerator.Generate();

            Assert.NotEqual(Token, TokenGenerator.Generate());
        }

        [Fact]
        public void TokenIsNotNull()
        {
            TokenGenerator TokenGenerator = new TokenGenerator();
            string Token = String.Empty;

            Assert.NotEqual(Token, TokenGenerator.Generate());
        }

        [Fact]
        public void AddGetDelete()
        {
            MongoRepository repository = new MongoRepository();
            MinifyData data = new MinifyData();
            data.Url = "check";

            repository.Add(data);

            MinifyData dataAfterAdd = new MinifyData();
            var values = repository.Get();

            foreach(MinifyData value in values) {
                if (value.Url == "check")
                {
                    dataAfterAdd = value;
                }
            }
            Assert.IsType<MinifyData>(dataAfterAdd);
            Assert.Equal(data._id, dataAfterAdd._id);

            repository.Delete(data._id);

            MinifyData dataAfterDelete = new MinifyData();
            var values2 = repository.Get();
            foreach(MinifyData value in values2) {
                if (value.Url == "check")
                {
                    dataAfterDelete = value;
                }
            }
            Assert.Null(dataAfterDelete._id);
        }
    }
}